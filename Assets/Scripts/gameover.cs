using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameover : MonoBehaviour
{
    private int score = 0;
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        TextMeshProUGUI gameOverText = GetComponent<TextMeshProUGUI>();
        gameOverText.text = "GAME OVER\n Score: " + score.ToString();
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
