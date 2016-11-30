using UnityEngine;
using System.Collections;

public class ItemsGeneration : MonoBehaviour {

	public GameObject egg;
	public GameObject milk;
	public GameObject wool;
	public GameObject cheese;

	public float spawnTimer=1;

	private Transform pos_gen;
	private int randNum;
	private bool canSpawn = true;



	// Use this for initialization
	void Start () {
		pos_gen = this.transform;
		StartCoroutine(coolDown());
	}
	
	// Update is called once per frame
	void Update () {
	
		if (canSpawn) {
			randNum = Random.Range (1, 5);

			switch (randNum) {

			case 1://EGG
				Instantiate (egg, new Vector3 ((pos_gen.position.x + Random.Range (-14.0f, 14.0f)), pos_gen.position.y, pos_gen.position.z), new Quaternion (0, 0, 0, 0));
				break;
			case 2://milk
				Instantiate (milk, new Vector3 ((pos_gen.position.x + Random.Range (-14.0f, 14.0f)), pos_gen.position.y, pos_gen.position.z), new Quaternion (0, 0, 0, 0));
				break;
			case 3://wool
				Instantiate (wool, new Vector3 ((pos_gen.position.x + Random.Range (-14.0f, 14.0f)), pos_gen.position.y, pos_gen.position.z), new Quaternion (0, 0, 0, 0));
				break;
			case 4://cheese
				Instantiate (cheese, new Vector3 ((pos_gen.position.x + Random.Range (-14.0f, 14.0f)), pos_gen.position.y, pos_gen.position.z), new Quaternion (0, 0, 0, 0));
				break;
			}
			canSpawn = false;
		}
			
	}

	IEnumerator coolDown()
	{
		while (true){
			yield return new WaitForSeconds (spawnTimer);
		canSpawn = true;
		}
	}
}
