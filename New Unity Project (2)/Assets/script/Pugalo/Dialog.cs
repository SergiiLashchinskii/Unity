using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour {
    public TextMeshProUGUI textDisplay;
    public string[] sentenses;
    private int index;
    public float typingspeed;
    public GameObject continueBatton;
    IEnumerator Type()
    {
        foreach (char letter in sentenses[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(Type());
	}
	
    public void NextSentense()
    {
        continueBatton.SetActive(false);
        if (index < sentenses.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueBatton.SetActive(false);
        }
    }
	// Update is called once per frame
	void Update () {
        if (textDisplay.text == sentenses[index])
            continueBatton.SetActive(true);
	}
}
