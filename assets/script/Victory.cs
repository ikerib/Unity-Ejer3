using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{
				GUI.Label (new Rect (380, 310, 320, 220), "<color=white><size=50>VICTORY!!!</size></color>");
		}
}
