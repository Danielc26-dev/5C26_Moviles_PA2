using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resultados : MonoBehaviour
{
    public TMP_Text resultText;
    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("ScoreFinal");
        
    }


    private void Update()
    {
        resultText.text = score.ToString();
    }


}
