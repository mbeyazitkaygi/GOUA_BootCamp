using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint cannonTurret;
    public TurretBlueprint wizardTurret;
    public TurretBlueprint poisonTurret;
    public TurretBlueprint ballistaTurret;
    public TurretBlueprint archerTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(cannonTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(wizardTurret);
    }

    public void SelectArcherTurret()
    {
        Debug.Log("Archer Turret Selected");
        buildManager.SelectTurretToBuild(archerTurret);
    }

    public void SelectBallistaTurret()
    {
        Debug.Log("Ballista Turret Selected");
        buildManager.SelectTurretToBuild(ballistaTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(poisonTurret);
    }


}