using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardTutorial : MonoBehaviour {

	public Slider loadBar;
	public bool loadBarCompled;
	public GameObject startButton;

	void Start () {
		loadBar.maxValue = 10;
		loadBar.value = 0;
		loadBarCompled = false;

		loadBar.transform.position = new Vector2 (Screen.width / 2, Screen.height / 10);

	}

	void Awake() {
		startButton.SetActive (false);
	}
	

	void Update () {
		if (loadBar.value < 10) {
			loadBar.value += Random.Range (Time.deltaTime, Time.deltaTime * 2);
			print (loadBar.value);
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Battle");
		}
	}
}
