using UnityEngine;
using System.Collections;

public class BloodBalloonScript : MonoBehaviour {

	//The player that presses any button first when the balloon explodes is the winner


	public int maxTime = 10;   //The max time for the balloon to explode, in sec
	public int minTime = 3;   //The min time for the balloon to explode
	public int nrOfPlayers = 4;
	public float growingSpeed; //The speed in which the balloon grows (should be used to scale the image)

	private bool exploded;    //True when the balloon has exploded
	private float growthTime; //Will be the time until the balloon explosion for this game
	private int[] controllers;  //The index corresponds to the controller and the value is the player number
	private int[] place;      //The place which the players got, the index corresponds to the player number (i.e. index 0 means player 1)
	private int placeCounter; //Should be incremented each time a player finishes

	// Use this for initialization
	void Start () {
		//When the game starts the balloon will not have exploded yet (hopefully)
		exploded = false;
		//Give a random growth time for the balloon
		growthTime = Random.Range(minTime, maxTime);

		controllers = new int[nrOfPlayers];
		//Set the controllers
		controllers[GlobalVariables.controllerP1] = 0;
		controllers[GlobalVariables.controllerP2] = 1;
		controllers[GlobalVariables.controllerP3] = 2;
		controllers[GlobalVariables.controllerP4] = 3;

		place = new int[nrOfPlayers];
		placeCounter = 0;
	}

	// Update is called once per frame
	void Update () {
		if (exploded)
		{
			//If the balloon has exploded, then the player that presses first will win 
			if (Input.GetKeyDown(KeyCode.W))
			{

			}
			if (Input.GetKeyDown(KeyCode.A))
			{

			}
			if (Input.GetKeyDown(KeyCode.S))
			{

			}
			if (Input.GetKeyDown(KeyCode.D))
			{

			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{

			}
			if (Input.GetButtonDown("A"))
			{

			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{

			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{

			}
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{

			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{

			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{

			}
		}
	}
	/// <summary>
	/// Call this when the player has pressed a button
	/// </summary>
	/// <param name="playerID"></param>
	void ReachedGoal(int playerID)
	{

	}
}
