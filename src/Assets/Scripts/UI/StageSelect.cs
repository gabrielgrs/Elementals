using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour {

    public GameObject player;
    public PlayerModel playerModel;

    public GameObject enemy;
    public EnemyModel enemyModel;

	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject four;

	void Start() {
		two = GameObject.FindGameObjectWithTag ("buttonSecondStage");
		three = GameObject.FindGameObjectWithTag ("buttonThirdStage");
		four = GameObject.FindGameObjectWithTag ("buttonFourthStage");
	}

	void FixedUpdate() 
	{
		int currentStage = PlayerPrefs.GetInt ("LastStage");

		two.SetActive (false);
		three.SetActive (false);
		four.SetActive (false);

		GameObject.Find ("buttonFirstStage").SetActive(true);

		if (currentStage == 2) {
			two.SetActive (true);
			three.SetActive (false);
			four.SetActive (false);
		} else if (currentStage == 3) {
			two.SetActive (true);
			three.SetActive (true);
			four.SetActive (false);
		} else if (currentStage == 4) {
			two.SetActive (true);
			three.SetActive (true);
			four.SetActive (true);
		}
	}


    public void backMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cidade");
    }

    public void firstStage()
    {
        print("Primeira fase!");
		PlayerPrefs.SetInt ("CurrentStage", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }

    public void secondStage()
    {
        print("Segunda fase!");
		PlayerPrefs.SetInt ("CurrentStage", 2);
		UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }

    public void thirdStage()
    {
        print("Primeira fase!");
		PlayerPrefs.SetInt ("CurrentStage", 3);
		UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }

    public void fourthStage()
    {
        print("Primeira fase!");
		PlayerPrefs.SetInt ("CurrentStage", 4);
		UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }
}
