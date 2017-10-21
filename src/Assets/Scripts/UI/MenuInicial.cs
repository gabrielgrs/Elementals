using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour {

	public GUISkin PerSkin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI (){

		GUI.skin = PerSkin;

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2, 90, 60), "Começar")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Battle");
		}
		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 90, 90, 60), "Sair")) {
			Application.Quit ();
		}
	
	}
}
