using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController yellow;
    public AnimatorOverrideController black;

    public void YellowSkin()
    {
        PlayerPrefs.SetInt("Skin", 1);
        GetComponent<Animator>().runtimeAnimatorController = yellow as RuntimeAnimatorController;
    }

    public void BlackSkin()
    {
        PlayerPrefs.SetInt("Skin", 2);
        GetComponent<Animator>().runtimeAnimatorController = black as RuntimeAnimatorController;
    }
}