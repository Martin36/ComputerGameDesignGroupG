using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {


	//the number of players "alive" on the game, be care if you modify that variable, I do in some games. Before every game should be reset it properly
	public static int numPlayers=12;

	//numberOfLevel that have to be load
	public static int numScene=0;

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

	public static int gameID=10;//number of the scene

	//Variable to control the change of spawning a new Microgame, should be reset after a microgame spawned
	public static int microGameChance = 0;

	//Set this to true if the results scene should display the global score istead of the local one 
	public static bool globalScores = false;
}
