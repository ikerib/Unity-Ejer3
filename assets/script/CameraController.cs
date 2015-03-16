using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
		public float velocidad;
		public float maxLeft;
		public float maxRight;
		public int vidasPersonaje;
		public int vidaEnemigo;
		Transform myTransform;

		public GameObject PrefBala;
		public GameObject myCubo;

		// Use this for initialization
		void Start ()
		{
				myTransform = this.transform;
				if (velocidad == 0)
						velocidad = 4;
				if (maxLeft == 0)
						maxLeft = 6f;
				if (maxRight == 0)
						maxRight = -6f;
				if (vidaEnemigo == 0)
						vidaEnemigo = 3;
				if (vidasPersonaje == 0)
						vidasPersonaje = 3;
		}
	
		// Update is called once per frame
		void Update ()
		{
				// Si pulsamos spacio, disparamos
				if (Input.GetKeyUp (KeyCode.Space)) {
						// instanciamos bala
						Vector3 dest = new Vector3 (Camera.main.camera.transform.position.x, 3.5f, 7.5f);
						GameObject bala = (GameObject)GameObject.Instantiate (PrefBala, dest, Quaternion.identity);
						// obtenemos su rigidbody			
						Rigidbody balaFisicas = (Rigidbody)bala.GetComponent<Rigidbody> ();
						// aplicamos fuerza = disparamos
						balaFisicas.AddForce (new Vector3 (0, 100, -400));
				}

				if (Input.GetKey (KeyCode.A)) {
						// Movemos la cámara a la izquierda
						if (myTransform.position.x < maxLeft) {
								myTransform.Translate (Vector3.left * velocidad * Time.deltaTime);
						}
				}

				if (Input.GetKey (KeyCode.D)) {
						// Movemos la cámara a la derecha
						if (myTransform.position.x > maxRight) {
								myTransform.Translate (Vector3.right * velocidad * Time.deltaTime);			
						}
				}
		}


}
