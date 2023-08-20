using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;

    [SerializeField] private Transform platformTransform;
    private Transform _playerTransform;
    private float _spawnZ = 4;
    private float tileLength = 5;
    private float safeZone = 7;
    private int amnTilesOnScreen = 6;
    private int _lastPrefabIndex;

    private List<GameObject> _activeTiles;
    private void Start()  
    {
        Application.targetFrameRate = 60;
        _activeTiles = new List<GameObject>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTilesOnScreen; i++) 
        {
            if (i < 1)
                SpawnTile (0);
            else
                SpawnTile ();       
        }
    }
    private void Update()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        platformTransform.SetPositionAndRotation(new Vector3(0,0, _playerTransform.position.z), new Quaternion(0,0,0,0));
        if (_playerTransform.position.z - safeZone > (_spawnZ - amnTilesOnScreen * tileLength)) 
        {
            SpawnTile ();
            DeleteTile ();
        }
    }
   
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]);
        else
            go = Instantiate(tilePrefabs[prefabIndex]);
        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * _spawnZ;
        _spawnZ += tileLength;
        _activeTiles.Add (go);
        //_spawnZ -= tileLength;
        //_playerTransform.Translate(0,0,tileLength);
    }


    private void DeleteTile() 
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = _lastPrefabIndex;
        while (randomIndex == _lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        _lastPrefabIndex = randomIndex;
        return randomIndex; 
    }
}
