using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostGuardianLife : MonoBehaviour
{
    public int lifes = 2;
    public float immuneTime = 1;
    private int startLifes;
    private bool isImmune;
    private GameObject playerSkills;
    private Rigidbody2D rb2D;
    public float anchorTime = 0.02f;

    private void Awake()
    {
        playerSkills = GameObject.Find("StandarInterface").GetComponent<Initialization>().playerSkills;
        startLifes = lifes;
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Hit()
    {
        if (!isImmune)
        {
            isImmune = true;
            lifes -= 1;
            StartCoroutine(GroundAnchor(anchorTime));
            StartCoroutine(DisableImmunity());

            if (lifes <= 0)
            {
                RestartLifes();
                isImmune = false;
                playerSkills.GetComponent<FrostGuardian>().Destransformation();
            }
        }
    }

    public IEnumerator GroundAnchor(float anchorTime)
    {
        gameObject.layer = 7;       // Capa neutral
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(anchorTime);
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(immuneTime - anchorTime);
        gameObject.layer = 8;       // Capa del jugador
    }

    private IEnumerator DisableImmunity()
    {
        yield return new WaitForSeconds(immuneTime);
        isImmune = false;
    }

    public void RestartLifes()
    {
        lifes = startLifes;
    }
}
