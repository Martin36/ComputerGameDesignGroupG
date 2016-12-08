using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level1SpikesHardcore : MonoBehaviour
{

	public float levelTimer;
	public Button exitButton;
	public Text textWin;
	public GameObject chicken;
	public GameObject chicken1;
	public GameObject chicken2;
	public GameObject chicken3;
	public GameObject sheep;
	public GameObject sheep1;
	public GameObject sheep2;
	public GameObject sheep3;
	public GameObject cow;
	public GameObject cow1;
	public GameObject cow2;
	public GameObject cow3;
	public GameObject mouse;
	public GameObject mouse1;
	public GameObject mouse2;
	public GameObject mouse3;

	void Start()
	{
		checkControllers ();
		Time.timeScale = 1.0f;
		StartCoroutine(levelDuration());

	}

	void Update()
	{
		if (GlobalVariables.numPlayers == 0)
		{
			Time.timeScale = 0.0f;
			textWin.text = "Game Over";
			textWin.gameObject.SetActive(true);
			exitButton.gameObject.SetActive(true);
		}
	}

	IEnumerator levelDuration()
	{

		yield return new WaitForSeconds(levelTimer);
		Time.timeScale = 0.0f;
		exitButton.gameObject.SetActive(true);
		textWin.text = "Game Over";
		textWin.gameObject.SetActive(true);

	}

	public void exitLevel()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(4, LoadSceneMode.Single);
	}

	void checkControllers(){


		//remember to substitute 3 -> 4, the third number it was just a test, we need to put the 4 for the gamepad controller

		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 0) {
			chicken.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			chicken1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			chicken2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			chicken3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			sheep.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			sheep1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			sheep2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			sheep3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			cow.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; //thats the gamepad in the other script
			cow1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; //thats the gamepad in the other script
			cow2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; //thats the gamepad in the other script
			cow3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; //thats the gamepad in the other script
			Destroy (mouse);
			Destroy (mouse1);
			Destroy (mouse2);
			Destroy (mouse3);

		}

		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 1) {
			chicken.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			chicken1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			chicken2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			chicken3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			sheep.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			sheep1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			sheep2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			sheep3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			mouse.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1; 
			mouse1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1; 
			mouse2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1; 
			mouse2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1; 
			Destroy (cow);
			Destroy (cow1);
			Destroy (cow2);
			Destroy (cow3);

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 2) {
			chicken.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			chicken1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			chicken2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			chicken3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			cow.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			cow1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			cow2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			cow3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			mouse.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2; 
			mouse1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2; 
			mouse2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2; 
			mouse3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2; 
			Destroy (sheep);
			Destroy (sheep1);
			Destroy (sheep2);
			Destroy (sheep3);

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 3) {
			cow.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			cow1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			cow2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			cow3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			sheep.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			sheep1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			sheep2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			sheep3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			mouse.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; 
			mouse1.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; 
			mouse2.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; 
			mouse3.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; 
			Destroy (chicken);
			Destroy (chicken1);
			Destroy (chicken2);
			Destroy (chicken3);

		}
	}
}
