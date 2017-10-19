using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMagicService : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (5 * Time.deltaTime, 0));
	}
}
