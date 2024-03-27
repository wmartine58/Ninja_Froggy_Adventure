using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Rendering.FilterWindow;

public class BreakBox : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRederer;
    public GameObject brokenParts;
    public int lifes = 1;
    public GameObject boxCollider;
    public Collider2D coll2D;
    public GameObject element;
    public AudioSource[] clips;
    public JumpBox jumpBox;
    public float disableTime = 0.5f;
    public Rigidbody2D rb2D;
    public GameObject BoxWithElement;
    //private FrostGuardianLife frostGuardianLife;
    //public Vector3[] brokenPartPositions;

    private void Awake()
    {
        //brokenPartPositions = jumpBox.brokenPartPositions;
        clips = new AudioSource[2];
        clips[0] = GameObject.Find("HitBox").GetComponent<AudioSource>();
        clips[1] = GameObject.Find("BreakBox").GetComponent<AudioSource>();
        //frostGuardianLife = GameObject.Find("StandarInterface").GetComponent<Initialization>().frostGuardianAvatar.GetComponent<FrostGuardianLife>();
        //rb2D = GetComponentInParent<Rigidbody2D>();
        SetElementParent();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (collision.gameObject.name == "FrostGuardian")
            {
                //StartCoroutine(frostGuardianLife.GroundAnchor(0.02f));
                LoseLifeAndHit();
            }
        }
    }

    private void SetElementParent()
    {
        element.SetActive(false);

        if (element.GetComponent<BriefCollected>())
        {
            element.GetComponent<BriefCollected>().inBox = true;
            element.transform.SetParent(GameObject.Find("BriefManager").transform);
        }
        else if (element.GetComponent<ItemCollected>())
        {
            element.GetComponent<ItemCollected>().inBox = true;
            element.transform.SetParent(GameObject.Find("ItemManager").transform);
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
            int brokenPartsLength = brokenParts.transform.childCount;
            jumpBox.brokenPartPositions = new Vector3[brokenPartsLength];
            clips[1].Play();

            for (int i = 0; i < brokenPartsLength; i++)
            {
                Transform brokenPart = brokenParts.transform.GetChild(i);
                jumpBox.brokenPartPositions[i] = brokenPart.position;
            }

            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            element.transform.position = gameObject.transform.position;

            if (element.GetComponent<BriefCollected>())
            {
                if (!element.GetComponent<BriefCollected>().isCollected)
                {
                    element.GetComponent<BriefCollected>().inBox = false;
                    element.SetActive(true);
                }
            }
            else if (element.GetComponent<ItemCollected>())
            {
                if (!element.GetComponent<ItemCollected>().isCollected)
                {
                    element.GetComponent<ItemCollected>().inBox = false;
                    element.SetActive(true);
                }
            }

            coll2D.enabled = false;
            brokenParts.SetActive(true);
            spriteRederer.enabled = false;
            jumpBox.isBroken = true;
            StartCoroutine(jumpBox.DestroyBox());
            gameObject.SetActive(false);
        }
        else
        {
            clips[0].Play();
        }
    }

    //public IEnumerator DestroyBox()
    //{
    //    yield return new WaitForSecondsRealtime(disableTime);
    //    BoxWithElement.SetActive(false);
    //}
}
