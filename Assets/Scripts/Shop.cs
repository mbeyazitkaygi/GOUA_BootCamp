using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint cannonTurret;
    public TurretBlueprint wizardTurret;
    public TurretBlueprint poisonTurret;
    public TurretBlueprint ballistaTurret;
    public TurretBlueprint archerTurret;

    private Node nodeScript;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(cannonTurret);
        FindAnyObjectByType<AudioManager>().Play("MuteButtonSound");
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(wizardTurret);
        FindAnyObjectByType<AudioManager>().Play("MuteButtonSound");
    }

    public void SelectArcherTurret()
    {
        buildManager.SelectTurretToBuild(archerTurret);
        FindAnyObjectByType<AudioManager>().Play("MuteButtonSound");
    }

    public void SelectBallistaTurret()
    {
        buildManager.SelectTurretToBuild(ballistaTurret);
        FindAnyObjectByType<AudioManager>().Play("MuteButtonSound");
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(poisonTurret);
        FindAnyObjectByType<AudioManager>().Play("MuteButtonSound");
    }
}