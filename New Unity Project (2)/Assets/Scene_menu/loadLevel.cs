using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadLevel : MonoBehaviour {

    public string LevelName { get; set; }


    public void LoadScene(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
