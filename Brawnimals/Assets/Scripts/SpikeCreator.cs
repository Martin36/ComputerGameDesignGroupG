using UnityEngine;
using System.Collections;

public class SpikeCreator : MonoBehaviour {


	public GameObject spikeDown;
	public GameObject spikeUp;
	public float shootTime=1.0f;
	private bool canShoot;

	// Use this for initialization
	void Start () {
		canShoot=true;
	}
	
	// Update is called once per frame
	void Update () {

			if (Input.GetMouseButtonDown (0) && canShoot==true) {

				Instantiate (spikeDown, new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 10.0f, 0.0f), Quaternion.Euler (0, 0, 180));
				canShoot = false;
				StartCoroutine (coldDown());

			}

			if (Input.GetMouseButtonDown (1) && canShoot==true ) {

				Instantiate (spikeUp, new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, -10.0f, 0.0f), Quaternion.Euler (0, 0, 0));
				canShoot = false;
				StartCoroutine (coldDown());

			}
	}

	IEnumerator coldDown(){

		yield return new WaitForSeconds (shootTime);
		canShoot = true;

	}


}
