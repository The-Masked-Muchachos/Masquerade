using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BoardObj : MonoBehaviour
{
    private static BoardObj _instance;
    public Board board;
    
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

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        board = Board.FromPlaintext("Assets/Levels/temp.txt");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
