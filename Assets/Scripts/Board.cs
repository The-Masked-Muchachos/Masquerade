public class Board<T>
{
    // All the masks currently on the board
    private T[,] currentState;

    // Previous board states for undoing
    private Stack<T[,]> pastStates;

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
    public T this[int row, int column] {
        get => currentState[row, column];
    }

    // Undoes to a previous board state
    public void Undo();

    // Sets the value of a cell in the currentState
    private void setMaskAt(int row, int column, T mask);

    // Remove an existing mask from a cell
    public void RemoveMaskAt(int row, int column);

    // Add a mask to an empty cell
    public void AddMaskAt(int row, int column, T? mask);

    // Change one mask into another
    public void ReplaceMaskAt(int row, int column, T? mask);

    // Move mask from one cell to another
    public void MoveMaskFromTo(int fromRow, int fromColumn, int toRow, int toColumn);

    // Swap two masks from different cells
    public void SwapMasksAt(int row1, int column1, int row2, int column2);
}
