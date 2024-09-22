using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;
    public static GameManager Instance { get; private set; }
    public bool GameOver { get; private set; }

    [SerializeField] MeteorSpawner meteorSpawner;
    [field: SerializeField] public PlayerController PC { get; private set; }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void OnEnable()
    {
        PC.OnDestroyed += EndGame;
    }

    private void OnDisable()
    {
        PC.OnDestroyed -= EndGame;
    }

    private void Start()
    {
        if (meteorSpawner != null)
        {
            meteorSpawner.StartSpawningMeteors();
        }
    }
    private void EndGame()
    {
        GameOver = true;
        OnGameOver?.Invoke();
    }
}
