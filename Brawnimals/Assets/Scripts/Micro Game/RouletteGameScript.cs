using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
/// <summary>
/// The player has to shoot when the bullet is pointing towards the player
/// Otherwise the character will explode
/// The player gets a point each time the character gets hit (animation?)
/// If the player misses he is out of the game
/// </summary>
public class RouletteGameScript : MonoBehaviour {

	public GameObject explosion;
	public Vector2 shootingRange;			//The interval in which the bullet hits the player (angle 100 is 0)
	public int nrOfPlayers = 4;
	public float rotationSpeed = 10;    //The rotation speed of the gun (degrees/sec)
	public float rotationAcc = 5;     //The acceleration of the wheel
	public bool useSound = true;			//Set this true if sound should be enabled

	private GameObject[] players;
	private GameObject[] guns;    //The rotating roulette weels
	private Text[] scoreDisplays; //Text objects to display the score
	private Text infoText;
	private int[] scores;     //Scores for each player
	private int[] controllers;  //The index corresponds to the controller and the value is the player number
	private int playersLeft;
	private bool gameOver;
	private bool debug;
	private bool startFinished;


	void Start () {
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

		guns = new GameObject[nrOfPlayers];
		scoreDisplays = new Text[nrOfPlayers];
		//Get the gun component and give it a random rotation
		for (int i = 0; i < nrOfPlayers; i++)
		{
			guns[i] = players[i].transform.GetChild(0).gameObject;
			guns[i].transform.Rotate(0, 0, Random.Range(0f, 360f));
		}
		//Get the score display for each player
		for (int i = 0; i < nrOfPlayers; i++)
		{
			var child = players[i].GetComponentInChildren<Text>();
			scoreDisplays[i] = child;
		}
		infoText = GetComponentInChildren<Text>();
		scores = new int[nrOfPlayers];

		controllers = new int[nrOfPlayers];
		//Set the controllers
		controllers[GlobalVariables.controllerP1] = 0;
		controllers[GlobalVariables.controllerP2] = 1;
		controllers[GlobalVariables.controllerP3] = 2;
		controllers[GlobalVariables.controllerP4] = 3;

		playersLeft = nrOfPlayers;
		gameOver = false;
		debug = true;
		startFinished = true;
	}

	void Update () {
		if (!gameOver && startFinished)
		{
			//Rotate the weels
			for(int i = 0; i < nrOfPlayers; i++)
			{
				//Check if current player still alive
				if(players[i] != null)
				{
					guns[i].transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
				}
			}
			//Chech for shooting
			int playerID = 5;			//Use 5 as default if nobody pressed
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
			{
				playerID = controllers[0];
			}
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				playerID = controllers[1];
			}
			if (Input.GetButtonDown("A"))
			{
				playerID = controllers[2];
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
			{
				playerID = controllers[3];
			}
			if (debug && Input.GetKeyDown(KeyCode.I))
			{
				playerID = controllers[2];
			}
			
			if(playerID != 5 && players[playerID])
			{
				//If an alive player shot, then shoot
				Shoot(playerID);
			}
			rotationSpeed += rotationAcc * Time.deltaTime;
			if(playersLeft <= 0)
			{
				//The game is done
				GameOver();
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
	/// <summary>
	/// Call this when player has shot
	/// </summary>
	/// <param name="playerID"></param>
	void Shoot(int playerID)
	{
		GameObject gun = guns[playerID];
		//Check if player still alive
		if (gun)
		{
			//Check if the shot was fired in the right interval
			if (gun.transform.rotation.eulerAngles.z <= shootingRange.y && gun.transform.rotation.eulerAngles.z >= shootingRange.x)
			{
				//TODO: Add some animation for the shooting
				scoreDisplays[playerID].text = string.Format("Score: {0}", ++scores[playerID]);
			}
			else
			{
				//If the player misses he explodes
				Explode(playerID);
			}
		}
	}

	void Explode(int playerID)
	{
		//TODO: Add some animation for the player exploding
		if (players[playerID] != null)
		{
			Instantiate(explosion, players[playerID].transform.position, Quaternion.Euler(90, 0, 0));
			scoreDisplays[playerID].transform.SetParent(transform); //Remove the player as parent to keep the score display
			Destroy(players[playerID]);
			playersLeft -= 1;
		}
	}

	void GameOver()
	{
		//Time.timeScale = 0f;
		infoText.text = string.Format("Chicken: {0} \nSheep: {1} \nCow: {2} \nMouse: {3} \nPress \"enter\" to continue", scores.Select(x => x.ToString()).ToArray());
		GlobalVariables.lastGameScoreP1 = scores[0];
		GlobalVariables.lastGameScoreP2 = scores[1];
		GlobalVariables.lastGameScoreP3 = scores[2];
		GlobalVariables.lastGameScoreP4 = scores[3];
		if (!debug)
		{
			GlobalVariables.lastGameScoreP1 = 75;
			GlobalVariables.lastGameScoreP2 = 50;
			GlobalVariables.lastGameScoreP3 = 20;
			GlobalVariables.lastGameScoreP4 = 88;
		}

		gameOver = true;

	}
}
