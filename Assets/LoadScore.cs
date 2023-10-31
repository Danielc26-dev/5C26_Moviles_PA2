using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadScore : MonoBehaviour
{
    public PuntajeScriptableObject puntaje;

    public TMP_Text score;
    void Start()
    {
        score.text = "Final Score: " + puntaje.puntaje.ToString();
    }

    
}
