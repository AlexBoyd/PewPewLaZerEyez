using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour 
{
	public float SpawnInterval = 2;
	public GameObject ObjectPrefab;
	public float SpawnRange = 10f;
	public float SpawnVelocity = 15f;
	public float MinVelocity = 3f;
	public float MinSpawnDistance = 0.2f;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(SpawnCoroutine());
	}
	
	// Update is called once per frame
	private IEnumerator SpawnCoroutine() 
	{
		GameObject newObj = null;
		while(true)
		{
			yield return new WaitForSeconds(SpawnInterval);

			newObj = GameObject.Instantiate(ObjectPrefab) as GameObject;
			newObj.transform.parent = transform;
			newObj.transform.position = new Vector3(-(Random.value + MinSpawnDistance), 0, (Random.value + MinSpawnDistance)) * SpawnRange;
			Vector3 velocity = newObj.transform.position * -SpawnVelocity * Random.value + (-MinVelocity * newObj.transform.position);
			float flightTime = newObj.transform.position.magnitude / velocity.magnitude;
			Debug.Log(flightTime);
			newObj.rigidbody.velocity = velocity + (Vector3.up * -Physics.gravity.y * flightTime / 2);


		}
	}
}
