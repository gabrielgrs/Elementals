﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayer : MonoBehaviour {

    public string Name;
    public string Element;

    public InputField nameField;
    public Dropdown elementDropdown;

	public GameObject form;

	void Start () {	}

	void Awake() { 
		form = GameObject.Find ("FormGameObject");
		form.transform.position = new Vector2 (Screen.width / 2, Screen.height / 2);
	}


    public void SavePlayer()
    {
        if (nameField.text != "")
        {
            Name = nameField.text;
            PlayerPrefs.SetString("PlayerName", Name);
        }
        else
        {
            print("Nome inválido!");
        }
        

        if (elementDropdown.value.ToString() != "")
        {
			Element = elementDropdown.value.ToString();
			if (Element == "0")
				Element = "Água";
			if (Element == "1")
				Element = "Fogo";
			if (Element == "2")
				Element = "Terra";
			if (Element == "3")
				Element = "Vento";

            PlayerPrefs.SetString("PlayerElement", Element);
        }
        else
        {
            print("Elemento inválido!");
        }

        if (Name != "" && Element != "")
        {
			PlayerPrefs.SetInt("PlayerGold", 500);
			PlayerPrefs.SetInt("PlayerExp", 1);
			PlayerPrefs.SetInt ("PlayerLevel", 1);
			PlayerPrefs.SetInt ("LifePotion", 3);
			PlayerPrefs.SetInt ("ManaPotion", 3);
			PlayerPrefs.SetInt ("LastStage", 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cidade");
        }
    }

    public void CancelCreation()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");
    }
}
