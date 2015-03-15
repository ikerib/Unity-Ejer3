using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

	public Text VidasPersonaje;	
	public Text VidasEnemigo;	
	public Text Puntos;	
	public Text Disparos;	
	public Text Aciertos;	


	private int numPuntos;
	private int numDisparos;
	private int numAciertos;

	// Use this for initialization
	void Start () {
		numPuntos = 0;
		numDisparos = 0;
		numAciertos = 0;

		GameObject miCubo = GameObject.Find ("Cubo");

		VidasPersonaje = gameObject.GetComponent<Cubo>().vidas;

		Puntos.text = "Puntos: 0";
		Disparos.text = "Disparos: 0";
		Aciertos.text = "Aciertos: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Actualizahudcubo(bool acierto, int vidasplayer)
	{
		VidasPersonaje.text = vidasplayer.ToString ();
		numDisparos += 1;

		if (acierto == true) {
			numAciertos +=1;
			numPuntos = numDisparos * 10;
		}

		Puntos.text = "Puntos: " + numPuntos.ToString ();
		Disparos.text = "Disparos: " + numDisparos.ToString ();
		Aciertos.text = "Aciertos: " + numAciertos.ToString ();
	}

	public void Actualizahudbalaenemigo()
	{
		numPuntos -= 10;
		Puntos.text = "Puntos: " + numPuntos.ToString ();
	}

	public void Actualizahudenemigo(bool acierto, int vidasenemigo)
	{
		VidasEnemigo.text = vidasenemigo.ToString ();
		numDisparos += 1;
		
		if (acierto == true) {
			numAciertos +=1;
			numPuntos = numDisparos * 10;
		}
		
		Puntos.text = "Puntos: " + numPuntos.ToString ();
		Disparos.text = "Disparos: " + numDisparos.ToString ();
		Aciertos.text = "Aciertos: " + numAciertos.ToString ();
	}
}
