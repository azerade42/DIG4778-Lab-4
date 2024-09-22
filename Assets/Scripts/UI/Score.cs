using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    public int currentScore;
    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        currentScore = 0;
    }
    private void OnEnable()
    {
        Meteor.OnMeteorDestroyed += addScore;
    }

    private void OnDisable()
    {
        Meteor.OnMeteorDestroyed -= addScore;
    }

    private void addScore(int i)
    {
        currentScore += i;
    }

    private void Update()
    {
        if (scoreDisplay.gameObject.activeSelf)
        {
            string scoreText = currentScore.ToString();
            scoreDisplay.text = $"Score: {scoreText}";
        }
    }
}
