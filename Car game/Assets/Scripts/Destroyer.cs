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

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Obstacle")
        {
            Destroy(target.gameObject);

            AddScore();
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
