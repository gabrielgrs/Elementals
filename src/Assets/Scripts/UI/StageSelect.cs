using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour {

    public GameObject player;
    public PlayerModel playerModel;

    public GameObject enemy;
    public EnemyModel enemyModel;

	void Start () {
        playerModel = gameObject.AddComponent<PlayerModel>();
	}

	void Awake() 
	{
		int currentStage = PlayerPrefs.GetInt ("LastStage");

		GameObject.Find ("buttonFirstStage").SetActive(true);

		if (currentStage == 2) {
			GameObject.Find ("buttonSecondStage").SetActive(true);
			GameObject.Find ("buttonThirdStage").SetActive(false);
			GameObject.Find ("buttonFourthStage").SetActive(false);
		} else if (currentStage == 3) {
			GameObject.Find ("buttonSecondStage").SetActive(true);
			GameObject.Find ("buttonThirdStage").SetActive(true);
			GameObject.Find ("buttonFourthStage").SetActive(false);
		} else if (currentStage == 4) {
			GameObject.Find ("buttonSecondStage").SetActive(true);
			GameObject.Find ("buttonThirdStage").SetActive(true);
			GameObject.Find ("buttonFourthStage").SetActive(true);
		}
	}


    public void backMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cidade");
    }

    public void firstStage()
    {
        print("Primeira fase!");
		PlayerPrefs.SetInt ("LastStage", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }

    public void secondStage()
    {
        print("Segunda fase!");
		PlayerPrefs.SetInt ("LastStage", 2);
		UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }

    public void thirdStage()
    {
        print("Primeira fase!");
		PlayerPrefs.SetInt ("LastStage", 3);
		UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }

    public void fourthStage()
    {
        print("Primeira fase!");
		PlayerPrefs.SetInt ("LastStage", 4);
		UnityEngine.SceneManagement.SceneManager.LoadScene("KeyboardTutorial");
    }
}
