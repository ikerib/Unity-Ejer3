using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
		// Variable públicas a cajas de texto
		public Text VidasPersonaje;	
		public Text VidasEnemigo;	
		public Text Puntos;	
		public Text Disparos;	
		public Text Aciertos;	
		
		// Defininimos número de Vidas del personaje y enemigo
		private int numVidasPersonaje;
		private int numVidasEnemigo;

		// Variables privadas	
		private int numPuntos;
		private int numDisparos;
		private int numAciertos;

		void Start ()
		{
				// Inicializamos variables con seguridad
				numPuntos = 0;
				numDisparos = 0;
				numAciertos = 0;
				
				// Leemos las vidas desde el CameraController
				numVidasPersonaje = Camera.main.camera.GetComponent<CameraController> ().vidasPersonaje;		
				numVidasEnemigo = Camera.main.camera.GetComponent<CameraController> ().vidaEnemigo;

				// Inicializamos con valores si vacio
				if (numVidasEnemigo == 0)
						numVidasEnemigo = 3;
				if (numVidasPersonaje == 0)
						numVidasPersonaje = 3;

				// Mostramos HUD
				VidasPersonaje.text = "Mis Vidas: " + numVidasPersonaje.ToString ();
				VidasEnemigo.text = "Vidas Enemigo: " + numVidasEnemigo.ToString ();
				Puntos.text = "Puntos: 0";
				Disparos.text = "Disparos: 0";
				Aciertos.text = "Aciertos: 0";
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void StoreScore()
		{
			PlayerPrefs.SetInt ("TotalScore", numPuntos);
		}

		public int Actualizahudcubo (bool acierto)
		{
				// Función que acualiza el Hud actualizando antes las vidas y devuelve el número de Vidas del enemigo
				// Pasamos booleano diciendo si el disparo a dado en el banco o no, para así actualizar vidas + puntos
				numDisparos += 1;

				if (acierto == true) {
						
						numAciertos += 1;
						numPuntos += 10;
						numVidasEnemigo -= 1;
				}

				Puntos.text = "Puntos: " + numPuntos.ToString ();
				Disparos.text = "Disparos: " + numDisparos.ToString ();
				Aciertos.text = "Aciertos: " + numAciertos.ToString ();
				VidasEnemigo.text = "Vidas Enemigo: " + numVidasEnemigo.ToString ();
				StoreScore ();
				

				return numVidasEnemigo;
		}

		public int Actualizahudbalaenemigo ()
		{
				// Función que acualiza el Hud actualizando antes las vidas y devuelve el número de Vidas del personaje
				// para así actualizar vidas + puntos
				numPuntos -= 10;
				Puntos.text = "Puntos: " + numPuntos.ToString ();

				numVidasPersonaje -= 1;
				VidasPersonaje.text = "Mis Vidas: " + numVidasPersonaje.ToString ();
				StoreScore ();

				return numVidasPersonaje;
		}


}
