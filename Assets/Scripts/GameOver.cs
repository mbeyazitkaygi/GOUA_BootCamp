using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	//MovingCamera script'ine referansta bulun

	public void Retry ()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);


        //eðer sahnede CameraStartPos veya CameraEndPos objeleri var mý yok mu bunu kontrol etsin, null'sa return etsin bu kadar

        //"K" kodunu çaðýr
    }

}