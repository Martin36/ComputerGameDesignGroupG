using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public void  loadLevel1(){
		SceneManager.LoadScene (1, LoadSceneMode.Single);
		GlobalVariables.numPlayers = 3;
	}

	public void  loadLevel2(){
		SceneManager.LoadScene (2, LoadSceneMode.Single);
		GlobalVariables.numPlayers = 3;
	}

	public void  loadLevel3(){
		SceneManager.LoadScene (3, LoadSceneMode.Single);
		GlobalVariables.numPlayers = 12;
	}

	public void  exitGame(){
		Application.Quit ();
	}
}
