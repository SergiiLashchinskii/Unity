using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCheck : MonoBehaviour
{
    int Skinnumber1;
    // Start is called before the first frame update
    void Start()
    {
        Skinnumber1 = PlayerPrefs.GetInt("Skin");
    }

    // Update is called once per frame
    void Update()
    {
        if(Skinnumber1 == 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
