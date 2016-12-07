using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class ResultsScript : MonoBehaviour {

	public int nrOfPlayers = 4;
	public int maxLocalScore = 100;
	public int maxGlobalScore = 500;
	public int fillTime = 5;
	public int delay = 10;			//The time before next scene is loaded
	public bool globalScore = false;		//Set this true if the global score is needed
	

	private List<Text> scoreDisplays;   //The text boxes to display the score each player has
	private Image[] blood;
	private int[] scores;
	private float[] fillAmount;

	void Awake()
	{
		scoreDisplays = new List<Text>();
		foreach (Transform child in transform)
		{
			//Add each text to scoreDisplays
			if (child.tag.Equals("PlayerText"))
			{
				scoreDisplays.Add(child.GetComponent<Text>());
			}
		}
		globalScore = GlobalVariables.globalScores;

		scores = new int[nrOfPlayers];
		//Set the scores to the correct ones
		if (globalScore)
		{
			scores[0] = GlobalVariables.globalScoreP1;
			scores[1] = GlobalVariables.globalScoreP2;
			scores[2] = GlobalVariables.globalScoreP3;
			scores[3] = GlobalVariables.globalScoreP4;
		}
		else
		{
			scores[0] = GlobalVariables.lastGameScoreP1;
			scores[1] = GlobalVariables.lastGameScoreP2;
			scores[2] = GlobalVariables.lastGameScoreP3;
			scores[3] = GlobalVariables.lastGameScoreP4;
		}

		fillAmount = new float[nrOfPlayers];
		//Calculate the amount which is to be filled
		if(globalScore)
			for (int i = 0; i < nrOfPlayers; fillAmount[i] = (float)scores[i++] / maxGlobalScore) ;
		else
			for (int i = 0; i < nrOfPlayers; fillAmount[i] = (float)scores[i++] / maxLocalScore) ;


		blood = new Image[nrOfPlayers];
		//Get the "blood filling" images
		for (int i = 0; i < nrOfPlayers; blood[i] = scoreDisplays[i++].transform.GetChild(1).GetComponent<Image>()) ;

	}

	void Start () {

		//Set the score text
		for(int i = 0; i < nrOfPlayers; i++)
		{
			string oldText = scoreDisplays[i].text;
			string newText = oldText + ' ' + scores[i];
			scoreDisplays[i].text = newText;
		}

		//Set timer for changing screen
		StartCoroutine(LoadLevelAfterDelay());
	}
	
	void Update () {
		//Increase the amount of blood each frame until it reaches maximum
		for (int i = 0; i < nrOfPlayers; blood[i].fillAmount = Mathf.Min(1f/fillTime * Time.timeSinceLevelLoad, fillAmount[i++]));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			StoreData();
			//Load the game roulette screen for starting a new game
			SceneManager.LoadScene("GameRoulette");
		}
	}

	IEnumerator LoadLevelAfterDelay()
	{
		yield return new WaitForSeconds(delay);
		StoreData();
		//Load the game roulette screen for starting a new game
		SceneManager.LoadScene("GameRoulette");
	}

	void StoreData()
	{
		//Add the last game scores to the globals
		GlobalVariables.globalScoreP1 += GlobalVariables.lastGameScoreP1;
		GlobalVariables.globalScoreP2 += GlobalVariables.lastGameScoreP2;
		GlobalVariables.globalScoreP3 += GlobalVariables.lastGameScoreP3;
		GlobalVariables.globalScoreP4 += GlobalVariables.lastGameScoreP4;
		//Reset the last game scores
		GlobalVariables.lastGameScoreP1 = 0;
		GlobalVariables.lastGameScoreP2 = 0;
		GlobalVariables.lastGameScoreP3 = 0;
		GlobalVariables.lastGameScoreP4 = 0;
	}
}
