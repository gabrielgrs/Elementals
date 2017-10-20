using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : MonoBehaviour
{
    public string Name { get; set; }
    public int RecoveryQuantity { get; set; }

    // Se sim, recupera Vida, senão, recupera Mana
    public bool IsToLife { get; set; }

}


