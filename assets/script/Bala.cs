using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour
{
			
		// Use this for initialization
		void Start ()
		{
				Vector3 CameraPosition;
				CameraPosition = Camera.main.gameObject.transform.position;

				this.transform.position = CameraPosition;
				audio.Play ();
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		// Cuando colisiona
		void OnCollisionEnter (Collision col)
		{
				// combrobamos si colisiona con el cubo		
				if (col.gameObject.tag == "Cubo") {
						// Si colisiona con el cubo restamos vida
						GameObject.Find ("Cubo").SendMessage ("DisminuirVidas");			
						// destruimos la bala
						Destroy (gameObject);  
				}

				// se destruye siempre con el suelo, otra bala... con cualquier colisión
				Destroy (gameObject);  
		}
}
