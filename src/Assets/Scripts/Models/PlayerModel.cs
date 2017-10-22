﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
	public string Name { get; set; }

	public int Level { get; set; }
	public int Exp { get; set; }

	public int Gold { get; set; }

	public int MaxLife { get; set; }
	public int Life { get; set; }

	public int MaxMana { get; set; }
	public int Mana { get; set; }

	public int Attack { get; set; }
	public int Defense { get; set; }
	public bool Died { get; set; }

	public string FirstSkill { get; set; }
	public string SecondSkill { get; set; }
	public string ThirdSkill { get; set; }


	// Estados
	public bool InFloor { get; set; }
	public bool FacingRight { get; set; }
	
	void Start () {
		Name = "Batatão"; MaxLife = 100; Life = 100; MaxMana = 100; Mana = 100; Attack = 10; Defense = 10;	Died = false; Gold = 0;	Exp = 1; Level = 0; InFloor = true; FacingRight = true;
	}



}