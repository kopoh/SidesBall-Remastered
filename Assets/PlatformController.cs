using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    public Transform PlatformTransform;
    private Transform playerTransform;
    public float spawnZ = 40.7f;
    public float tileLength = 73.7f;
    public float safeZone = 20.0f;
    public int amnTilesOnScreen = 7;
    public int lastPrefabIndex = 0;

    private List<GameObject> activeTiles; 
   
    private void Start()  
    {
        Application.targetFrameRate = 60;
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

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
        PlatformTransform.SetPositionAndRotation(new Vector3(0,0, playerTransform.position.z), new Quaternion(0,0,0,0));
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength)) 
        {
            SpawnTile ();
            DeleteTile ();
        }
    }
   
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add (go);
    }


    private void DeleteTile() 
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex; 
    }
}
