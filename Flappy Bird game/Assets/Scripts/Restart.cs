using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private Button restartButton;

    void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        SceneManager.LoadScene("Main");
    }
}
