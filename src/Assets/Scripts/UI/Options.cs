using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

	public GUISkin perSkin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){

		GUI.skin = perSkin;

		if(GUI.Button (new Rect((float)Screen.width / 2.3f, Screen.height/2, 180, 90), "Controles")){
			
		}

		if(GUI.Button (new Rect((float)Screen.width / 2.3f, Screen.height/2 + 60, 180, 90), "Vídeo")){

		}

		if(GUI.Button (new Rect((float)Screen.width / 2.3f, Screen.height/2 + 120, 180, 90), "Voltar")){
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
		}
	}
}
