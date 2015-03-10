using UnityEngine;
using System.Collections;

public class DebugMessages : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Variable pública para acceso externo al script
	public void WriteToLog(string text)
	{
		Debug.Log(text);
	}
}
