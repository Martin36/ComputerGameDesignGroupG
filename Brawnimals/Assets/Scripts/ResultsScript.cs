using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ResultsScript : MonoBehaviour {

	public int nrOfPlayers = 4;
	public int maxScore = 100;
	public int fillTime = 5;
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
		for (int i = 0; i < nrOfPlayers; fillAmount[i] = (float)scores[i++] / maxScore) ;

		blood = new Image[nrOfPlayers];
		//Get the "blood filling" images
		for (int i = 0; i < nrOfPlayers; blood[i] = scoreDisplays[i++].transform.GetChild(1).GetComponent<Image>()) ;

	}

	void Start () {
		//Set the amount of blood to 0
		//for (int i = 0; i < nrOfPlayers; blood[i++].fillAmount = 0f) ; 

		//Set the score text
		for(int i = 0; i < nrOfPlayers; i++)
		{
			string oldText = scoreDisplays[i].text;
			string newText = oldText + ' ' + scores[i];
			scoreDisplays[i].text = newText;
		}
	}
	
	void Update () {
		//Increase the amount of blood each frame until it reaches maximum
		for (int i = 0; i < nrOfPlayers; blood[i].fillAmount = Mathf.Min(1f/fillTime * Time.timeSinceLevelLoad, fillAmount[i++]));

		if (Input.GetKeyDown(KeyCode.Space))
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
			//Load the game roulette screen for starting a new game
			SceneManager.LoadScene("GameRoulette");
		}
	}
}
