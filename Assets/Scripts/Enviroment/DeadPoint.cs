using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint : MonoBehaviour
{
    public bool isSuperAttack = true;
    private GameObject player;
    private GameObject frostGuardianAvatar;
    private FrostGuardian frostGuardian;
    private PlayerInfo playerInfo;
    
    private void Awake()
    {
        player = GameObject.Find("StandarInterface").GetComponent<Initialization>().player;
        playerInfo = GameObject.Find("StandarInterface").GetComponent<Initialization>().playerInfo;
        frostGuardian = GameObject.Find("StandarInterface").GetComponent<Initialization>().playerSkills.GetComponent<FrostGuardian>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.name == "FrostGuardian")
            {
                frostGuardian.Destransformation();
            }

            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            player.GetComponent<PlayerRespawn>().PlayerDamaged(playerInfo.maxHearts, isSuperAttack);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
