using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomReward : MonoBehaviour
{
    public GameObject adContainer;
    public GameObject storeContainer;
    private AudioSource[] buttonClips;

    private void Awake()
    {
        SetButtonSounds();
    }

    private void SetButtonSounds()
    {
        buttonClips = new AudioSource[3];
        buttonClips[0] = GameObject.Find("ButtonSoundController").transform.GetChild(0).GetComponent<AudioSource>();
        buttonClips[1] = GameObject.Find("ButtonSoundController").transform.GetChild(1).GetComponent<AudioSource>();
        buttonClips[2] = GameObject.Find("ButtonSoundController").transform.GetChild(2).GetComponent<AudioSource>();
    }

    public void ShowRewardPanel()
    {
        buttonClips[0].Play();
        adContainer.SetActive(true);
        //storeContainer.SetActive(false);
        storeContainer.GetComponent<CanvasGroup>().interactable = false;
    }

    public void HideRewardPanel()
    {
        buttonClips[2].Play();
        adContainer.SetActive(false);
        //storeContainer.SetActive(true);
        storeContainer.GetComponent<CanvasGroup>().interactable = true;
    }
}
