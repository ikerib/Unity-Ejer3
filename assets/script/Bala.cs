using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour
{
			
		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		// Cuando colisiona
		void OnCollisionEnter (Collision col)
		{
				GameObject go = GameObject.Find ("HudCamera");
				HudController HudManager = (HudController)go.GetComponent (typeof(HudController));
				
				// combrobamos si colisiona con el cubo		
				if (col.gameObject.tag != "Cubo") {
						Destroy (gameObject); 
						HudManager.Actualizahudcubo (false);
				}				
		}
}
