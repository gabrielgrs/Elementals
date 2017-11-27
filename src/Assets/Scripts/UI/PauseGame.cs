using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public GameObject PausePanel;

	public bool paused = false;

	void Start() {		
		PausePanel.SetActive (false);
	}

	void Update() {
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			PausePanel.SetActive (true);
			Time.timeScale = 0;
			AudioListener.volume = 0;
		}

		if (!paused) {
			PausePanel.SetActive (false);
			Time.timeScale = 1;
			AudioListener.volume = 1;
		}
	}

	public void pauseButton() {
		paused = !paused;
	}

	public void Resume() {		
		paused = false;
	}

	public void Restart() {
		//Application.LoadLevel (Application.loadedLevel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Battle");
	}

	public void MainMenu() {
		//Application.LoadLevel (0);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
	}

	public void Quit() {
		//Application.Quit();
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
	}
}

