using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Board : MonoBehaviour
{
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
        LoadFromPlaintext("Assets/Levels/temp.txt");
    }

    // All the masks currently on the board
    private GameObject[,] currentState;

    // Previous board states for undoing
    private Stack<GameObject[,]> pastStates;

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
    private void LoadFromPlaintext(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            List<char[]> maskTypes = new List<char[]>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                char[] cells = line.ToCharArray();
                maskTypes.Add(cells);
            }

            int rows = maskTypes.Count;
            int columns = maskTypes[0].Length;

            pastStates = new Stack<GameObject[,]>();
            currentState = new GameObject[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    currentState[row, column] = GetComponent<MaskFactory>().CreateMaskOfType(maskTypes[row][column], row, column);
                }
            }
        }
    }

    // Undoes to a previous board state
    public void Undo()
    {

    }

    // Sets the value of a cell in the currentState
    public void SetMaskAt(int row, int column, GameObject? mask)
    {
        currentState[row, column] = mask;
    }

    // Remove an existing mask from a cell
    public void AnimateRemoveMaskAt(int row, int column)
    {
        Destroy(currentState[row, column]);

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
        GameObject originalMask = currentState[fromRow, fromColumn];

        //TODO: Animation

    }

    // Swap two masks from different cells
    public void AnimateSwapMasksAt(int row1, int column1, int row2, int column2)
    {
        GameObject originalMask = currentState[row1, column1];
        GameObject otherMask = currentState[row2, column2];

        //TODO: Animation
    }
}
