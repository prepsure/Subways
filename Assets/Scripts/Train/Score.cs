using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    private void Awake() 
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        SetUI(0);
    }

    public void SetUI(int Score)
    {
        ScoreText.text = "" + Score;
    }
}
