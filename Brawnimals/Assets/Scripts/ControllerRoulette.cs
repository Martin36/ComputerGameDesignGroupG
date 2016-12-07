using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControllerRoulette : MonoBehaviour {


	public float torque;
	private Rigidbody2D rb;
	public TextMesh text1;
	public TextMesh text2;
	public TextMesh text3;
	public TextMesh text4;
	public TextMesh space;

	private bool firsTime=true;
	private bool stopped = false;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (firsTime) {
			if(Input.GetKeyDown(KeyCode.Space)){
				rb.AddTorque (-torque * Random.Range(5,15));
				firsTime = false;
			}
		
		}

		if (stopped) {
			space.text = "Press Space \n to continue"; 
			if(Input.GetKeyDown(KeyCode.Space)){
				SceneManager.LoadScene(GlobalVariables.numScene, LoadSceneMode.Single);
			}
		}
			
	}


	void FixedUpdate(){
		if (rb.IsSleeping() == true && firsTime == false && stopped == false) {
			Debug.Log ("stopped");
			stopped = true;
			putResults ();
		}
	}

	void putResults(){

		int randomAux = Random.Range (0, 4);
		Debug.Log (randomAux);
		switch (randomAux) {

		case 0:
				GlobalVariables.controllerP1 = 0;    //Chicken player
				GlobalVariables.controllerP2 = 1;    //Sheep player
				GlobalVariables.controllerP3 = 2;    //Cow player
				GlobalVariables.controllerP4 = 3;    //Mouse player

				text1.text = "Chicken";
				text2.text = "Sheep";
				text3.text = "Cow";
				text4.text = "Mouse";
			break;
		case 1:
				GlobalVariables.controllerP1 = 1;    //Chicken player
				GlobalVariables.controllerP2 = 2;    //Sheep player
				GlobalVariables.controllerP3 = 3;    //Cow player
				GlobalVariables.controllerP4 = 0;    //Mouse player

				text1.text = "Mouse";
				text2.text = "Chicken";
				text3.text = "Sheep";
				text4.text = "Cow";
			break;
		case 2:
				GlobalVariables.controllerP1 = 2;    //Chicken player
				GlobalVariables.controllerP2 = 3;    //Sheep player
				GlobalVariables.controllerP3 = 0;    //Cow player
				GlobalVariables.controllerP4 = 1;    //Mouse player

				text1.text = "Cow";
				text2.text = "Mouse";
				text3.text = "Chicken";
				text4.text = "Sheep";
			break;
		case 3:

				GlobalVariables.controllerP1 = 3;    //Chicken player
				GlobalVariables.controllerP2 = 0;    //Sheep player
				GlobalVariables.controllerP3 = 1;    //Cow player
				GlobalVariables.controllerP4 = 2;    //Mouse player

				text1.text = "Sheep";
				text2.text = "Cow";
				text3.text = "Mouse";
				text4.text = "Chicken";
			break;
		}

		/*
		//first case
		if(gameObject.transform.rotation.eulerAngles.z >= 0.0f && gameObject.transform.rotation.eulerAngles.z <= 90.0f){
			


		}

		//first case
		if(gameObject.transform.rotation.eulerAngles.z >= 90.0f && gameObject.transform.rotation.eulerAngles.z <= 180.0f){



		}

		//first case
		if(gameObject.transform.rotation.eulerAngles.z >= 180.0f && gameObject.transform.rotation.eulerAngles.z <= 270.0f){



		}

		//first case
		if(gameObject.transform.rotation.eulerAngles.z >= 270.0f && gameObject.transform.rotation.eulerAngles.z <= 350.0f){


		}*/
	}
	
}
