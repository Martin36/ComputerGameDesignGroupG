using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public int time;
	// Use this for initialization
	void Start () {
	
		Destroy (gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
