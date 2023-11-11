using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    int currentScene = 0;
    // Start is called before the first frame update

    public void LoadScene(int scene)
    {
        currentScene = scene;
        //Debug.Log("loading scene with the number " + scene);
        SceneManager.LoadScene(scene);
    }
    public void LoadScene(string scene)
    {       
        SceneManager.LoadScene(scene);
        //Debug.Log("loading scene with the name " + scene);
    }
    //public void LoadNextScene()
    //{
    //    //Debug.Log("loading next scene");
    //    currentScene++;
    //    SceneManager.LoadScene(currentScene);
    //}
    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
