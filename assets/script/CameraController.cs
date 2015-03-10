using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
		public float velocidad;
		public float maxLeft;
		public float maxRight;

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
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Space)) {
						// instanciamos bala
						GameObject bala = (GameObject)GameObject.Instantiate (PrefBala); 
						// obtenemos su rigidbody			
						Rigidbody balaFisicas = (Rigidbody)bala.GetComponent<Rigidbody> ();
						// aplicamos fuerza = disparamos
						balaFisicas.AddForce (new Vector3 (0, 100, -400));
				}

				if (Input.GetKey (KeyCode.A)) {
						if (myTransform.position.x < maxLeft) {
								myTransform.Translate (Vector3.left * velocidad * Time.deltaTime);
						}
				}

				if (Input.GetKey (KeyCode.D)) {
						if (myTransform.position.x > maxRight) {
								myTransform.Translate (Vector3.right * velocidad * Time.deltaTime);			
						}
				}
		}

}
