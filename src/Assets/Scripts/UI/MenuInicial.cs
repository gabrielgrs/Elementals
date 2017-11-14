using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour {

	public GUISkin PerSkin;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnGUI (){

		GUI.skin = PerSkin;

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 90, 90, 60), "Começar")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Cidade");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 150, 90, 60), "Opções")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Options");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 210, 90, 60), "Sair")) {
			Application.Quit ();
		}
	
	}
}
