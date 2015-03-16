using UnityEngine;
using System.Collections;

public class BalaEnemigo : MonoBehaviour
{

		public HudController HudManager; 

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void StartMoving ()
		{
				// Aplicamos fuerza, la bala enemiga no tiene gravedad. Cambiar 200f por un número mayor para más velocidad.
				this.rigidbody.AddForce (transform.forward * 200f);
		}

		// Cuando colisiona
		void OnCollisionEnter (Collision col)
		{
				// combrobamos si colisiona con el cubo		
				if (col.gameObject.tag == "MainCamera") {
						
						// destruimos la bala
						Destroy (gameObject);  
						
						// Ya no estamos disparando
						GameObject.Find ("Cubo").SendMessage ("toogleShooting");
						
						// Actualizamos HUD 
						GameObject go = GameObject.Find ("HudCamera");
						HudController HudManager = (HudController)go.GetComponent (typeof(HudController));
						int numVidas = HudManager.Actualizahudbalaenemigo ();

						// Si morimos...
						if (numVidas < 1) {
								Application.LoadLevel ("GameOver");
						}
				}


				// Sin esto la balas viajan al infinito y más allá
				if (col.gameObject.tag == "Limite") {
						GameObject.Find ("Cubo").SendMessage ("toogleShooting");			
						Destroy (gameObject);  
				}

		}
}
