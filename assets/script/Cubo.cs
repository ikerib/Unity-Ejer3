using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cubo : MonoBehaviour
{
	
		// Variables publicas para el acceso desde el diseñador
		public float velocidad;
		public GameObject PrefBalaEnemigo;
		public HudController HudManager; 
		
		private int sentido = -1;
		private int VidasPersonaje;

		
		// Al tener paredes fijas, no necesitamos variables publicas. Seran fijas.
		private static Vector3 maxLeft = new Vector3 (6f, 0.5f, 0);
		private static Vector3 maxRight = new Vector3 (-6f, 0.5f, 0);
		private bool isShooting = false;
		private Vector3 dest = new Vector3 (0, 0, 0);

		void Start ()
		{
				// Variables iniciales. Si estan a nulo, establecemos valores por defecto
				if (velocidad == 0)
						velocidad = 1;
				if (VidasPersonaje == 0)
						VidasPersonaje = 3;
				dest = maxLeft;
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if ((dest.x - 0.5f < this.transform.position.x) && (sentido == -1)) {
						sentido = 1;
						dest = maxRight;
				} else if ((dest.x + 0.5f > this.transform.position.x) && (sentido == 1)) {
						sentido = -1;
						dest = maxLeft;
				}
				
				this.transform.position = Vector3.MoveTowards (transform.position, dest, Time.deltaTime * velocidad); 
				RaycastHit hit;
				Vector3 fin = new Vector3 (this.transform.position.x, 3.5f, 9f);
				//Debug.DrawLine (this.transform.position, fin, Color.red);

				if (Physics.Raycast (this.transform.position, fin, out hit)) { 
						if (hit.collider.tag == "MainCamera") {
								if (isShooting == false) {
										isShooting = true;
										Vector3 desti = new Vector3 (this.transform.position.x, 0.08f, 0.8f);
										GameObject BalaEnemigo = (GameObject)GameObject.Instantiate (PrefBalaEnemigo, desti, Quaternion.identity);  
										BalaEnemigo.transform.LookAt (Camera.main.camera.transform.position);
										BalaEnemigo.GetComponent<BalaEnemigo> ().StartMoving ();
								}					
						}					
				}			
		}
		
		// Cuando colisiona
		void OnCollisionEnter (Collision col)
		{
				GameObject go = GameObject.Find ("HudCamera");
				HudController HudManager = (HudController)go.GetComponent (typeof(HudController));
				int numVidas;
				// combrobamos si colisiona con el cubo		
				if (col.gameObject.tag == "Bala") {
						// Si colisiona con el cubo restamos vida
						//GameObject.Find ("Cubo").SendMessage ("DisminuirVidas");			
						// destruimos la bala
						
						numVidas = HudManager.Actualizahudcubo (true);
						
						if (numVidas < 1) {
								Application.LoadLevel ("victory");
						}
						Destroy (col.gameObject); 
				}
 
		}


		public void toogleShooting ()
		{
				if (isShooting == false) {
						isShooting = true;
				} else {
						isShooting = false;
				}
			
		}
}