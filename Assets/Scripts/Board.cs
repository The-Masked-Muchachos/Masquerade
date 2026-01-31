using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private bool undo = false;

    void OnValidate()
    {
        if (undo)
        {
            Undo();
            undo = false;
        }
    }

    private static Board _instance;
    public static Board Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Board>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(Board).ToString());
                    _instance = singleton.AddComponent<Board>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return _instance;
        }
    }

    void Start()
    {
    }

    // All the masks currently on the board
    private GameObject[,] currentState;

    // Previous board states for undoing
    private Stack<string> pastStates;

    // Number of rows in the board
    public int NumberOfRows
    {
        get => currentState.GetLength(0);
    }

    // Number of columns in the board
    public int NumberOfColumns
    {
        get => currentState.GetLength(1);
    }

    // Gets the mask at a specified coordinate
    public GameObject this[int row, int column]
    {
        get => currentState[row, column];
        private set => currentState[row, column] = value;
    }

    // Creates a new board using a file
    public void LoadFromTextAsset(TextAsset textAsset)
    {
        List<char[]> maskTypes = new List<char[]>();

        foreach (string line in textAsset.text.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.None))
        {
            char[] cells = line.ToCharArray();
            maskTypes.Add(cells);
        }

        int rows = maskTypes.Count;
        int columns = maskTypes[0].Length;

        pastStates = new Stack<string>();
        currentState = new GameObject[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                currentState[row, column] = GetComponent<MaskFactory>().CreateMaskOfType(maskTypes[row][column], row, column);
            }
        }
    }

    // Saves the current state of the board before changes are made
    public void SaveCurrentState()
    {
        string savedState = "";

        for (int row = 0; row < NumberOfRows; row++)
        {
            for (int column = 0; column < NumberOfColumns; column++)
            {
                if (currentState[row, column] == null)
                {
                    savedState += '-';
                    continue;
                }
                savedState += currentState[row, column].GetComponent<Mask>().ID;
            }
            savedState += '\n';
        }

        pastStates.Push(savedState);
    }

    // Undoes to a previous board state
    public void Undo()
    {
        if (pastStates.Count == 0) return;

        string savedState = pastStates.Pop();

        List<char[]> maskTypes = new List<char[]>();

        foreach (string line in savedState.Split('\n'))
        {
            char[] cells = line.ToCharArray();
            maskTypes.Add(cells);
        }

        for (int row = 0; row < NumberOfRows; row++)
        {
            for (int column = 0; column < NumberOfColumns; column++)
            {
                Destroy(currentState[row, column]);
                currentState[row, column] = GetComponent<MaskFactory>().CreateMaskOfType(maskTypes[row][column], row, column);
            }
        }

        LevelManager.Instance.LastMove();
    }

    // Checks if all masks have been cleared
    public bool IsComplete()
    {
        foreach (GameObject mask in currentState)
        {
            if (mask != null) return false;
        }

        return true;
    }

    // Sets the value of a cell in the currentState
    public void SetMaskAt(int row, int column, GameObject? mask)
    {
        currentState[row, column] = mask;
    }

    // Remove an existing mask from a cell
    public void AnimateRemoveMaskAt(int row, int column)
    {
        //TODO: Play remove mask animation
    }

    // Add a mask to an empty cell
    public void AnimateAddMaskAt(int row, int column, GameObject mask)
    {

        //TODO: Play mask on animation
    }

    // Change one mask into another
    public void AnimateReplaceMaskAt(int row, int column, GameObject mask)
    {

        //TODO: Play new mask on animation
    }

    // Move mask from one cell to another
    public void AnimateMoveMaskFromTo(int fromRow, int fromColumn, int toRow, int toColumn)
    {
        GameObject mask = currentState[toRow, toColumn];

        //TODO: Animation
        // IEnumerator GlideToPosition(GameObject mask, Vector2 from, Vector2 to)
        // {
        //     mask.transform.position = from;
        //     Vector2 displacement = to - from;
            
        //     for (float i = 0; i < 1; i += 0.01f)
        //     {
        //         mask.transform.position = from + displacement * i;
        //         yield return null;
        //     }

        //     mask.transform.position = to;
        // }




    }

    // Swap two masks from different cells
    public void AnimateSwapMasksAt(int row1, int column1, int row2, int column2)
    {
        Mask mask1 = currentState[row1, column1].GetComponent<Mask>();
        Mask mask2 = currentState[row2, column2].GetComponent<Mask>();

        IEnumerator GlideToPosition(GameObject mask, Vector2 from, Vector2 to)
        {
            mask.transform.position = from;
            Vector2 displacement = to - from;
            
            for (float i = 0; i < 1; i += 0.01f)
            {
                mask.transform.position = from + displacement * i;
                yield return null;
            }

            mask.transform.position = to;
        }

        //TODO: Animation
        // mask1.gameObject.transform.position = new Vector2(mask1.Column, -mask1.Row);
        // mask2.gameObject.transform.position = new Vector2(mask2.Column, -mask2.Row);

        StartCoroutine(GlideToPosition(mask1.gameObject, mask1.gameObject.transform.position, new Vector2(mask1.Column, -mask1.Row)));
        StartCoroutine(GlideToPosition(mask2.gameObject, mask2.gameObject.transform.position, new Vector2(mask2.Column, -mask2.Row)));
    }
}
