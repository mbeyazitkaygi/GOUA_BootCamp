using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public string menuSceneName = "MenuScene";

    public SceneFader sceneFader;
    public MovingCamera movingCamera;

    //MovingCamera script'ine referansta bulun

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {

        movingCamera.BackToCam();


        //e�er sahnede CameraStartPos veya CameraEndPos objeleri var m� yok mu bunu kontrol etsin, null'sa return etsin bu kadar

        //"K" kodunu �a��r
    }
    public void GameOverMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}