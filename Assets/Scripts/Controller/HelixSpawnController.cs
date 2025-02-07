using System;
using Framework;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class HelixSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] helixRingPrefabs;

    [SerializeField] public int noOfRings = 10;
    [SerializeField] private float ringOffset = 5f;
    [SerializeField] private float _firstHelixPosY = 0;

    private void Start()
    {
        noOfRings = GameManager.CurrentLevelIdx + 5;
        
        SpawnHelixColumn();
    }

    private void SpawnHelixColumn()
    {
        for (int i = 0; i < noOfRings; i++)
        {
            if (i == 0) SpawnHelixRing(0);
            else SpawnHelixRing(Random.Range(1, helixRingPrefabs.Length-1));
        }

        SpawnHelixRing(helixRingPrefabs.Length-1);
    }

    public void SpawnHelixRing(int idx)
    {
        GameObject newRing = Instantiate(helixRingPrefabs[idx], new Vector3(transform.position.x, _firstHelixPosY, transform.position.z), Quaternion.identity);
        _firstHelixPosY -= ringOffset;
        newRing.transform.SetParent(transform);
    }

}
