using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRederer;
    public GameObject brokenParts;
    public float jumpforce = 4;
    public int lifes = 1;
    public GameObject boxCollider;
    public Collider2D coll2D;
    public GameObject element;
    public bool isBroken = false;
    public float disableTime = 0.5f;
    public Rigidbody2D rb2D;
    public BreakBox breakBox;
    public Vector3[] brokenPartPositions;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (collision.transform.name == "Player")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpforce;
            }
            
            breakBox.LoseLifeAndHit();
        }
    }

    public IEnumerator DestroyBox()
    {
        yield return new WaitForSecondsRealtime(disableTime);
        transform.parent.gameObject.SetActive(false);
    }

    public void RestoreBox()
    {
        element.SetActive(false);
        boxCollider.SetActive(true);
        coll2D.enabled = true;
        spriteRederer.enabled = true;
        RestoreBrokenParts();
        brokenParts.SetActive(false);
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        transform.parent.gameObject.SetActive(true);
        isBroken = false;
        
        if (element.GetComponent<BriefCollected>())
        {
            if (!element.GetComponent<BriefCollected>().isCollected)
            {
                element.GetComponent<BriefCollected>().inBox = true;
            }
        }
        else if (element.GetComponent<ItemCollected>())
        {
            if (!element.GetComponent<ItemCollected>().isCollected)
            {
                element.GetComponent<ItemCollected>().inBox = true;
            }
        }
    }

    private void RestoreBrokenParts()
    {
        int brokenPartsLength = brokenParts.transform.childCount;
        
        for (int i = 0; i < brokenPartsLength; i++)
        {            
            brokenParts.transform.GetChild(i).position = brokenPartPositions[i];
            brokenParts.transform.GetChild(i).rotation = new Quaternion();

            if (brokenParts.transform.GetChild(i).GetComponent<Rigidbody>())
            {
                brokenParts.transform.GetChild(i).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
