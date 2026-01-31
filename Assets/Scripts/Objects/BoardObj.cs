using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BoardObj : MonoBehaviour
{
    Board board;

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
