using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private string nextLevel;
    private float waitTime = 4;
    private GameDataManager gameDataManager;
    private InventoryDataManager inventoryDataManager;
    private EndLevelReward endLevelReward;
    private TransitionImage transitionImage;
    private TimeController timeController;

    private void Awake()
    {
        gameDataManager = GameObject.Find("StandarInterface").GetComponent<Initialization>().gameDataManager;
        inventoryDataManager = GameObject.Find("StandarInterface").GetComponent<Initialization>().inventoryDataManager;
        endLevelReward = GameObject.Find("StandarInterface").GetComponent<Initialization>().endLevelReward;
        transitionImage = GameObject.Find("StandarInterface").GetComponent<Initialization>().transitionImage;
        timeController = GameObject.Find("StandarInterface").GetComponent<Initialization>().timeController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            timeController.StopTime();
            transitionImage.StartTransition(0.3f, 30000, 10f);
            StartCoroutine(ShowEndLevelRewards());
            
        }
    }

    public IEnumerator ShowEndLevelRewards()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        endLevelReward.Show();
    }    

    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSecondsRealtime(waitTime/2);
        gameDataManager.levelCompleted = true;
        gameDataManager.SaveData();
        inventoryDataManager.SaveData();
        SetNextLevel();
        SceneManager.LoadScene(nextLevel);
    }

    private void SetNextLevel()
    {
        int nextLevelPosition = 0;

        for (int i = 0; i < gameDataManager.gameData.levels.Length; i++)
        {
            if (gameDataManager.gameData.levels[i] == SceneManager.GetActiveScene().name)
            {
                if (i < gameDataManager.gameData.levels.Length - 1)
                {
                    nextLevelPosition = i + 1;
                }
            }
        }

        if (nextLevelPosition > 0)
        {
            nextLevel = gameDataManager.gameData.levels[nextLevelPosition];
        }
        else
        {
            nextLevel = "MainMenu";
        }
        
    }
}
