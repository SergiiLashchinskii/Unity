using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheck : MonoBehaviour
{
    void Start()
    {
        CoinCongrats.SetActive(false);
    }
    public GameObject CoinCongrats;
    void Update()
    {
        if (!GameObject.FindWithTag("Coin"))
        {
            CoinCongrats.SetActive(true);
        }
    }
}
