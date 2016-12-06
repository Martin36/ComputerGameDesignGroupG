using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	public bool showCountdown = true;

	private string countdown;

	void Start () {
		StartCoroutine(GetReady());
	}

	IEnumerator GetReady()
	{
		showCountdown = true;

		countdown = "3";
		yield return new WaitForSeconds(1.5f);

		countdown = "2";
		yield return new WaitForSeconds(1.5f);

		countdown = "1";
		yield return new WaitForSeconds(1.5f);

		countdown = "GO";
		yield return new WaitForSeconds(1.5f);

		showCountdown = false;
		countdown = "";

	}

	void OnGUI()
	{
		if (showCountdown)
		{
			GUI.color = Color.red;
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "GET READY");

			// display countdown    
			GUI.color = Color.white;
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), countdown);
		}

	}
}
