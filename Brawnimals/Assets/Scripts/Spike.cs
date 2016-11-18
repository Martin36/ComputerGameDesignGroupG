using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {


	public bool isSpikeUp;
	public int speed;



	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {

			if (isSpikeUp) {
				transform.Translate (Vector3.up * Time.deltaTime * speed);

			} else {
				transform.Translate (Vector3.up * Time.deltaTime * speed);
			}
			
		}

}





