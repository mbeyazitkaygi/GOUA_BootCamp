using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    public float delayBeforeSkip = 6f;
    public Button skipButton;
    public VideoPlayer videoPlayer;
    public AudioClip audioClip;
    
    private bool isVideoFinished;
    private bool isAudioFinished;

    private float elapsedTime;

    private AudioSource audioSource;

    private void Start()
    {
        // Hide the skip button initially
        skipButton.gameObject.SetActive(false);

        // Start playing the video
        videoPlayer.Play();

        // Start tracking the elapsed time
        elapsedTime = 0f;

        // Subscribe to video completion event
        videoPlayer.loopPointReached += OnVideoFinished;

        // Create and configure the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = audioClip;
    }

    private void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Show the skip button if enough time has passed
        if (elapsedTime >= delayBeforeSkip)
        {
            skipButton.gameObject.SetActive(true);
        }

        // Check if both video and audio have finished playing
        if ((isVideoFinished && !audioSource.isPlaying) || isAudioFinished)
        {
            // Load the 1st scene (scene index 1 in the build settings)
            SceneManager.LoadScene(1);
        }
    }

    public void SkipScene()
    {
        // Stop playing the video (optional)
        videoPlayer.Stop();

        // Stop playing the audio (optional)
        audioSource.Stop();

        // Load the 1st scene (scene index 1 in the build settings)
        SceneManager.LoadScene(1);
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Video has finished playing
        isVideoFinished = true;

        // Play the audio clip
        audioSource.Play();
    }

    private void OnAudioFinished()
    {
        // Audio has finished playing
        isAudioFinished = true;
    }
}