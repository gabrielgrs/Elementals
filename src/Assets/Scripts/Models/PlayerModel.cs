using System.Collections;
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

    public int LifePotion { get; set; }
    public int ManaPotion { get; set; }

	public int LastStage { get; set; }

	// Estados
	public bool InFloor { get; set; }
	public bool FacingRight { get; set; }
}
