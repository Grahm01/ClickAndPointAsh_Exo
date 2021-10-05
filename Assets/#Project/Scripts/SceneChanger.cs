using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    void Update()
    {
    }


    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    public void Quit()
    {
        Application.Quit();
    }

}
