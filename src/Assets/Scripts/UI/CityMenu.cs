using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMenu : MonoBehaviour {

	public GUISkin PerSkin;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI (){

		GUI.skin = PerSkin;

		if (GUI.Button (new Rect ((float)Screen.width / 2.1f, Screen.height / 2, 90, 60), "Batalhar")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Battle");
		}

	}
}
