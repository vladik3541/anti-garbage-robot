using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnEnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform[] spawnPoint;
    private List<GameObject> _trashOnScene = new List<GameObject>();
    private float lastSpawnTime;
    [SerializeField]private float nextSpawn = 5;
    private void OnEnable()
    {
        TrashDetect.OnSpawn += AddTrashList;
        TrashDetect.OnDestroy += RemoveTrashList;
    }
    private void OnDisable()
    {
        TrashDetect.OnSpawn -= AddTrashList;
        TrashDetect.OnDestroy -= RemoveTrashList;
    }

    private void RemoveTrashList(GameObject trash)
    {
        _trashOnScene.Remove(trash);
    }
    private void AddTrashList(GameObject trash)
    {
        _trashOnScene.Add(trash);
    }

    private void Update()
    {
        if(_trashOnScene == null) return;
        int count = _trashOnScene.Count;

        if(count > 2 && count < 6)
        {
            nextSpawn = 6;
        }
        else if(count > 5)
        {
            nextSpawn = 5;
        }
        Spawn();
    }
    private void Spawn()
    {

        if (Time.time > lastSpawnTime)
        {
            lastSpawnTime = Time.time + nextSpawn;
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);

        }
    }
}
