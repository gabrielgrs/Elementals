using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public GUISkin PerSkin;
	public PlayerModel playerModel;
	public GameStorage gameStorage;

	public Text gold;
	public Text lifePotion;
	public Text manaPotion;

	public GameObject potionsHUD;

	void FixedUpdate() {
		gameStorage = gameObject.AddComponent<GameStorage> ();
		potionsHUD = GameObject.FindGameObjectWithTag ("PotionsHUD");

		potionsHUD.transform.position = new Vector2 (Screen.width / 2, Screen.height / 2);

		lifePotion.text = PlayerPrefs.GetInt ("LifePotion").ToString();
		manaPotion.text = PlayerPrefs.GetInt ("ManaPotion").ToString();
		gold.text = PlayerPrefs.GetInt ("PlayerGold").ToString();
	}

	void OnGUI (){

		GUI.skin = PerSkin;

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2, 180, 100), "Comprar poção de HP")) {

			if (PlayerPrefs.GetInt ("PlayerGold") > 0) {
				PlayerPrefs.SetInt ("PlayerGold", PlayerPrefs.GetInt ("PlayerGold") - 100);
				PlayerPrefs.SetInt ("LifePotion", PlayerPrefs.GetInt("LifePotion") + 1);
				print ("Você comprou uma poção de HP!");
			} else {
				print ("Você não tem dinheiro suficiente!");
			}
		}

		if (GUI.Button (new Rect ((float)Screen.width / 2.3f, Screen.height / 2 + 90, 180, 100), "Comprar poção de MP")) {
			
			if (PlayerPrefs.GetInt ("PlayerGold") > 0) {
				PlayerPrefs.SetInt ("PlayerGold", PlayerPrefs.GetInt ("PlayerGold") - 100);
				PlayerPrefs.SetInt ("ManaPotion", PlayerPrefs.GetInt("ManaPotion") + 1);

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
