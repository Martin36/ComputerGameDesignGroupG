using UnityEngine;
using System.Collections;

public class ExplosionGenerator : MonoBehaviour {


	public GameObject explosion;
	public GameObject explosionParticles;
	public float shootTime = 1.0f;
	private bool canShoot;

	void Start()
	{
		canShoot = true;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && canShoot == true)
		{

			Instantiate(explosion, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y
				, Camera.main.ScreenToWorldPoint(Input.mousePosition).z), Quaternion.Euler(0, 0, 0));
			Instantiate(explosionParticles, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y
				, Camera.main.ScreenToWorldPoint(Input.mousePosition).z), Quaternion.Euler(0, 0, 0));
			canShoot = false;
			StartCoroutine(coolDown());

		}

		if (Input.GetMouseButtonDown(1) && canShoot == true)
		{

			Instantiate(explosion, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y
				, Camera.main.ScreenToWorldPoint(Input.mousePosition).z), Quaternion.Euler(0, 0, 0));
			Instantiate(explosionParticles, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y
				, Camera.main.ScreenToWorldPoint(Input.mousePosition).z), Quaternion.Euler(0, 0, 0));
			canShoot = false;
			StartCoroutine(coolDown());

		}
	}

	IEnumerator coolDown()
	{

		yield return new WaitForSeconds(shootTime);
		canShoot = true;

	}
}
