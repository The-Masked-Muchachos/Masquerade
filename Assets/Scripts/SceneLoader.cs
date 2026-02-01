using System;
using System.Collections;
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
        StartCoroutine(ChangeSceneAfterDelay());
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
