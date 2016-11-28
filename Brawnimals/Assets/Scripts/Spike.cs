using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{

	public bool isSpikeUp;
	public int speed;

	void Start()
	{
		Destroy(this.gameObject, 5);
	}

	void Update()
	{

		if (isSpikeUp)
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);

		}
		else
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		}

	}

}





