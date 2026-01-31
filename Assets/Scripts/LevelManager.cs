using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(LevelManager).ToString());
                    _instance = singleton.AddComponent<LevelManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return _instance;
        }
    }

    private List<MoveType> moves = new();
    private int currentMove = 0;

    public int CurrentMoveNumber
    {
        get => currentMove;
    }

    public MoveType CurrentMoveType
    {
        get => moves[currentMove];
    }

    public enum MoveType
    {
        Swap,
        Trigger
    }

    private List<Mask> masksToSwap = new();

    public void AddSwap(Mask mask)
    {
        masksToSwap.Add(mask);
        
        if (masksToSwap.Count > 1)
        {
            Board.Instance.SetMaskAt(masksToSwap[0].Row, masksToSwap[0].Column, masksToSwap[1].gameObject);
            Board.Instance.SetMaskAt(masksToSwap[1].Row, masksToSwap[1].Column, masksToSwap[0].gameObject);

            Board.Instance.AnimateMoveMaskFromTo(masksToSwap[0].Row, masksToSwap[0].Column, masksToSwap[1].Row, masksToSwap[1].Column);
            
            masksToSwap = new();

        }
    }

    public void LoadLevelFromTextAsset(TextAsset textAsset)
    {
        currentMove = 0;
        moves = new();

        foreach (char move in textAsset.text.ToCharArray())
        {
            if (move == 'T')
            {
                moves.Add(MoveType.Trigger);
            }
            else if (move == 'S')
            {
                moves.Add(MoveType.Swap);
            }
        }
    }

    public void NextMove()
    {
        currentMove++;
        if (currentMove >= moves.Count)
        {
            GameManager.Instance.NextLevel();
        } else
        {
            Debug.Log("On move " + (currentMove + 1) + ": " + CurrentMoveType);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
