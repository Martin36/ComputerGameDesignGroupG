using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SpamTapGameScript : MonoBehaviour {

	//First randomize a button for the players to press (20 times to start with)
	//Second: Make listners for the player inputs

	private List<Text> scoreDisplays;   //The text boxes to display the score each player has
	private Text buttonToPress;					//The text where is says which button to press
	private int[] pushes;								//The score counter
	private string[] buttonNames;				//The names of the buttons the player has (should be changed later)

	void Awake()
	{
		scoreDisplays = new List<Text>();
		foreach(Transform child in transform)
		{
			//Add each text to scoreDisplays
			if (child.tag.Equals("PlayerText"))
			{
				scoreDisplays.Add(child.GetComponent<Text>());
			}
		}
		pushes = new int[scoreDisplays.Count];
		buttonNames = new string[] { "UP", "LEFT", "RIGHT" };

		buttonToPress = GameObject.FindGameObjectWithTag("ButtonPress").GetComponent<Text>();
		//Randomize the button to spam
		int buttonNr = Random.Range(0, buttonNames.Length);
		buttonToPress.text = string.Format("Press: {0} button", buttonNames[buttonNr]);

		//for()
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
