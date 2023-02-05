using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    //Scene scene;
    public void Continue()
    {
        Time.timeScale = 1;
        SceneManager.UnloadScene(gameObject.scene);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
