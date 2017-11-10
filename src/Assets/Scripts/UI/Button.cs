/*
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public float input;
	bool pressing;

	void Start () {
		
	}	

	public void OnPointerDown(PointerEventData eventData){
		pressing = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		pressing = false;
	}

	void Update () {
		if (pressing) {
			input += Time.deltaTime;
		}
	}
}

*/