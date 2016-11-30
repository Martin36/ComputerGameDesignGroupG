using UnityEngine;
using System.Collections;

public class ChangeGravity : MonoBehaviour {

	public float amountX = 2.0f;
	public float amountY = 2.0f;
	private float gravityX=0;
	private float gravityY=0;
	// Use this for initialization
	void Start () {
		gravityY = Physics2D.gravity.y;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButton(0)) {
			gravityX -= amountX;

		}

		if (Input.GetMouseButton(1)) {
			gravityX += amountX;

		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			gravityY -= amountY;
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			gravityY += amountY;
		}


		Physics2D.gravity = new Vector2 (gravityX, gravityY);
	}
}
