using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cubo : MonoBehaviour
{
	
		// Variables publicas para el acceso desde el diseñador
		public float velocidad;
		public DebugMessages dLog;
		public GameObject PrefBalaEnemigo;
		public HudController HudManager; 
			

		// Variables privadas del script
		Transform myTransform;
		
		
		private bool gameOver; // Constrola si hay que finalizar el juego o no
		private int sentido = -1;
		private int VidasPersonaje = gameObject.GetComponent<CameraController> ().vidasPersonaje;
		private int VidasEnemigo = gameObject.GetComponent<CameraController> ().vidaEnemigo;
		
		// Al tener paredes fijas, no necesitamos variables publicas. Seran fijas.
		private static Vector3 maxLeft = new Vector3 (6f, 0.5f, 0);
		private static Vector3 maxRight = new Vector3 (-6f, 0.5f, 0);
		private bool isShooting = false;
		private Vector3 dest = new Vector3 (0, 0, 0);
		// Use this for initialization
		void Start ()
		{
				// Variables iniciales. Si estan a nulo, establecemos valores por defecto
				myTransform = this.transform;
				if (velocidad == 0)
						velocidad = 1;
				if (vidas == 0)
						vidas = 3;
				gameOver = false;
				dest = maxLeft;
				//VidasPersonaje.text = "Vidas: " + vidas.ToString ();

		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if ((dest.x - 0.5f < myTransform.position.x) && (sentido == -1)) {
						sentido = 1;
						dest = maxRight;
				} else if ((dest.x + 0.5f > myTransform.position.x) && (sentido == 1)) {
						sentido = -1;
						dest = maxLeft;
				}
				
			
				//myTransform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime * velocidad); 
				myTransform.position = Vector3.MoveTowards (transform.position, dest, Time.deltaTime * velocidad); 
				RaycastHit hit;
				Vector3 fin = new Vector3(this.transform.position.x,3.5f,9f);
				Debug.DrawLine(this.transform.position, fin, Color.red);

				if ( Physics.Raycast( this.transform.position, fin, out hit ) )
				{ 
					if ( hit.collider.tag == "MainCamera" ) 
					{
						if (isShooting == false) 
						{
							isShooting=true;
							Vector3 desti = new Vector3(0, 0.08f, 0.8f);
							GameObject BalaEnemigo = (GameObject)GameObject.Instantiate (PrefBalaEnemigo, desti, Quaternion.identity);  
							BalaEnemigo.transform.LookAt(Camera.main.camera.transform.position);
							BalaEnemigo.GetComponent<BalaEnemigo>().StartMoving();
						}					
					}					
				}	
		
		}

		// Función para restar vidas al personaje
		public void DisminuirVidas ()
		{
			vidas -= 1;
			if (vidas < 1) {
				// terminamos el juego
				audio.Play ();
				gameOver = true;
				Camera.main.audio.Stop ();		
			} 

		}

		public void toogleShooting()
		{
			if (isShooting == false) {
				isShooting = true;
			} else {
				isShooting = false;
			}
			
		}
}