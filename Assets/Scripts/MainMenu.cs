using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public void Play ()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}