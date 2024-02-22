using System.Collections;
using TMPro;
using UnityEngine;

public class GarbageDelivery : MonoBehaviour
{
    [SerializeField] private GameObject[] item;

    [SerializeField] private float delay;

    [SerializeField] private Transform[] poins;

    [Range(3f, 10f)]
    [SerializeField] private int minCountGarbage;
    [Range(3f, 10f)]
    [SerializeField] private int maxCountGarbage;
    private int indexWave;


    private bool allowSpawn = true;
    Vector3 RandomPosition()
    {
        Vector3 randomPos;

        randomPos.x = Random.Range(poins[0].position.x + 1, poins[2].position.x - 1);

        randomPos.z = Random.Range(poins[1].position.z - 1, poins[3].position.z + 1);

        randomPos.y = 14;

        return randomPos;
    }
    private IEnumerator SpawnGarbage()
    {
        allowSpawn = false;
        indexWave++;

        for (int i = 0; i < Random.Range(minCountGarbage, maxCountGarbage); i++)
        {
            Vector3 randomRotation = new Vector3(0, Random.Range(0, 360), 0);
            Quaternion randomQuaternion = Quaternion.Euler(randomRotation);
            Instantiate(item[Random.Range(0, item.Length)], RandomPosition(), randomQuaternion);
            yield return new WaitForSeconds(0.3f);
        }
        CancelInvoke();
        print("Cancel Invoke");
        yield return new WaitForSeconds(delay);
        allowSpawn = true;

    }
    private void Update()
    {
        if(allowSpawn)
        {
            StartCoroutine(SpawnGarbage());
        }
    }


}
