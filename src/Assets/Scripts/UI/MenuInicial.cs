using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour {

	public GUISkin PerSkin;

    public GameStorage gameStorage;

	void Start () {
        gameStorage = gameObject.AddComponent<GameStorage>();
        gameStorage.loadGame();
	}
	
	void Update () {
		
	}

	void OnGUI (){

		GUI.skin = PerSkin;

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 90, 180, 90), "Começar")) {
            if (PlayerPrefs.GetString("Name") == "")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("CreatePlayer");
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Cidade");
            }
            
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 150, 180, 90), "Opções")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Options");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2 + 210, 180, 90), "Sair")) {
			Application.Quit ();
		}
	
	}
}
