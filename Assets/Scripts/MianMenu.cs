using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianMenu : MonoBehaviour
{
    
   

    public void HideMenu(int n)
    {
        
        SceneManager.LoadSceneAsync(n);
    }
    

    public void Quit()
    {
        Application.Quit();
        print("Saliste...");
    }
}
