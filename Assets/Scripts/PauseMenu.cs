using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}
	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);
		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
		} else
		{
			Time.timeScale = 1f;
		}
	}
	public void Retry ()
	{
		Toggle();
		//Bir alt satır silinirse retry button çalışmıyor.Silinmemeli!!
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        WaveSpawner.EnemiesAlive = 0;										//needed for resetting enemy counter on the screen, thus game can acknowledge that there are no enemies left on screen when quitting/retrying/going to next level
    }

    public void Menu ()
	{
		Toggle();
		//Alt satırdakiler silinirse menu button çalışmıyor.Silinmemeli!!
        Debug.Log("Go to menu.");
		sceneFader.FadeTo(menuSceneName);
        WaveSpawner.EnemiesAlive = 0;										//needed for resetting enemy counter on the screen, thus game can acknowledge that there are no enemies left on screen when quitting/retrying/going to next level
    }

}