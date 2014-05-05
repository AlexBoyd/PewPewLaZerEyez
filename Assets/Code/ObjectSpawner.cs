using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour 
{
	public float SpawnInterval = 2;
	public GameObject ObjectPrefab;
	public float SpawnRange = 10f;
	public float SpawnVelocity = 10f;
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
			newObj.transform.position = Random.insideUnitSphere * SpawnRange;
			newObj.rigidbody.AddForce(newObj.transform.position * -SpawnVelocity);
		}
	}
}
