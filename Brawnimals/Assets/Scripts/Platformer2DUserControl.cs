using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof(PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;
		private bool m_Jump;
		public int playerID;


		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
		}


		private void Update()
		{
			if (!m_Jump)
			{
				// Read the jump input in Update so button presses aren't missed.
				//m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

				switch (playerID)
				{

					case 1:
						if (Input.GetKeyDown(KeyCode.W))
						{
							m_Jump = true;
						}
						break;
					case 2:
						if (Input.GetKeyDown(KeyCode.UpArrow))
						{
							m_Jump = true;
						}
						break;
					case 3:
						if (Input.GetKeyDown(KeyCode.I))
						{
							m_Jump = true;
						}
						break;
					case 4:

					m_Jump = Input.GetButtonDown ("A");

					break;
				}


			}
		}


		private void FixedUpdate()
		{
			// Read the inputs.
			//bool crouch = Input.GetKey(KeyCode.LeftControl);
			bool crouch = false;
			float h = 0;

			//get crouch, not needed for now
			/*			if (Input.GetKey (KeyCode.S)) {
							crouch = true;
						}

			*/
			//float h = CrossPlatformInputManager.GetAxis("Horizontal");

			switch (playerID)
			{

				case 1:
					if (Input.GetKey(KeyCode.A))
					{
						h = -1;
					}
					if (Input.GetKey(KeyCode.D))
					{
						h = 1;
					}
					break;
				case 2:
					if (Input.GetKey(KeyCode.LeftArrow))
					{
						h = -1;
					}
					if (Input.GetKey(KeyCode.RightArrow))
					{
						h = 1;
					}
					break;
				case 3:
					if (Input.GetKey(KeyCode.J))
					{
						h = -1;
					}
					if (Input.GetKey(KeyCode.L))
					{
						h = 1;
					}
					break;
				case 4:

					//h = Input.GetAxis("JoystickX");
					h = Input.GetAxis("JoystickX6th");

				break;
			}



			// Pass all parameters to the character control script.
			m_Character.Move(h, crouch, m_Jump);
			m_Jump = false;
		}
	}
}
