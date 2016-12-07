using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class BloodBalloonScript : MonoBehaviour {

	//The player that presses any button first when the balloon explodes is the winner

	public GameObject explosion;
	public AudioClip explosionSound;
	public AudioClip winningSound;
	public int maxTime = 10;   //The max time for the balloon to explode, in sec
	public int minTime = 3;   //The min time for the balloon to explode
	public int nrOfPlayers = 4;
	public int scoreInterval = 5;			//The range between the scores, so for 5 means (5, 10, 15, 20) points
	public float growingSpeed = 2; //The speed in which the balloon grows (should be used to scale the image)
	public bool useSound = true;

	private GameObject balloon;
	private GameObject[] players;
	private Text infoText;
	private AudioSource source;
	private bool exploded;    //True when the balloon has exploded
	private bool debug;       //True if trying out the code (without the gamepad)
	private bool gameOver;
	private float growthTime; //Will be the time until the balloon explosion for this game
	private int[] controllers;  //The index corresponds to the controller and the value is the player number
	private int placeCounter; //Should be incremented each time a player finishes, a 5 means the player failed
	private int playersLeft;
	private object[] place;      //The place which the players got, the index corresponds to the player number (i.e. index 0 means player 1)

	void Awake () {

		balloon = GameObject.FindGameObjectWithTag("Balloon");

		players = new GameObject[nrOfPlayers];
		//Get all the player objects
		int playerCounter = 0;
		foreach (Transform child in transform)
		{
			if (child.tag.Equals("Player"))
			{
				players[playerCounter++] = child.gameObject;
			}
		}

		infoText = GetComponentInChildren<Text>();
		//When the game starts the balloon will not have exploded yet (hopefully)
		exploded = false;
		//For testing the code without gamepad
		debug = true;

		gameOver = false;
		//Give a random growth time for the balloon
		growthTime = Random.Range(minTime, maxTime);

		controllers = new int[nrOfPlayers];
		//Set the controllers
		controllers[GlobalVariables.controllerP1] = 0;
		controllers[GlobalVariables.controllerP2] = 1;
		controllers[GlobalVariables.controllerP3] = 2;
		controllers[GlobalVariables.controllerP4] = 3;

		place = new object[nrOfPlayers];
		placeCounter = 0;
		playersLeft = nrOfPlayers;
		//Scale the explosion
		explosion.transform.localScale = new Vector3(40, 40, 40);

		source = GetComponent<AudioSource>();
	}

	void Update () {
		if (!gameOver)
		{
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
				//Play the sound 
				if (useSound)
				{
					source.PlayOneShot(explosionSound);
				}
				//Then the balloon explodes
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
		else
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				GlobalVariables.globalScores = false;
				SceneManager.LoadScene("ResultsLocal");
			}
		}
	}
	/// <summary>
	/// Call this when the player has pressed a button
	/// </summary>
	/// <param name="playerID"></param>
	void ReachedGoal(int playerID)
	{
		if(players[playerID] != null)
		{
			//Give the player the correct position
			place[playerID] = ++placeCounter;
			playersLeft -= 1;
			//Play winning sound
			if (useSound)
			{
				source.PlayOneShot(winningSound);
			}
			//Destroy the player
			Destroy(players[playerID]);
		}
	}
	/// <summary>
	/// Function for making the player explode if any button is pressed before the balloon explodes
	/// </summary>
	/// <param name="playerID"></param>
	void Explode(int playerID)
	{
		if(players[playerID] != null)
		{
			if (useSound)
			{
				source.PlayOneShot(explosionSound);
			}
			Instantiate(explosion, players[playerID].transform.position, Quaternion.Euler(90, 0, 0));
			Destroy(players[playerID]);
			place[playerID] = "Disqualified";
			playersLeft -= 1;
		}
	}
	/// <summary>
	/// Call this when the game is done
	/// </summary>
	void GameOver()
	{
		gameOver = true;
		if(balloon != null)
		{
			Destroy(balloon);
		}

		//Create a score list
		infoText.text = string.Format("Chicken: {0} \nSheep: {1} \nCow: {2} \nMouse: {3} \nPress \"Enter\" to continue",	place.Select(x => x.ToString()).ToArray());

		//Set the last game scores
		for(int i = 0; i < nrOfPlayers; i++)
		{
			int score;
			if (place[i].Equals("Disqualified"))
				score = 0;
			else
			{
				//Give the player who clicked first the highest score 
				score = scoreInterval * (5 - System.Convert.ToInt32(place[i]));
			}
			switch (i)
			{
				case 0:
					GlobalVariables.lastGameScoreP1 = score;
					break;
				case 1:
					GlobalVariables.lastGameScoreP2 = score;
					break;
				case 2:
					GlobalVariables.lastGameScoreP3 = score;
					break;
				case 3:
					GlobalVariables.lastGameScoreP4 = score;
					break;
			}

		}
	}
}
