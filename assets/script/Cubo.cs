using UnityEngine;
using System.Collections;

public class Cubo : MonoBehaviour
{
	
		// Variables publicas para el acceso desde el diseñador
		public float velocidad;
		public DebugMessages dLog;
		public int vidas;

		// Variables privadas del script
		Transform myTransform;
		
		private bool gameOver; // Constrola si hay que finalizar el juego o no
		private int sentido = -1;
		// Al tener paredes fijas, no necesitamos variables publicas. Seran fijas.
		private static Vector3 maxLeft = new Vector3 (6f, 0.5f, 0);
		private static Vector3 maxRight = new Vector3 (-6f, 0.5f, 0);
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

		
		void OnGUI ()
		{
				// Mostramos Vidas
				GUI.Label (new Rect (10, 10, 200, 100), vidas.ToString ());
				if (gameOver) {
						// Mostramos Game Over
						Application.LoadLevel ("GameOver");
				}
						
		}	
}