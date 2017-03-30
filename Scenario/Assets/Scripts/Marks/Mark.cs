using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mark : MonoBehaviour {

    private static List<Spawnmark> _spawnmarks;
    private static List<EnemySpawnmark> _eSpawnmarks;
    private static List<Landmark> _landmarks;
    private static List<EnemyLandmark> _eLandmarks;

    public static List<Spawnmark> spawnmarks {
        get {
            if (_spawnmarks == null)
                _spawnmarks = new List<Spawnmark>(FindObjectsOfType<Spawnmark>());
            return _spawnmarks;
        }
    }
    public static List<EnemySpawnmark> eSpawnmarks {
        get {
            if (_eSpawnmarks == null)
                _eSpawnmarks = new List<EnemySpawnmark>(FindObjectsOfType<EnemySpawnmark>());
            return _eSpawnmarks;
        }
    }
    public static List<Landmark> landmarks {
        get {
            if (_landmarks == null)
                _landmarks = new List<Landmark>(FindObjectsOfType<Landmark>());
            return _landmarks;
        }
    }

    public static List<EnemyLandmark> eLandmarks {
        get {
            if (_eLandmarks == null)
                _eLandmarks = new List<EnemyLandmark>(FindObjectsOfType<EnemyLandmark>());
            return _eLandmarks;
        }
    }

    protected virtual void OnDestroy() {
        print("Mark destroyed");
    }
}
