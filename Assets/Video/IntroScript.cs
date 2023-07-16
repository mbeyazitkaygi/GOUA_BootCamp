using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button skipButton;

    private float videoDuration;
    private bool videoFinished = false;

    private void Start()
    {
        // Hide the skip button at the start
        skipButton.gameObject.SetActive(false);

        // Play the video
        videoPlayer.Play();

        // Get the video duration
        videoDuration = (float)videoPlayer.length;

        // Delay the appearance of the skip button by 5 seconds
        Invoke("ShowSkipButton", 5f);
    }

    private void ShowSkipButton()
    {
        skipButton.gameObject.SetActive(true);
    }

    public void SkipIntro()
    {
        // Only skip the intro if the video has finished playing
        if (videoFinished)
        {
            // Stop the video
            videoPlayer.Stop();

            // Load the Level01 scene
            SceneManager.LoadScene("Level01");
        }
    }

    private void Update()
    {
        // Check if the video has finished playing
        if (!videoFinished && videoPlayer.time >= videoDuration)
        {
            videoFinished = true;
        }
    }
}