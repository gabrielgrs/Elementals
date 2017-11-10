using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtons : MonoBehaviour {
	public Button leftArrow;
	public Button rightArrow;
	public Button attackButton;

	public Button firstMagic;
	public Button secondMagic;
	public Button thirdMagic;

	public Button firstItem;
	public Button secondItem;

	public Button pause;

	public GameObject button;

	void Start() {		
		//leftArrow = button.GetComponent<Button> ();
	}

	void Update() {

		//transform.Translate (leftArrow.input * Time.deltaTime, 0, 0);

		//transform.position = new Vector2 ((float)Screen.width / 2.0f);
		//transform.position = new Vector2 ((float)Screen.heigth / 2.0f);
	}
}
