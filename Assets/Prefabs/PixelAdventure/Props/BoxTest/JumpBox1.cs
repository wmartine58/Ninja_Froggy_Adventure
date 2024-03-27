using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox1 : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRederer;
    public GameObject brokenParts;
    public float jumpforce = 4;
    public int lifes = 1;
    public GameObject boxCollider;
    public Collider2D coll2D;
    //public GameObject fruit;

    private void Start()
    {
        //fruit.SetActive(false);
        //fruit.transform.SetParent(FindObjectOfType<FruitManager>().transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpforce;
            LoseLifeAndHit();
        }
    }

    public void LoseLifeAndHit()
    {
        lifes--;
        animator.Play("Hit");
        CheckLife();
    }

    public void CheckLife()
    {
        if (lifes <= 0)
        {
            //fruit.SetActive(true);
            boxCollider.SetActive(false);
            coll2D.enabled = false;
            brokenParts.SetActive(true);
            spriteRederer.enabled = false;
            Invoke("DestroyBox", 0.5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(transform.parent.gameObject);
    }
}
