using UnityEngine;

public class FloorCheckerService : MonoBehaviour {
    
    private GameObject player;
    private PlayerModel playerModel;

	private Rigidbody2D rb2d;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerModel = player.GetComponent<PlayerModel>();
		rb2d = player.GetComponent<Rigidbody2D> ();
     }
}