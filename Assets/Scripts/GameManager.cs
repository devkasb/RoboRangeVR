using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TargetSpawner targetSpawner;
    public TurretShoot[] turrets;
    public void StartGame()
    {
        if (targetSpawner != null)
        {
            targetSpawner.StartSpawning();
        }

        foreach (var turret in turrets)
        {
            turret.StartShooting();
        } 

        Debug.Log("Turret activated");
    }
}
