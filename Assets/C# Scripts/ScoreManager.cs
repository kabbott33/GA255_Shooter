using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float totalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddScore(float score)
    {
        totalScore += score;
       // Debug.Log(totalScore);
        scoreText.text = ("Score:" + totalScore);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
