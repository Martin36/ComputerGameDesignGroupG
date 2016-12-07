using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelItems : MonoBehaviour
{

	public float levelTimer;
	public Button exitButton;
	public Text textWin;
	public GameObject chicken;
	public GameObject sheep;
	public GameObject cow;
	public GameObject mouse;

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
		GlobalVariables.globalScores = false;
		SceneManager.LoadScene(4, LoadSceneMode.Single);
	}

	void checkControllers(){


		//remember to substitute 3 -> 4, the third number it was just a test, we need to put the 4 for the gamepad controller

		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 0) {
			chicken.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			sheep.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			cow.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; //thats the gamepad in the other script
			Destroy (mouse);

		}

		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 1) {
			chicken.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			sheep.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			mouse.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1; 
			Destroy (cow);

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 2) {
			chicken.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4;
			cow.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			mouse.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2; 
			Destroy (sheep);

		}
		//means that the chicken use the awsd
		if (GlobalVariables.controllerP1 == 3) {
			cow.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 2;
			sheep.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 1;
			mouse.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().playerID = 4; 
			Destroy (chicken);

		}
	}
}
