using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // since 2018.3, i guess u can make a script for path that has pub meth to return the list, prefab will have empty list and each path has his own diff list of waypoints
    //config
    Waves waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;



    void Start()
    {
        waypoints = waveConfig.ReturnWaypointList();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update() {
        MoveOnPath();
    }

    // getting wave from scriptable object
    public void SetWaveInPath(Waves waveToSet) {
        this.waveConfig = waveToSet;
    }


    private void MoveOnPath() {
        if (waypointIndex <= waypoints.Count - 1) {
            var tranformPos = waypoints[waypointIndex].position; // no need for +1, it will automatically increment cz it's already there on start
            transform.position = Vector2.MoveTowards(transform.position, tranformPos, waveConfig.ReturnMoveSpeed() * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].position) {
                waypointIndex++;
            }
        }
        else {
            Destroy(gameObject);
        }
    }
}
