using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneController : MonoBehaviour
{
    public void Salir_OnClick()
    {
        Application.Quit();
    }

    public async void CargarEscenaOnClick(string LevelName)
    {
        await LoadSceneAsync(LevelName);
    }

    private async Task LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // 0.9 is the maximum progress value when the scene is loaded
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            await Task.Yield();
        }
    }
}
