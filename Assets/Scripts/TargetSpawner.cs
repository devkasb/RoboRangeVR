using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] targetPrefabs;
    public float spawnInterval = 0.5f;
    public float randomScale;
    public float randomHeight;

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnTarget), 1f, spawnInterval);
    } 

    void SpawnTarget()
    {
        int randomIndex = Random.Range(0, targetPrefabs.Length);
        GameObject selectedTarget = targetPrefabs[randomIndex];

        int randomObject = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomObject];
        Vector3 direction;

        if (spawnPoint.position.x < 0)
        {
            direction = Vector3.right;
        } else
        {
            direction = Vector3.left;
        }

        randomScale = Random.Range(0.5f, 2f);
        randomHeight = Random.Range(1f, 4f);

        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.y = randomHeight;

        GameObject spawnedTarget = Instantiate(
            selectedTarget,
            spawnPosition,
            spawnPoint.rotation
        );

        spawnedTarget.transform.localScale = new Vector3 (
            randomScale,
            randomScale,
            randomScale
        );

        TargetMovement movement = spawnedTarget.GetComponent<TargetMovement>();
        movement.direction = direction;
    }
}
