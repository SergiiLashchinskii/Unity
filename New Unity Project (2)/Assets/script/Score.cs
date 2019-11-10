using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    // Use this for initialization
    private TextMeshProUGUI tm;
    private int score;

	void Start () {
        score = 32;
        tm = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        tm.text = "Score: " + score.ToString();	
	}

    public void GetScore(int score)
    {
        this.score += score;
    }
}
