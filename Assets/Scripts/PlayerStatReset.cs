using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStatReset : MonoBehaviour
{
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        LevelSelector.levelReached = 1;
        SceneManager.LoadScene("RoomLevelSelect");
    }
}
