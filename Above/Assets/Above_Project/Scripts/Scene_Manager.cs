using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : Singleton<Scene_Manager>
{
    public static int CurrentScene;
    public static string CurrentSceneName;

    // Start is called before the first frame update
    public override void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        CurrentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public static void NextScene()
    {
        if (CurrentScene != SceneManager.sceneCount)
        {
            SceneManager.LoadScene(CurrentScene + 1);

            CurrentScene++;
            CurrentSceneName = SceneManager.GetActiveScene().name;
        }
    }

}
