using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMenu : MonoBehaviour {

	public GUISkin PerSkin;

	void Start () {

	}

	void Update () {

	}

	void OnGUI (){

		GUI.skin = PerSkin;

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2, 90, 60), "Batalha")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("SelectStage");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 45, 90, 60), "Loja")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Shop");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 90, 90, 60), "Voltar")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
		}

	}
}
