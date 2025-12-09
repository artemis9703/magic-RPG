using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Button startButton;
    public string sceneToLoad;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("clicked");
    }
}