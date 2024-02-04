using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destroyer : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    int currentScore;

    void Start()
    {
        currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            AddScore();
        }

        if (other.CompareTag("Road"))
        {
            Destroy(other.gameObject);
        }
    }

    public void AddScore()
    {
        currentScore++;
        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
        }

        SetScore();
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }
}
