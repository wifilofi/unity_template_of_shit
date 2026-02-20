using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleMenuLoader : MonoBehaviour
{
    public void LoadGameplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
