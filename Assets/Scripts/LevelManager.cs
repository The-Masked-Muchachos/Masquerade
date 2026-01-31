using System;
using System.Collections;
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
    private int? currentMove = 0;

    public int? CurrentMoveNumber
    {
        get => currentMove;
    }

    public MoveType? CurrentMoveType
    {
        get
        {
            if (currentMove == null) return null;
            return moves[(int)currentMove];
        }
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

        Debug.Log("Added mask to swap");

        if (masksToSwap.Count > 1)
        {
            Board.Instance.SaveCurrentState();
            
            int mask0OldRow = masksToSwap[0].Row;
            int mask0OldColumn = masksToSwap[0].Column;
            int mask1OldRow = masksToSwap[1].Row;
            int mask1OldColumn = masksToSwap[1].Column;

            Board.Instance.SetMaskAt(masksToSwap[0].Row, masksToSwap[0].Column, masksToSwap[1].gameObject);
            Board.Instance.SetMaskAt(masksToSwap[1].Row, masksToSwap[1].Column, masksToSwap[0].gameObject);

            masksToSwap[0].Row = mask1OldRow;
            masksToSwap[0].Column = mask1OldColumn;
            masksToSwap[1].Row = mask0OldRow;
            masksToSwap[1].Column = mask0OldColumn;

            Board.Instance.AnimateSwapMasksAt(masksToSwap[0].Row, masksToSwap[0].Column, masksToSwap[1].Row, masksToSwap[1].Column);

            masksToSwap = new();

            NextMove();
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

    public void CheckBoard()
    {
        if (Board.Instance.IsComplete())
        {
            GameManager.Instance.NextLevel();
        }
    }

    public void MoveInProgress()
    {
        StopAllCoroutines();
        StartCoroutine(NextMoveAfterDone());
    }

    public IEnumerator NextMoveAfterDone()
    {
        yield return new WaitForSeconds(0.25f);
        NextMove();
    }

    public void NextMove()
    {
        currentMove++;
        if (Board.Instance.IsComplete())
        {
            GameManager.Instance.NextLevel();
            return;
        }

        if (currentMove >= moves.Count)
        {
            currentMove = null;
            Debug.Log("Out of moves!");
            return;
        }

        Debug.Log("On move " + (currentMove + 1) + ": " + CurrentMoveType);
    }

    public void LastMove()
    {
        if (currentMove == null) currentMove = moves.Count;

        currentMove--;
        Debug.Log("On move " + (currentMove + 1) + ": " + CurrentMoveType);
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
