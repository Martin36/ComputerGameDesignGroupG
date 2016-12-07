using UnityEngine;
using System.Collections;

public class TimeScaleReset : MonoBehaviour {

	void Awake(){
		Time.timeScale = 1.0f;
		Physics2D.gravity = new Vector2 (0.0f,  -9.81f);

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
