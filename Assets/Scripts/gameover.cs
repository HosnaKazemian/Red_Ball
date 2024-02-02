using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameover : MonoBehaviour
{
    private int score;
	private string status;
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
		status = PlayerPrefs.GetString("status", "Game Over");
        TextMeshProUGUI gameOverText = GetComponent<TextMeshProUGUI>();
        gameOverText.text = status + "\n Score: " + score.ToString();
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
