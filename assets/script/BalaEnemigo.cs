using UnityEngine;
using System.Collections;

public class BalaEnemigo : MonoBehaviour {

	public HudController HudManager; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartMoving() {
		this.rigidbody.AddForce (transform.forward * 200f);
	}

	// Cuando colisiona
	void OnCollisionEnter (Collision col)
	{

		// combrobamos si colisiona con el cubo		
		if (col.gameObject.tag == "MainCamera") {
			// Si colisiona con el cubo restamos vida
			GameObject.Find ("Main Camera").SendMessage ("DisminuirVidas");			
			// destruimos la bala
			Destroy (gameObject);  
			GameObject.Find ("Cubo").SendMessage ("toogleShooting");

			GameObject go = GameObject.Find("HudCamera");
			HudController HudManager = (HudController) go.GetComponent(typeof(HudController));
			HudManager.Actualizahudbalaenemigo();
		}


		if (col.gameObject.tag == "Limite") {
			GameObject.Find ("Cubo").SendMessage ("toogleShooting");			
			Destroy (gameObject);  
		}

	}
}
