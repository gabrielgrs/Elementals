using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth = 100;
    
    public float healthBarLength;
    
    void Start() {
   
    }
    
    void Update() {

    }

	public void takeDamage(int _damage) {
		currentHealth -= _damage;
		print (currentHealth);
	}
    


}
