using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

	public GUISkin perSkin;

    public GameStorage gameStorage;

	void Start () {
        gameStorage = gameObject.AddComponent<GameStorage>();
	}

	void OnGUI(){

		GUI.skin = perSkin;

		// if(GUI.Button (new Rect((float)Screen.width / 2.3f, Screen.height/2, 180, 90), "Controles")){ }

		if(GUI.Button (new Rect((float)Screen.width / 2.3f, Screen.height/2 + 60, 180, 90), "Resetar Jogo"))
		{ 
			gameStorage.resetGame();
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
		}


        if (GUI.Button (new Rect((float)Screen.width / 2.3f, Screen.height/2 + 120, 180, 90), "Voltar")){
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
		}
	}
}
