using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{
    public scriptableObjectScore sos;
    public Text scoreFinish; 
    // Start is called before the first frame update
    void Start()
    {
        scoreFinish.text = sos.ScriptableScore.ToString();
    }


}
