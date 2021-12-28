using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawn : MonoBehaviour
{

    [SerializeField] List<Waves> waveList;
    [SerializeField] int startingWaveIndex = 0;
    [SerializeField] bool loopWaves = false;

    IEnumerator Start()
    {
        do {
            yield return StartCoroutine(LoadAllWaves());
        } while (loopWaves);

    }

    void Update()
    {
        
    }


    private IEnumerator LoadAllWaves() {
        for(int i = startingWaveIndex; i < waveList.Count; i++) {
            var currentWave = waveList[i];
            yield return StartCoroutine(SpawnAllEnemiesAndWaves(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesAndWaves(Waves wave) {
        for (int i = 0; i < wave.ReturnNumOfEnemies(); i++) {
            var NewEnemySpawn = Instantiate(wave.ReturnEnemeyPrefab(), wave.ReturnWaypointList()[0].position, Quaternion.identity);
            NewEnemySpawn.GetComponent<EnemyPathing>().SetWaveInPath(wave);
            yield return new WaitForSeconds(wave.ReturnTimeBtwSpawn());
        }
    }
}
