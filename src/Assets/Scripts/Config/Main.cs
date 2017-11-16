using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	public GameStorage GameStorage;

	void Start ()
	{
		
	}


	void FixedUpdate ()
	{
		GameStorage.saveGame ();
	}
}

