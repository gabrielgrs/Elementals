using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{

    private GameObject Magic;
    // private SkillModel skillModel;
    private GameObject player;
    private PlayerModel playerModel;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Magic = GameObject.FindGameObjectWithTag("Magic");
        playerModel = player.GetComponent<PlayerModel>();
    }

    public void CastFirstMagic()
    {
        Instantiate(Magic, new Vector2(player.transform.position.x + (playerModel.FacingRight ? +0.5f : -0.5f ), player.transform.position.y), player.transform.rotation);
    }


    public void CastSecondMagic() { }

    public void CastThirdMagic() { }
}
