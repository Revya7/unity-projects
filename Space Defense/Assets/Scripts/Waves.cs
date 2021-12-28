using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class Waves : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float randomFactor = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int numberOfEnemies = 5;

    // List<Transform> waveWayPoints; doing this do not reset the list when the game is reset

    public GameObject ReturnEnemeyPrefab() { return enemyPrefab; }


    public List<Transform> ReturnWaypointList() {

        List<Transform> waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform) {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }
    public float ReturnTimeBtwSpawn() { return timeBetweenSpawn; }
    public float ReturnRandomFactor() { return randomFactor; }
    public float ReturnMoveSpeed() { return moveSpeed; }
    public int ReturnNumOfEnemies() { return numberOfEnemies; }

}
