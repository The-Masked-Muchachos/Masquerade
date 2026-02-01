using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{

    public string sceneName;
    private Camera cam;

    private void Awake()
    {
        this.cam = Camera.main;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
