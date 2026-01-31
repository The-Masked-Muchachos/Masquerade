using System.IO;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;


public class BoardObj : MonoBehaviour
{
    [CanBeNull] private static BoardObj _instance;

    public static BoardObj Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BoardObj>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(BoardObj).ToString());
                    _instance = singleton.AddComponent<BoardObj>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return _instance;
        }
    }

    public Board board;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
