using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayer : MonoBehaviour {

    public string Name;
    public string Element;

    public InputField nameField;
    public Dropdown elementDropdown;


	void Start () 
    {
	}

    public void SavePlayer()
    {
        if (nameField.text != "")
        {
            Name = nameField.text;
            PlayerPrefs.SetString("Name", Name);
        }
        else
        {
            print("Nome inválido!");
        }
        

        if (elementDropdown.value.ToString() != "")
        {
            Element = elementDropdown.value.ToString();
            PlayerPrefs.SetString("Element", Element);
        }
        else
        {
            print("Elemento inválido!");
        }

        if (Name != "" && Element != "")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cidade");
        }
    }

    public void CancelCreation()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");
    }
}
