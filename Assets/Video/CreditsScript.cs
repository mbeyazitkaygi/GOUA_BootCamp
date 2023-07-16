using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class CreditsScript : MonoBehaviour
{
    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;
    public Button skipButton;

    private bool video1Finished = false;

    private void Start()
    {
        // Start playing video1 immediately
        videoPlayer1.Play();

        // Deactivate video2 at the start
        videoPlayer2.gameObject.SetActive(false);

        // Deactivate skipButton at the start
        skipButton.gameObject.SetActive(false);

        // Delay the appearance of the skipButton by 4 seconds
        Invoke("ActivateSkipButton", 4f);

        // Register a callback for when video2 ends
        videoPlayer2.loopPointReached += Video2EndReached;
    }

    private void ActivateSkipButton()
    {
        skipButton.gameObject.SetActive(true);
    }

    public void SkipScene()
    {
        // Only skip the scene if video1 has finished playing
        if (video1Finished)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Video2EndReached(VideoPlayer player)
    {
        // Stop videoPlayer2
        videoPlayer2.Stop();

        // Delay the scene transition by 1 second
        Invoke("TransitionToMenuScene", 0.5f);
    }

    private void TransitionToMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayVideo2()
    {
        // Stop video1
        videoPlayer1.Stop();

        // Activate video2 and play it
        videoPlayer2.gameObject.SetActive(true);
        videoPlayer2.Play();
    }

    private void Update()
    {
        // Check if video1 has finished playing
        if (!video1Finished && !videoPlayer1.isPlaying)
        {
            video1Finished = true;
        }
    }
}