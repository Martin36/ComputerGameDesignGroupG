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
	public int treeStage3 = 15;					//Same as the above but another image

	private List<Text> scoreDisplays;   //The text boxes to display the score each player has
	private Text buttonToPress;         //The text where is says which button to press
	private Image[] currentImage;       //The current image to display for the player, will change depending on which how many hits the player has left
	private GlobalVariables gv;         //Reference to the script holding the global variables
	private int[] controllers;					//Reference to the controllers, as given by the global variables
	private int[] score;                //The score counter, the index corresponds to the player number (i.e. index 0 means player 1)
	private int winner;									//The number of the player that has won
	private string[] buttonNames;				//The names of the buttons the player has (should be changed later)
	

	void Awake()
	{
		gv = GameObject.Find("GlobalVariables").GetComponent<GlobalVariables>();
		controllers = gv.controllers;

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
	
	}
	
	// Update is called once per frame
	void Update () {
		//Check for which buttons has been pressed and give players score accordingly
		if (Input.GetKeyDown(KeyCode.W))
		{
			//Check which player has these controllers and give him a point
			int playerID = controllers[GlobalVariables.controller1];
			score[playerID] += 1;
			//Update score text (need to add 1 to playerID because of the indexing)
			scoreDisplays[playerID].text = string.Format("Player {0} score: {1}", playerID+1, score[playerID]);
			if(score[playerID] == treeStage2)
			{
				//TODO: Update the image of the tree to stage 2
			}
			else if(score[playerID] == treeStage3)
			{
				//TODO: Update the image of the tree to stage 3
			}
			else if(score[playerID] >= winScore)
			{
				//This player has won
			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			int playerID = controllers[GlobalVariables.controller2];
			score[playerID] += 1;
			scoreDisplays[playerID].text = string.Format("Player {0} score: {1}", playerID+1, score[playerID]);
		}
		//TODO: Insert check for the gamepad
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			int playerID = controllers[GlobalVariables.controller4];
			score[playerID] += 1;
			scoreDisplays[playerID].text = string.Format("Player {0} score: {1}", playerID+1, score[playerID]);
		}

	}

	void GameFinished()
	{
		//Announce the winner and go to the global/local score screen
	}
}
 