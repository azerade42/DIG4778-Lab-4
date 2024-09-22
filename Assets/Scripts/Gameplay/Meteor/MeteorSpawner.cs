using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject bigMeteorPrefab;
    [SerializeField] private float spawnXRange = 8f;
    [SerializeField] private float spawnYPos = 7.5f;
    [SerializeField] private float delayAtStart = 1f;
    [SerializeField] private float delayBetweenSpawns = 2f;

    private int meteorCount = 1;
    private Coroutine spawningCoroutine;

    private void OnEnable()
    {
        GameManager.OnGameOver += StopSpawning;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= StopSpawning;
    }

    public void StartSpawningMeteors()
    {
        spawningCoroutine = StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(delayAtStart);

        while (!GameManager.Instance.GameOver)
        {
            if (meteorCount % 5 == 0)
            {
                SpawnMeteor(bigMeteorPrefab);
            }
            else
            {
                SpawnMeteor(meteorPrefab);
            }

            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }

    private void SpawnMeteor(GameObject meteorPrefab)
    {
        meteorCount++;
        Vector3 spawnPos = new Vector3(Random.Range(-spawnXRange, spawnXRange), spawnYPos, 0);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
    }

    private void StopSpawning()
    {
        StopCoroutine(spawningCoroutine);
    }
}
