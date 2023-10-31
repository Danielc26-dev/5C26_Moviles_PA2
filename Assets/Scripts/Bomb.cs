using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            FindObjectOfType<GameManager>().Explode();

            Invoke("LoadScene", 5.0f);
        }
    }


    void LoadScene()
    {
        SceneManager.LoadScene("Result");
    }

}
