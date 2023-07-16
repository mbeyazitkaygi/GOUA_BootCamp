using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

    public AudioSource musicSource;
    public AudioSource ambientSource;


    void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
            FindAnyObjectByType<AudioManager>().Play("LockedSound");
        }
    }
	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);
		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
            FindAnyObjectByType<AudioManager>().Play("PauseMenuMusic");
            musicSource.volume = 0f;
			ambientSource.volume = 0f;
        }
        else
		{
			Time.timeScale = 1f;
            FindAnyObjectByType<AudioManager>().Stop("PauseMenuMusic");
            musicSource.volume = 1f;
			ambientSource.volume = 1f;
        }
    }
	public void Retry ()
	{
		Toggle();
		//Bir alt satır silinirse retry button çalışmıyor.Silinmemeli!!
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        WaveSpawner.EnemiesAlive = 0;                                       //needed for resetting enemy counter on the screen, thus game can acknowledge that there are no enemies left on screen when quitting/retrying/going to next level
        FindAnyObjectByType<AudioManager>().Play("UIClickSound");
    }

    public void Menu ()
	{
		Toggle();
		//Alt satırdakiler silinirse menu button çalışmıyor.Silinmemeli!!
		sceneFader.FadeTo(menuSceneName);
        WaveSpawner.EnemiesAlive = 0;                                       //needed for resetting enemy counter on the screen, thus game can acknowledge that there are no enemies left on screen when quitting/retrying/going to next level
        FindAnyObjectByType<AudioManager>().Play("UIClickSound");
    }

}