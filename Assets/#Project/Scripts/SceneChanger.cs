using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    void Update()
    {
    }

    public void Load()
    {
        int index = SceneManager.GetActiveScene().buildIndex; //charge l'index de scène suivante o/ et après on load la scène
        SceneManager.LoadScene(index + 1);
        //Debug.Log("ok I'm in");


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
