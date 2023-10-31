using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class butonManagerScript : MonoBehaviour
{
    public string jugarScene;
    public string menu;
    public string resultados;

    public void irPlay()
    {
        SceneManager.LoadScene(jugarScene);
    }

    public void salir()
    {
        Application.Quit();
    }

    public void irMenu()
    {
        SceneManager.LoadScene(menu);

    }


}
