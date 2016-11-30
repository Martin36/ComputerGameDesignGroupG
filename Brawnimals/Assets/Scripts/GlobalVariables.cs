using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {


	//the number of players "alive" on the game, be care if you modify that variable, I do in some games. Before every game should be reset it properly
	public static int numPlayers=9;

	//to know which controller pertain to each player 0 = wasd, 1 = Arrows, 2 = Gamepad, 3 = Mouse
	public static int controllerP1 = 0;    //Chicken player
	public static int controllerP2 = 1;    //Sheep player
	public static int controllerP3 = 2;    //Cow player
	public static int controllerP4 = 3;    //Mouse player

	//Global scores for players
	public static int globalScoreP1 = 0;
	public static int globalScoreP2 = 0;
	public static int globalScoreP3 = 0;
	public static int globalScoreP4 = 0;

	//Last game scores for players
	public static int lastGameScoreP1 = 0;
	public static int lastGameScoreP2 = 0;
	public static int lastGameScoreP3 = 0;
	public static int lastGameScoreP4 = 0;

	//Variable to control the change of spawning a new Microgame, should be reset after a microgame spawned
	public static int microGameChance = 0;






	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//we cannot use NON-static variables, this script will not be instantiated in any object, it just remains in the project folder and it works
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	/*
	[HideInInspector]
	public int[] controllers = new int[numPlayers];			//The index in the array corresponds to the controller with that number and the valuse is the player
	[HideInInspector]
	public int[] globalScoreArray = new int[numPlayers];     //Use ints as score?
	[HideInInspector]
	public int[] localScoreArray = new int[numPlayers];


	void Awake()
	{
		DontDestroyOnLoad(this);
		//Just for testing, the controllers should be assigned other where
		for(int i = 0; i < controllers.Length; i++)
		{
			controllers[i] = i;
		}
	}*/


}
