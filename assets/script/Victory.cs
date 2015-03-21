using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour
{

		int TotalScore = 0;

		// Use this for initialization
		void Start ()
		{
			TotalScore = PlayerPrefs.GetInt ("TotalScore");	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		public Texture gameOverTexture;
	
		void OnGUI ()
		{
				GUI.Label (new Rect (Screen.width / 2 - 100, 310, 200, 220), "<color=white><size=50>Victory!!</size></color>");
				GUI.Label (new Rect (Screen.width / 2 - 40, 400, 80, 30), "Puntos: " + TotalScore.ToString());
		}
}
