using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject interfaceMenu;
    public GameObject startMenu;
    public GameObject gameManager;

    /*[SerializeField] string sceneAI;
    [SerializeField] string sceneVR;

    public void LoadAIScene()
    {
        SceneManager.LoadScene(sceneAI);
    }

    public void LoadVRScene()
    {
        SceneManager.LoadScene(sceneVR);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }*/

    public void StartGame() //on click disable start button, enable main UI, activate GameManager object
    {
        shopMenu.SetActive(true);
        interfaceMenu.SetActive(true);
        gameManager.SetActive(true);
        startMenu.SetActive(false);
    }
}