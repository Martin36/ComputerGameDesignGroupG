using UnityEngine;
using System.Collections;

public class ChangeGravity : MonoBehaviour {

	public float amountX = 2.0f;
	public float amountY = 2.0f;
	private float gravityX=0;
	private float gravityY=0;
	private int duration=0;
	private bool checkOnce=true;

	// Use this for initialization
	void Start () {
		GlobalVariables.numPlayers = 3;
		gravityY = Physics2D.gravity.y;
		StartCoroutine (levelDuration ());
	}
	
	// Update is called once per frame
	void Update () {


		//check if game is over

		if (GlobalVariables.numPlayers == 0 && checkOnce==true) {
			putScoreMousePlayer ();
			checkOnce = false;
			
		}
	
		if (Input.GetMouseButton(0)) {
			gravityX -= amountX;

		}

		if (Input.GetMouseButton(1)) {
			gravityX += amountX;

		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			gravityY -= amountY;
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			gravityY += amountY;
		}


		Physics2D.gravity = new Vector2 (gravityX, gravityY);
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
			GlobalVariables.lastGameScoreP4 += 500/duration; // the mouse controller is the mouse
		}

		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 1) {
			GlobalVariables.lastGameScoreP3 += 500/duration; // the mouse controller is the cow

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 2) {
			GlobalVariables.lastGameScoreP2 += 500/duration; // the mouse controller is the sheep

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 3) {
			GlobalVariables.lastGameScoreP1 += 500/duration; // the mouse controller is the chicken

		}
	}
}
