using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivePanelsLevel007 : MonoBehaviour
{
    public int[] panelListState;
    private bool canInit;
    private bool canLoadState;
    private GameObject[] panelList;
    private static ActivePanelsLevel007 activePanelsLevel007;
    public string[] levelNames;

    private void Awake()
    {
        canInit = true;

        if (ActivePanelsLevel007.activePanelsLevel007 == null)
        {
            ActivePanelsLevel007.activePanelsLevel007 = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == levelNames[0] && canInit)
        {
            SetStates();
        }

        if (SceneManager.GetActiveScene().name == levelNames[1])
        {
            canLoadState = true;
            canInit = false;
        }

        if (SceneManager.GetActiveScene().name == levelNames[0] && canLoadState)
        {
            LoadPanelStates();
        }
    }

    private void SetStates()
    {
        GameObject panelController = GameObject.Find("PanelController");
        panelList = new GameObject[panelController.transform.childCount];
        panelListState = new int[panelController.transform.childCount];

        for (int i = 0; i < panelController.transform.childCount; i++)
        {
            panelList[i] = GameObject.Find("PanelController").transform.GetChild(i).gameObject;

            if (panelList[i].GetComponent<Animator>().GetBool("Activate") == false)
            {
                panelListState[i] = 0;
            }
            else
            {
                panelListState[i] = 1;
            }
        }
    }

    private void LoadPanelStates()
    {
        GameObject panelController = GameObject.Find("PanelController");

        for (int i = 0; i < panelController.transform.childCount; i++)
        {
            panelList[i] = GameObject.Find("PanelController").transform.GetChild(i).gameObject;

            if (panelListState[i] == 0)
            {
                panelList[i].GetComponent<Animator>().SetBool("Activate", false);
            }
            else
            {
                panelList[i].GetComponent<Animator>().SetBool("Activate", true);
                panelList[i].GetComponent<ActivatePanel>().SwitchVisibility();
            }
        }

        canLoadState = false;
        canInit = true;
    }
}
