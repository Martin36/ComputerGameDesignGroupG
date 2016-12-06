using UnityEngine;
using System.Collections;

public class ColliderItems : MonoBehaviour {

	public int itemID;//1 = chicken, 2 = sheep, 3 = cow, 4 = mouse

	private void OnTriggerEnter2D(Collider2D other){
		/*
		Debug.Log("chicken" + GlobalVariables.lastGameScoreP1);
		Debug.Log("sheep" + GlobalVariables.lastGameScoreP2);
		Debug.Log("cow" + GlobalVariables.lastGameScoreP3);
		Debug.Log("mouse" + GlobalVariables.lastGameScoreP4);
		*/
		switch (itemID)
		{

		case 1:
			if (other.gameObject.name == "Chicken") {
				GlobalVariables.lastGameScoreP1 += 10;
				Destroy (this.gameObject);

			}else 
			if (other.gameObject.name == "Sheep" || other.gameObject.name == "Mouse" || other.gameObject.name == "Cow") {
				
				GlobalVariables.lastGameScoreP2 += 5;
				GlobalVariables.lastGameScoreP3 += 5;
				GlobalVariables.lastGameScoreP4 += 5;
				Destroy (this.gameObject);
			}

			break;
		case 2:
			if (other.gameObject.name == "Sheep") {
				GlobalVariables.lastGameScoreP2 += 10;
				Destroy (this.gameObject);

			} else 
			if (other.gameObject.name == "Chicken" || other.gameObject.name == "Cow" || other.gameObject.name == "Mouse") {
				
				GlobalVariables.lastGameScoreP1 += 5;
				GlobalVariables.lastGameScoreP3 += 5;
				GlobalVariables.lastGameScoreP4 += 5;
				Destroy (this.gameObject);
			}

			break;
		case 3:
			if (other.gameObject.name == "Cow") {
				GlobalVariables.lastGameScoreP3 += 10;
				Destroy (this.gameObject);

			}else 
			if (other.gameObject.name == "Chicken" || other.gameObject.name == "Sheep" || other.gameObject.name == "Mouse") {
				
				GlobalVariables.lastGameScoreP1 += 5;
				GlobalVariables.lastGameScoreP2 += 5;
				GlobalVariables.lastGameScoreP4 += 5;
				Destroy (this.gameObject);
			}
			break;
		case 4:
			if (other.gameObject.name == "Mouse") {
				GlobalVariables.lastGameScoreP4 += 10;
				Destroy (this.gameObject);

			}else 
			if (other.gameObject.name == "Chicken" || other.gameObject.name == "Cow" || other.gameObject.name == "Sheep") {
				
				GlobalVariables.lastGameScoreP1 += 5;
				GlobalVariables.lastGameScoreP3 += 5;
				GlobalVariables.lastGameScoreP2 += 5;
				Destroy (this.gameObject);
			}
			break;
		}
	}
}
