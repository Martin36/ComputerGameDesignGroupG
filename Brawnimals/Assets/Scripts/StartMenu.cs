using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public void  loadLevelGravity(){
		GlobalVariables.numScene = 10;
		GlobalVariables.numPlayers = 3;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}

	public void  loadLevelSpikes(){
		GlobalVariables.numScene = 6;
		GlobalVariables.numPlayers = 3;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}

	public void  loadLevelItems(){
		GlobalVariables.numScene = 9;
		GlobalVariables.numPlayers = 3;
		SceneManager.LoadScene (3, LoadSceneMode.Single);

	}

	public void  loadLevelGravityHardcore(){
		GlobalVariables.numScene = 14;
		GlobalVariables.numPlayers = 3;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}

	public void  loadLevelSpikesHardcore(){
		GlobalVariables.numScene = 7;
		GlobalVariables.numPlayers = 12;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}

	public void  loadLevelItemsHardcore(){
		GlobalVariables.numScene = 13;
		GlobalVariables.numPlayers = 3;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}


	public void globalScores(){
		GlobalVariables.globalScores = true; 
		SceneManager.LoadScene (4, LoadSceneMode.Single);

	}

	public void  russianRoulette(){
		GlobalVariables.numScene = 12;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}

	public void  treeChop(){
		GlobalVariables.numScene = 11;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}

	public void  bloodBalloon(){
		GlobalVariables.numScene = 15;
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}


	public void  exitGame(){
		Application.Quit ();
	}

	public void goToStarMenu(){
		GlobalVariables.globalScoreP1 = 0;
		GlobalVariables.globalScoreP2 = 0;
		GlobalVariables.globalScoreP3 = 0;
		GlobalVariables.globalScoreP4 = 0;
		GlobalVariables.lastGameScoreP1 = 0;
		GlobalVariables.lastGameScoreP2 = 0;
		GlobalVariables.lastGameScoreP3 = 0;
		GlobalVariables.lastGameScoreP4 = 0;


		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	public void  loadLevelSelect(){
		SceneManager.LoadScene (2, LoadSceneMode.Single);

	}
}
