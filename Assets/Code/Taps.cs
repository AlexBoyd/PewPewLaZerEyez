using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Taps : MonoBehaviour 
{
	public static bool Tapped {get; set;}

	// Tap calculation variables 
	public float Dadtmultiple = 4;
	public int Minselectmag = 1;
	public int NumAccelerationSamples = 6;
	public Queue<float> YAccels = new Queue<float>();
	public List<float> Dadtvalues = new List<float>();

	// 
	private float lastXAccel = 0;
	private float lastYAccel = 0;
	private float lastZAccel = 0;

	void Update () 
	{
		//Update y accelerations
		if (OVRDevice.GetAcceleration(0, ref lastXAccel, ref lastYAccel, ref lastZAccel))
		{
			YAccels.Enqueue(lastYAccel);

			if(YAccels.Count > NumAccelerationSamples)
			{
				YAccels.Dequeue();
			}
		}
		if(YAccels.Count == NumAccelerationSamples)
		{

			//Update differences
			Dadtvalues.Clear();

			for (int i = 1; i < YAccels.Count; i++)
			{
				Dadtvalues.Add(YAccels.ElementAt(i) - YAccels.ElementAt(i-1));
			}

			//Check for taps
			float avg = Dadtvalues.Average((val) => Mathf.Abs(val));
			Tapped = Dadtvalues.Any(val => Mathf.Abs(val) > avg * Dadtmultiple && Mathf.Abs(val) > Minselectmag); 

		}
	}

}
