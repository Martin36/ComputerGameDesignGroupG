using UnityEngine;
using UnityEngine.UI;
//using System;
using System.Collections;
using System.Linq;

public class BloodBalloonScript : MonoBehaviour {

	//The player that presses any button first when the balloon explodes is the winner

	public GameObject explosion;
	public int maxTime = 10;   //The max time for the balloon to explode, in sec
	public int minTime = 3;   //The min time for the balloon to explode
	public int nrOfPlayers = 4;
	public float growingSpeed = 2; //The speed in which the balloon grows (should be used to scale the image)

	private GameObject balloon;
	private Text infoText;
	private bool exploded;    //True when the balloon has exploded
	private bool debug;				//True if trying out the code (without the gamepad)
	private float growthTime; //Will be the time until the balloon explosion for this game
	private int[] controllers;  //The index corresponds to the controller and the value is the player number
	private int[] place;      //The place which the players got, the index corresponds to the player number (i.e. index 0 means player 1)
	private int placeCounter; //Should be incremented each time a player finishes, a 5 means the player failed
	private int playersLeft;

	// Use this for initialization
	void Start () {

		balloon = GameObject.FindGameObjectWithTag("Balloon");
		infoText = GetComponentInChildren<Text>();
		//When the game starts the balloon will not have exploded yet (hopefully)
		exploded = false;
		//For testing the code without gamepad
		debug = true;
		//Give a random growth time for the balloon
		growthTime = Random.Range(minTime, maxTime);
//		growthTime = 2;

		controllers = new int[nrOfPlayers];
		//Set the controllers
		controllers[GlobalVariables.controllerP1] = 0;
		controllers[GlobalVariables.controllerP2] = 1;
		controllers[GlobalVariables.controllerP3] = 2;
		controllers[GlobalVariables.controllerP4] = 3;

		place = new int[nrOfPlayers];
		placeCounter = 0;
		playersLeft = nrOfPlayers;
	}

	// Update is called once per frame
	void Update () {
		//Remove the deltaTime component each time
		growthTime -= Time.deltaTime;

		if (!exploded)
		{
			//Increase the size of the balloon
			Vector2 currentSize = balloon.GetComponent<Image>().rectTransform.sizeDelta;
			Vector2 newSize = new Vector2(currentSize.x + growingSpeed * Time.deltaTime, currentSize.y + growingSpeed * Time.deltaTime);
			balloon.GetComponent<Image>().rectTransform.sizeDelta = newSize;
		}

		//Do the check for when the balloon should explode
		if (growthTime <= 0 && !exploded)
		{
			//Then the balloon explodes
			//TODO: Add code for making the balloon explode
			explosion.transform.localScale = new Vector3(40, 40, 40);
			Destroy(balloon);
			Instantiate(explosion, new Vector3(0, 0, -2), Quaternion.Euler(90, 0, 0));
			exploded = true;
		}
		
		//The game is finished when all the players are finished
		if (playersLeft <= 0)
		{
			GameOver();
		}

		if (exploded)
		{
			//If the balloon has exploded, then the player that presses first will win 
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
			{
				int playerID = controllers[0];
				ReachedGoal(playerID);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				int playerID = controllers[1];
				ReachedGoal(playerID);
			}
			if (Input.GetButtonDown("A"))
			{
				int playerID = controllers[2];
				ReachedGoal(playerID);
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
			{
				int playerID = controllers[3];
				ReachedGoal(playerID);
			}
			if (debug && Input.GetKeyDown(KeyCode.I))
			{
				int playerID = controllers[2];
				ReachedGoal(playerID);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
			{
				int playerID = controllers[0];
				Explode(playerID);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				int playerID = controllers[1];
				Explode(playerID);
			}
			if (Input.GetButtonDown("A"))
			{
				int playerID = controllers[2];
				Explode(playerID);
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
			{
				int playerID = controllers[3];
				Explode(playerID);
			}
			if (debug && Input.GetKeyDown(KeyCode.I))
			{
				int playerID = controllers[2];
				Explode(playerID);
			}
		}

	}
	/// <summary>
	/// Call this when the player has pressed a button
	/// </summary>
	/// <param name="playerID"></param>
	void ReachedGoal(int playerID)
	{
		//Give the player the correct position
		place[playerID] = ++placeCounter;
		playersLeft -= 1;
	}
	/// <summary>
	/// Function for making the player explode if any button is pressed before the balloon explodes
	/// </summary>
	/// <param name="playerID"></param>
	void Explode(int playerID)
	{
		//TODO: Add some animation for the player exploding
		place[playerID] = 5;
		playersLeft -= 1;
	}
	/// <summary>
	/// Call this when the game is done
	/// </summary>
	void GameOver()
	{
		//Create a score list
		infoText.text = string.Format("Player1: {0} \nPlayer2: {1} \nPlayer3: {2} \nPlayer4: {3}",	place.Select(x => x.ToString()).ToArray());
		Time.timeScale = 0f;
	}
}
