using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("FruitNinja");
    }


    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salí");
    }
    public void Restart()
    {
        SceneManager.LoadScene("FruitNinja");
    }
}
