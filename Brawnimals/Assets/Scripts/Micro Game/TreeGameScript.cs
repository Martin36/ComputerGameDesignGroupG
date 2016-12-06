using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class TreeGameScript : MonoBehaviour {

	//TODO: Randomize the number of times the players has to hit the tree before it breaks
	//then the 3 different stages will have to depend on that number
	public struct IntVector2
	{
		public int x, y;

		public IntVector2(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}


	public Sprite[] treeSprites = new Sprite[4];
	public IntVector2 winScoreInterval = new IntVector2(10, 40);
	public bool randomizeButton = false;    //If true then randomize the button to press
	public bool randomizeWinScore = true;
	public int winScore = 20;          //The number of times to press the button before the tree breaks
	public int treeStage2 = 10;					//When the number of hits equals this number the image for the tree will change
	public int treeStage3 = 15;         //Same as the above but another image
	public int nrOfPlayers = 4;
	public int award = 5;               //How many points the winner gets (all the others gets 0)
	public int delay = 5;								//How many seconds before the next screen is auto loaded


	private List<Text> scoreDisplays;   //The text boxes to display the score each player has
	private List<string> names;					//The names of the players
	private Text buttonToPress;         //The text where is says which button to press
	private Image[] image;							//The current image to display for the player, will change depending on which how many hits the player has left
	private int[] controllers;					//The index corresponds to the controller and the value is the player number
	private int[] score;                //The score counter, the index corresponds to the player number (i.e. index 0 means player 1)
	private int winner;									//The number of the player that has won
	private string[] buttonNames;       //The names of the buttons the player has (should be changed later)
	private bool gameOver;
	private bool debug;
	

	void Awake()
	{
		//Set globals
		GlobalVariables.lastGameScoreP1 = 0;
		GlobalVariables.lastGameScoreP2 = 0;
		GlobalVariables.lastGameScoreP3 = 0;
		GlobalVariables.lastGameScoreP4 = 0;

		controllers = new int[nrOfPlayers];
		//Set the controllers
		controllers[GlobalVariables.controllerP1] = 0;
		controllers[GlobalVariables.controllerP2] = 1;
		controllers[GlobalVariables.controllerP3] = 2;
		controllers[GlobalVariables.controllerP4] = 3;


		buttonToPress = GameObject.FindGameObjectWithTag("ButtonPress").GetComponent<Text>();


		scoreDisplays = new List<Text>();
		names = new List<string>();

		foreach(Transform child in transform)
		{
			//Add each text to scoreDisplays
			if (child.tag.Equals("PlayerText"))
			{
				scoreDisplays.Add(child.GetComponent<Text>());
				names.Add(child.gameObject.name);
			}
		}
		score = new int[scoreDisplays.Count];

		image = new Image[nrOfPlayers];
		//Get all the players image components
		for (int i = 0; i < nrOfPlayers; image[i] = scoreDisplays[i++].transform.GetChild(0).GetComponent<Image>()) ;

		if (randomizeButton)
		{
			buttonNames = new string[] { "UP", "LEFT", "RIGHT" };
			buttonToPress = GameObject.FindGameObjectWithTag("ButtonPress").GetComponent<Text>();
			//Randomize the button to spam
			int buttonNr = Random.Range(0, buttonNames.Length);
			buttonToPress.text = string.Format("Press: {0} button", buttonNames[buttonNr]);
		}

		if (randomizeWinScore)
		{
			winScore = Random.Range(winScoreInterval.x, winScoreInterval.y);
			treeStage2 = (winScore / 2);		//Second stage is after half the cuts
			treeStage3 = (int)((3f / 4) * winScore);	//Third stage is after 3/4 of the cuts
		}
	}

	void Start () {
		gameOver = false;
		debug = true;
	}
	
	void Update () {
		if (!gameOver)
		{
			//Check for which buttons has been pressed and give players score accordingly
			if (Input.GetKeyDown(KeyCode.W))
			{
				//Check which player has these controllers and give him a point
				int playerID = controllers[0];
				GiveScore(playerID);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				int playerID = controllers[1];
				GiveScore(playerID);
			}
			if(Input.GetButtonDown("A") || (debug && Input.GetKeyDown(KeyCode.I)))
			{
				int playerID = controllers[2];
				GiveScore(playerID);
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				int playerID = controllers[3];
				GiveScore(playerID);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				SceneManager.LoadScene("ResultsLocal");
			}
		}
	}
	void GiveScore(int playerID)
	{
		score[playerID] += 1;
		//Update score text (need to add 1 to playerID because of the indexing)
		scoreDisplays[playerID].text = string.Format("{0} score: {1}", names[playerID], score[playerID]);
		if (score[playerID] == treeStage2)
		{
			//Update the image of the tree to stage 2
			image[playerID].sprite = treeSprites[1];
		}
		else if (score[playerID] == treeStage3)
		{
			//Update the image of the tree to stage 3
			image[playerID].sprite = treeSprites[2];
		}
		else if (score[playerID] >= winScore)
		{
			//This player has won
			//Set image to broken tree
			image[playerID].sprite = treeSprites[3];
			winner = playerID;
			GameFinished();
		}

	}

	void GameFinished()
	{
		//Announce the winner and go to the global/local score screen
		gameOver = true;
		buttonToPress.text = string.Format("{0} won! \nPress \"Enter\" to continue", names[winner]);
		//Give the winner score
		switch (winner)
		{
			case 0:
				GlobalVariables.lastGameScoreP1 = award;
				break;
			case 1:
				GlobalVariables.lastGameScoreP2 = award;
				break;
			case 2:
				GlobalVariables.lastGameScoreP3 = award;
				break;
			case 3:
				GlobalVariables.lastGameScoreP4 = award;
				break;
		}
		StartCoroutine(LoadLevelAfterDelay());
	}

	IEnumerator LoadLevelAfterDelay()
	{
		yield return new WaitForSeconds(delay);
		//Load the game roulette screen for starting a new game
		SceneManager.LoadScene("GameRoulette");
	}

}
