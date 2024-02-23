using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destroyer : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public int scoreToUnlockNextScene  = 100; // Skorun ulaşması gereken eşik değeri
    public int scoreToUnlockNextScene2 = 150;
    int currentScore;

    void Start()
    {
        currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        currentScoreText.text = currentScore.ToString(); // Skoru göster
        UnlockNextSceneIfScoreReached(); // Skor ulaşıldıysa sonraki sahneyi kontrol et
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            AddScore();
            UnlockNextSceneIfScoreReached(); // Skor ulaşıldıysa sonraki sahneyi kontrol et
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

    void UnlockNextSceneIfScoreReached()
    {
        if (currentScore >= scoreToUnlockNextScene)
        {
            PlayerPrefs.SetInt("IsSecondSceneUnlocked", 1); // İkinci sahnenin kilidini aç
        }
    }

    void UnlockNextSceneIfScoreReached2()
    {
        if (currentScore >= scoreToUnlockNextScene2)
        {
            PlayerPrefs.SetInt("IsSecondSceneUnlocked2", 1); // İkinci sahnenin kilidini aç
        }
    }
}
