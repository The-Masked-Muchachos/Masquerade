using System.Collections.Generic;
using System.IO;

public class Board
{
    // All the masks currently on the board
    private Mask[,] currentState;

    // Previous board states for undoing
    private Stack<Mask[,]> pastStates;

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
    public Mask this[int row, int column] {
        get => currentState[row, column];
        private set => currentState[row, column] = value;
    }

    // Creates a new empty board
    private Board(int rows, int columns) {
        pastStates = new Stack<Mask[,]>();
        currentState = new Mask[rows, columns];
    }

    // Creates a new board using a file
    public static Board FromPlaintext(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            List<char[]> masks = new List<char[]>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                char[] cells = line.ToCharArray();
                masks.Add(cells);
            }

            int rows = masks.Count;
            int columns = masks[0].Length;

            Board board = new Board(rows, columns);
            for(int row = 0; row < rows; row++) {
                for(int column = 0; column < columns; column++)
                {
                    board[row, column] = MaskFactory.CreateMaskOfType(masks[row][column], row, column);
                }
            }

            return board;
        }
    }

    // Undoes to a previous board state
    public void Undo()
    {

    }

    // Sets the value of a cell in the currentState
    private void setMaskAt(int row, int column, Mask? mask)
    {
        currentState[row, column] = mask;
    }

    // Remove an existing mask from a cell
    public void RemoveMaskAt(int row, int column)
    {
        setMaskAt(row, column, null);
        
        //TODO: Play remove mask animation
    }

    // Add a mask to an empty cell
    public void AddMaskAt(int row, int column, Mask mask)
    {
        setMaskAt(row, column, mask);
        
        //TODO: Play mask on animation
    }

    // Change one mask into another
    public void ReplaceMaskAt(int row, int column, Mask mask)
    {
        setMaskAt(row, column, mask);
        
        //TODO: Play new mask on animation
    }

    // Move mask from one cell to another
    public void MoveMaskFromTo(int fromRow, int fromColumn, int toRow, int toColumn)
    {
        Mask originalMask = currentState[fromRow, fromColumn];
        
        setMaskAt(fromRow, fromColumn, null);
        setMaskAt(toRow, toColumn, originalMask);
        
        //TODO: Animation
        
    }

    // Swap two masks from different cells
    public void SwapMasksAt(int row1, int column1, int row2, int column2)
    {
        Mask originalMask = currentState[row1, column1];
        Mask otherMask = currentState[row2, column2];
        
        setMaskAt(row1, column1, otherMask);
        setMaskAt(row2, column2, originalMask);
        
        //TODO: Animation
    }
}
