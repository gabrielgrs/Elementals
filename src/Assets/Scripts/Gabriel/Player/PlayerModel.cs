using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

	public int Life;
	public int Mana;
	public int Attack;
	public int Defense;
	public bool Died;

	public string FirstSkill;
	public string SecondSkill;
	public string ThirdSkill;

	void Start () {
		Life = 100;
		Mana = 100;
		Attack = 10;
		Defense = 10;
		Died = false;
	}

	void Update() {
		print (Life);
	}

}
