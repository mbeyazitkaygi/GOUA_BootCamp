using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public string menuSceneName = "MenuScene";

    public SceneFader sceneFader;
    public MovingCamera movingCamera;

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        FindAnyObjectByType<AudioManager>().Play("UIClickSound");
    }

    public void Menu()
    {
        movingCamera.BackToCam();
        FindAnyObjectByType<AudioManager>().Play("UIClickSound");
    }
    public void GameOverMenu()
    {
        sceneFader.FadeTo(menuSceneName);
        FindAnyObjectByType<AudioManager>().Play("UIClickSound");
    }
}