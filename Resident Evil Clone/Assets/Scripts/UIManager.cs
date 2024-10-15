using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI healthTxt;

    private int globalScore = 0;

    public delegate void OnZombieDie(int score);
    public static OnZombieDie zombieDeath;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        healthTxt = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        zombieDeath += UpdateScore;

        // zombieDeath?.Invoke(10);
    }
    private void UpdateScore(int score)
    {
        globalScore += score;
        scoreTxt.text = "Score: " + globalScore;
    }
}
