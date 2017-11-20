using UnityEngine;
using System.Collections;


public class Main : MonoBehaviour
{
	public GameStorage gameStorage;

	void Start ()
	{
		gameStorage = GetComponent<GameStorage> ();
		print ("Main.Start() chamado!");
	}

	void FixedUpdate ()
	{
		gameStorage.loadGame ();
	}
		
}

