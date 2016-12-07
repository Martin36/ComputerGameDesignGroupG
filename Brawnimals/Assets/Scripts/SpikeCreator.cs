using UnityEngine;
using System.Collections;

public class SpikeCreator : MonoBehaviour
{
	public GameObject spikeDown;
	public GameObject spikeUp;
	public float shootTime = 1.0f;
	private bool canShoot;
	private int duration=0;
	private bool checkOnce=true;

	void Start()
	{
		canShoot = true;
		StartCoroutine (levelDuration ());
	}

	void Update()
	{

		if (GlobalVariables.numPlayers == 0 && checkOnce==true) {
			putScoreMousePlayer ();
			checkOnce = false;

		}

		if (Input.GetMouseButtonDown(0) && canShoot == true)
		{

			Instantiate(spikeDown, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 10.0f, 0.0f), Quaternion.Euler(0, 0, 180));
			canShoot = false;
			StartCoroutine(coldDown());

		}

		if (Input.GetMouseButtonDown(1) && canShoot == true)
		{

			Instantiate(spikeUp, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -10.0f, 0.0f), Quaternion.Euler(0, 0, 0));
			canShoot = false;
			StartCoroutine(coldDown());

		}
	}

	IEnumerator coldDown()
	{

		yield return new WaitForSeconds(shootTime);
		canShoot = true;

	}

	IEnumerator levelDuration()
	{

		while (true) {
			yield return new WaitForSeconds(1);
			duration++;

		}

	}

	void putScoreMousePlayer(){

		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 0) {
			GlobalVariables.lastGameScoreP4 += 800/duration; // the mouse controller is the mouse
		}

		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 1) {
			GlobalVariables.lastGameScoreP3 += 800/duration; // the mouse controller is the cow

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 2) {
			GlobalVariables.lastGameScoreP2 += 800/duration; // the mouse controller is the sheep

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 3) {
			GlobalVariables.lastGameScoreP1 += 800/duration; // the mouse controller is the chicken

		}
	}


}
