using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicModel : MonoBehaviour
{
    public string Name { get; set; }

    public bool IsDamage { get; set; }

    public int Effect { get; set; }
    public string Element { get; set; }

    enum Elements { Wind, Earth, Fire, Water };
}

// Exemplo de criação
// MagicModel.Element = Elements.Fire.ToString();;