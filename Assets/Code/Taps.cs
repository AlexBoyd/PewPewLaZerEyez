using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Taps : MonoBehaviour 
{

	bool tapped = false;

	// Tap calculation variables 
	int starti = 3;
	int currenti = starti;
	int savedmax = 0;
	int dadtmultiple = 4;
	int minselectmag = 1;
	int numAccelerationSamples = 6;
	Queue<int> yAccels = new Queue<int>();
	List<int> dadtvalues = new List<int>();

	// Tap strength variables
	int tapAccelMultiplier = 5;
	int tapDisableTicks = 0;
	int tapDisableLength = 10;

	// 
	int lastXAccel = 0;
	int lastYAccel = 0;
	int lastZAccel = 0;

	// Use this for initialization
	void Start () 
	{


	
	}

	void Update () 
	{
		//Update y accelerations
		if (OVRDevice.GetAcceleration(0, ref lastXAccel, ref lastYAccel, ref lastZAccel))
		{
			yAccels.Enqueue(lastYAccel);

			if(yAccels.Count > numAccelerationSamples)
			{
				yAccels.Dequeue();
			}
		}


		//Update differences
		dadtvalues.Clear();
		for (int i = 1; i < yAccels.Count; i++)
		{
			dadtvalues[i-1] = yAccels[i] - yAccels[i-1];
		}

		//Check for taps
		int avg = dadtvalues.Average();
		tapped = dadtvalues.Any(val => Mathf.Abs(val) > avg * dadtmultiple && Mathf.Abs(val) > minselectmag) 

	}


}
