using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject bigMeteorPrefab;
    [SerializeField] private float spawnXRange = 8f;
    [SerializeField] private float spawnYRange = 7.5f;
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

        Vector3 PCPosition = GameManager.Instance.PC.transform.position;
        Vector3 spawnPos, moveDir;
        bool spawnOnSide = Random.Range(0,2) == 0;

        if (spawnOnSide)
        {
            int direction = Random.Range(0,2);
            float xPos = direction == 0 ? -spawnXRange : spawnXRange;
            spawnPos = new Vector3(xPos, Random.Range(-spawnYRange, spawnYRange), 0);
            moveDir = Vector3.right * (direction == 0 ? 1 : -1);
        }
        else
        {
            int direction = Random.Range(0,2);
            float yPos = direction == 0 ? -spawnYRange : spawnYRange;
            spawnPos = new Vector3(Random.Range(-spawnYRange, spawnYRange), yPos, 0);
            moveDir = Vector3.up * (direction == 0 ? 1 : -1);
        }
        
        Meteor meteor = Instantiate(meteorPrefab, spawnPos + PCPosition, Quaternion.identity).GetComponent<Meteor>();
        meteor.MoveDir = moveDir;
    }

    private void StopSpawning()
    {
        StopCoroutine(spawningCoroutine);
    }
}
