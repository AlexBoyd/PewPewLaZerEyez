using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {


	public Transform Orientation;
	public LayerMask lm;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Taps.Tapped)
		{
			Debug.DrawRay(Orientation.position, Orientation.forward * 100f, Color.red, 5f); 
			RaycastHit hit;
			if(Physics.Raycast(Orientation.position, Orientation.forward, out hit, 10000f, lm))
			{
				hit.rigidbody.AddExplosionForce(1000f, hit.point, 1f);
				Debug.Log("PEWPEW");
			}
		}
	
	}
}
