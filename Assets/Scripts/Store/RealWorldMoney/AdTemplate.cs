using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AdTemplate : MonoBehaviour
{
    public int idPos;
    public Image image;
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI tittle;
    public int amount;

    private void Awake()
    {
        amountText.text = "X" + amount.ToString();
        SetImageSize();
    }

    private void SetImageSize()
    {
        switch (tittle.text)
        {
            case "Basic Sword":
                image.rectTransform.sizeDelta = new Vector2(300, 300);
                break;
            case "Gems Pack":
                image.rectTransform.sizeDelta = new Vector2(175, 175);
                break;
            default:
                break;
        }
    }
}
