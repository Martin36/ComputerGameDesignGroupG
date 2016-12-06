using UnityEngine;
using System.Collections;

public class CharacterColliders : MonoBehaviour
{

	public int playerID;//1 = chicken, 2 = sheep, 3 = cow, 4 = mouse
	public GameObject blood1;
	public GameObject blood2;
	public GameObject blood3;
	public GameObject bloodExplosion;
	private int scoreCounter=0;


	void Start(){
		StartCoroutine (characterDuration());
	}
		
	IEnumerator characterDuration()
	{
		while (true) {
			yield return new WaitForSeconds(1);
			scoreCounter++;
		}

	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Spike")
		{

			int random = Random.Range(1, 4);

			switch (random)
			{

				case 1:
					Instantiate(blood1, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
					Instantiate(bloodExplosion, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
					break;
				case 2:
					Instantiate(blood2, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
					Instantiate(bloodExplosion, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
					break;
				case 3:
					Instantiate(blood3, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
					Instantiate(bloodExplosion, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
					break;
			}
			GlobalVariables.numPlayers -= 1;

			switch (playerID) {

			case 1:
				GlobalVariables.lastGameScoreP1 += 10 * scoreCounter;
				break;
			case 2:
				GlobalVariables.lastGameScoreP2 += 10 * scoreCounter;
				break;
			case 3:
				GlobalVariables.lastGameScoreP3 += 10 * scoreCounter;
				break;
			case 4:
				GlobalVariables.lastGameScoreP4 += 10 * scoreCounter;
			
				break;
			}
			//Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}
}
