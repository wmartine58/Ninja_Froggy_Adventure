using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostPeopleLevel005 : MonoBehaviour
{
    public GameObject[] people;
    public GameObject[] trappedPeople;
    public ActivatePanel activatePanel;
    public BoxCollider2D boxCollider2D;
    public GameObject door;
    public GameObject groundLock;
    public GameObject dialogue;
    public HomeArriveLevel005 homeArriveLevel005;
    public string[] levelNames;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == levelNames[0])
        {
            if (DisableEnemiesLevel005.disableEnemiesLevel005 != null)
            {
                if (DisableEnemiesLevel005.disableEnemiesLevel005.canDisableEnemies)
                {
                    DisableRockLock();
                }
            }
            
            if (activatePanel.animator.GetBool("Activate"))
            {
                dialogue.SetActive(true);
                EnableHostPeopleEvent();
            }

            if (GameObject.Find("ArrivePoint").GetComponent<HomeArriveLevel005>().gifRecived)
            {
                door.SetActive(false);
            }

            for (int i = 0; i < trappedPeople.Length; i++)
            {
                if (activatePanel.animator.GetBool("Activate"))
                {
                    trappedPeople[i].GetComponent<MoveAndDisappear>().canMove = true;
                }
            }

            if (homeArriveLevel005.gifRecived)
            {
                groundLock.SetActive(false);
            }
        }
    }

    private void DisableRockLock()
    {
        boxCollider2D.enabled = false;
    }

    public void EnableHostPeopleEvent()
    {
        for (int i = 0; i < people.Length; i++)
        {
            people[i].SetActive(true);
        }
    }
}
