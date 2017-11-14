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

		if(GUI.Button (new Rect((float)Screen.width / 2.1f, Screen.height/2, 90,60), "Controles")){
			
		}

		if(GUI.Button (new Rect((float)Screen.width / 2.1f, Screen.height/2 + 90, 90,60), "Vídeo")){

		}

		if(GUI.Button (new Rect((float)Screen.width / 2.1f, Screen.height/2 + 180, 90,60), "Voltar")){
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
		}
	}
}
