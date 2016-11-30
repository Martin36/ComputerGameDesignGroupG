using UnityEngine;
using System.Collections;

public class Explosion2D : MonoBehaviour {


	public float destroyTime = 0.75f;
	private CircleCollider2D cC2D;


	// Use this for initialization
	void Start () {
		cC2D = GetComponent<CircleCollider2D>();
		StartCoroutine(sizeIncrement());
		Destroy (this.gameObject,destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator sizeIncrement()
	{
		while (true) {
			yield return new WaitForSeconds (0.01f);
			cC2D.radius += 0.1f;
		}

	}


}
