using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class TreeGameScript : MonoBehaviour {

	//First randomize a button for the players to press (20 times to start with)
	//Second: Make listners for the player inputs

	public GameObject[] trees = new GameObject[4];          //The sprite images for the trees
	public bool randomizeButton = false;    //If true then randomize the button to press
	public int winScore = 20;          //The number of times to press the button before the tree breaks
	public int treeStage2 = 10;					//When the number of hits equals this number the image for the tree will change
	public int treeStage3 = 15;         //Same as the above but another image
	public int nrOfPlayers = 4;

	private List<Text> scoreDisplays;   //The text boxes to display the score each player has
	private Text buttonToPress;         //The text where is says which button to press
	private Image[] currentImage;       //The current image to display for the player, will change depending on which how many hits the player has left
	private int[] controllers;					//The index corresponds to the controller and the value is the player number
	private int[] score;                //The score counter, the index corresponds to the player number (i.e. index 0 means player 1)
	private int winner;									//The number of the player that has won
	private string[] buttonNames;       //The names of the buttons the player has (should be changed later)
	private bool gameOver;

	void Awake()
	{
		controllers = new int[nrOfPlayers];
		//Set the controllers
		controllers[GlobalVariables.controllerP1] = 0;
		controllers[GlobalVariables.controllerP2] = 1;
		controllers[GlobalVariables.controllerP3] = 2;
		controllers[GlobalVariables.controllerP4] = 3;


		buttonToPress = GameObject.FindGameObjectWithTag("ButtonPress").GetComponent<Text>();

		scoreDisplays = new List<Text>();
		foreach(Transform child in transform)
		{
			//Add each text to scoreDisplays
			if (child.tag.Equals("PlayerText"))
			{
				scoreDisplays.Add(child.GetComponent<Text>());
			}
		}
		score = new int[scoreDisplays.Count];
		if (randomizeButton)
		{
			buttonNames = new string[] { "UP", "LEFT", "RIGHT" };
			buttonToPress = GameObject.FindGameObjectWithTag("ButtonPress").GetComponent<Text>();
			//Randomize the button to spam
			int buttonNr = Random.Range(0, buttonNames.Length);
			buttonToPress.text = string.Format("Press: {0} button", buttonNames[buttonNr]);
		}

	}

	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver)
		{
			//Check for which buttons has been pressed and give players score accordingly
			if (Input.GetKeyDown(KeyCode.W))
			{
				//Check which player has these controllers and give him a point
				int playerID = controllers[0];
				score[playerID] += 1;
				//Update score text (need to add 1 to playerID because of the indexing)
				scoreDisplays[playerID].text = string.Format("Player {0} score: {1}", playerID + 1, score[playerID]);
				if (score[playerID] == treeStage2)
				{
					//TODO: Update the image of the tree to stage 2
				}
				else if (score[playerID] == treeStage3)
				{
					//TODO: Update the image of the tree to stage 3
				}
				else if (score[playerID] >= winScore)
				{
					//This player has won
					winner = playerID;
					GameFinished();
				}
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				int playerID = controllers[1];
				score[playerID] += 1;
				scoreDisplays[playerID].text = string.Format("Player {0} score: {1}", playerID + 1, score[playerID]);
				if (score[playerID] == treeStage2)
				{
					//TODO: Update the image of the tree to stage 2
				}
				else if (score[playerID] == treeStage3)
				{
					//TODO: Update the image of the tree to stage 3
				}
				else if (score[playerID] >= winScore)
				{
					//This player has won
					winner = playerID;
					GameFinished();
				}
			}
			//TODO: Insert check for the gamepad
			if(Input.GetButtonDown("A"))
			{
				int playerID = controllers[2];
				score[playerID] += 1;
				scoreDisplays[playerID].text = string.Format("Player {0} score: {1}", playerID + 1, score[playerID]);
				if (score[playerID] == treeStage2)
				{
					//TODO: Update the image of the tree to stage 2
				}
				else if (score[playerID] == treeStage3)
				{
					//TODO: Update the image of the tree to stage 3
				}
				else if (score[playerID] >= winScore)
				{
					//This player has won
					winner = playerID;
					GameFinished();
				}
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				int playerID = controllers[3];
				score[playerID] += 1;
				scoreDisplays[playerID].text = string.Format("Player {0} score: {1}", playerID + 1, score[playerID]);
				if (score[playerID] == treeStage2)
				{
					//TODO: Update the image of the tree to stage 2
				}
				else if (score[playerID] == treeStage3)
				{
					//TODO: Update the image of the tree to stage 3
				}
				else if (score[playerID] >= winScore)
				{
					//This player has won
					winner = playerID;
					GameFinished();
				}
			}
		}
	}

	void GameFinished()
	{
		//Announce the winner and go to the global/local score screen
		gameOver = true;
		buttonToPress.text = string.Format("Player {0} won!", winner + 1);
		Time.timeScale = 0;
	}
}
 