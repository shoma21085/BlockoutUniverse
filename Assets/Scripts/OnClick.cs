// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public void OnClickToGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClickToEnd()
    {
        Application.Quit();
    }
}
