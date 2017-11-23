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


    public void backMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cidade");
    }

    public void firstStage()
    {
        print("Primeira fase!");
        playerModel.LifePotion = 20;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }

    public void secondStage()
    {
        print("Primeira fase!");
        playerModel.LifePotion = 20;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }

    public void thirdStage()
    {
        print("Primeira fase!");
        playerModel.LifePotion = 20;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }

    public void fourthStage()
    {
        print("Primeira fase!");
        playerModel.LifePotion = 20;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }
}
