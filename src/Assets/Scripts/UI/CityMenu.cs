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

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2, 180, 90), "Batalha")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("SelectStage");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2 + 60, 180, 90), "Loja")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Shop");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2 + 120, 180, 90), "Voltar")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
		}

	}
}
