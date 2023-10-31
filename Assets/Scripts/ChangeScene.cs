using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeScenesAsync(int n)
    {
        SceneManager.LoadSceneAsync(n);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ChangeScenes(int n)
    {
        SceneManager.LoadScene(n);
    }
}
