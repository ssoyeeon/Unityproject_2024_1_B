using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text bestscoreText;

    void OnEnable()
    {
        GameManager.OnPointChanged += UpdatePointText;
        GameManager.OnBestScoreChanged += UpdateBestText;

    }

    void OnDisable()
    {
        GameManager.OnPointChanged -= UpdatePointText;
        GameManager.OnBestScoreChanged -= UpdateBestText;

    }

    void UpdatePointText(int newPoint)
    {
        pointText.text = "Points : " + newPoint;
    }
    void UpdateBestText(int newBestScore)
    {
        bestscoreText.text = "Best Score : " + newBestScore;
    }
}
