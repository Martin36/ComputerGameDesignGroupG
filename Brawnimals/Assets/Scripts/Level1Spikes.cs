using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level1Spikes : MonoBehaviour {


	public float levelTimer;
	public Button exitButton;
	public Text textWin;




	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		StartCoroutine (levelDuration());
	}
	
	// Update is called once per frame
	void Update () {
	

		if (GlobalVariables.numPlayers == 0) {
			Time.timeScale = 0.0f;
			textWin.text = "Player 4 Wins!";
			textWin.gameObject.SetActive (true);
			exitButton.gameObject.SetActive (true);
		}
	}

	IEnumerator levelDuration(){

		yield return new WaitForSeconds (levelTimer);
		Time.timeScale = 0.0f;
		exitButton.gameObject.SetActive (true);
		textWin.text = "Player 4 Lost!";
		textWin.gameObject.SetActive (true);

	}

	public void exitLevel(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}
}
