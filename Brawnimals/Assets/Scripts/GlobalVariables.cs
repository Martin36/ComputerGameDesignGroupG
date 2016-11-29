using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

	public static int numPlayers=4;

	public static int controller1 = 0;    //wasd
	public static int controller2 = 1;    //Arrows
	public static int controller3 = 2;    //Gamepad
	public static int controller4 = 3;    //Mouse 

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
	}
}
