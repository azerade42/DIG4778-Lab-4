using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void OnEnable()
    {

        UIManager.OnPlayerDie += ConcatenateScore;
    }

    private void OnDisable()
    {
        UIManager.OnPlayerDie -= ConcatenateScore;
    }

    public void ConcatenateScore()
    {
        string score = Score.Instance.currentScore.ToString();
        gameOverText.text = $"Game Over! \n Your Score Was: {score}";
        print(gameOverText.text);
    }
}
