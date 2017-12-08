using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public GUISkin PerSkin;
	public PlayerModel playerModel;
	public GameStorage gameStorage;


	void Awake() {	
		playerModel = gameObject.AddComponent<PlayerModel> ();
		playerModel = gameStorage.loadPlayer();
	}

	void OnGUI (){

		GUI.skin = PerSkin;

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2, 180, 100), "Comprar poção de HP")) {

			if (playerModel.Gold > 0) {
				playerModel.Gold -= 10;
				playerModel.LifePotion++;
				gameStorage.setLifePotion(playerModel.LifePotion);
				gameStorage.setPlayerGold(playerModel.Gold);
				print ("Você comprou uma poção de HP!");
			} else {
				print ("Você não tem dinheiro suficiente!");
			}
			//UnityEngine.SceneManagement.SceneManager.LoadScene ("SelectStage");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2 + 90, 180, 100), "Comprar poção de MP")) {
			
			if (playerModel.Gold > 0) {
				playerModel.Gold -= 10;
				playerModel.ManaPotion++;
				gameStorage.setManaPotion(playerModel.ManaPotion);
				gameStorage.setPlayerGold(playerModel.Gold);
				print ("Você comprou uma poção de MP!");
			} else {
				print ("Você não tem dinheiro suficiente!");
			}
			//UnityEngine.SceneManagement.SceneManager.LoadScene ("Shop");
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2 + 180, 180, 100), "Voltar")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Cidade");
		}

	}
}
