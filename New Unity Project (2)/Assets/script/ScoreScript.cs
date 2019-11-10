using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization

    private TextMeshProUGUI textMesh;
    private int score = 0;
	void Start () {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
	}

    public void GetScore(int score)
    {
        this.score += score;
    }
	
	// Update is called once per frame
	void Update () {
        textMesh.text = "score: " + score;
	}
}
