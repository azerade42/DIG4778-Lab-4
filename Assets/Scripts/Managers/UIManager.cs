using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    [SerializeField] private List<GameObject> startupObjects;
    [SerializeField] private List<GameObject> loseConObjects;
    public static Action OnPlayerDie;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnLose;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnLose;
    }
    void Start()
    {
        for(int i = 0; i < startupObjects.Count; i++)
        {
            startupObjects[i].SetActive(true);
        }   

        for(int i = 0;i < loseConObjects.Count; i++)
        {
            loseConObjects[i].SetActive(false);
        }
    }

    public void OnLose()
    {
        for(int i = 0;i < loseConObjects.Count; i++)
        {
            loseConObjects[i].SetActive(true);
        }

        for(int i = 0; i < startupObjects.Count; i++)
        {
            startupObjects[i].SetActive(false);
        }

        OnPlayerDie.Invoke();
    }

}
