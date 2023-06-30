using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TMP_Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;

    void OnEnable()                         //needed for resetting enemy counter on the screen, thus game can acknowledge that there are no enemies left on screen when quitting/retrying/going to next level
    {
        EnemiesAlive = 0;
    }

    void Update()
    {
        //if (spawnPoint == null || waveCountdownText == null)//c              ****BU KOD NORMALDE YOKTU ARADA EKLENMİŞ OLABİLİR.
        //{
        //    return;
        //}

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }


        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }


    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            Debug.Log("Wave cleared!");
            this.enabled= false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        //if (spawnPoint == null)//c                                          ****BU KOD NORMALDE YOKTU ARADA EKLENMİŞ OLABİLİR.
        //{
        //    // Nesne yok edildi, ilgili işlemleri yapabilirsiniz.
        //    return;
        //}
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
