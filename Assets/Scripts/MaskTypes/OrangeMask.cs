using System.Collections.Generic;
using UnityEngine;

public class OrangeMask : Mask
{
    public override void Activate(Board board)
    {
        Debug.Log("OrangeMask activated");

        List<GameObject> adjacentCells = new List<GameObject>();
        if (Column > 0) adjacentCells.Add(board[Row, Column - 1]);
        if (Column < board.NumberOfColumns - 1) adjacentCells.Add(board[Row, Column + 1]);
        if (Row > 0) adjacentCells.Add(board[Row - 1, Column]);
        if (Row < board.NumberOfRows - 1) adjacentCells.Add(board[Row + 1, Column]);
        if (Column > 0 && Row > 0) adjacentCells.Add(board[Row - 1, Column - 1]);
        if (Column > 0 && Row < board.NumberOfRows - 1) adjacentCells.Add(board[Row + 1, Column - 1]);
        if (Column < board.NumberOfColumns - 1 && Row > 0) adjacentCells.Add(board[Row - 1, Column + 1]);
        if (Column < board.NumberOfColumns - 1 && Row < board.NumberOfRows - 1) adjacentCells.Add(board[Row + 1, Column + 1]);

        board.SetMaskAt(Row, Column, null);

        foreach (GameObject cell in adjacentCells)
        {
            if (cell != null &&
                (
                    cell.GetComponent<RedMask>() != null ||
                    cell.GetComponent<OrangeMask>() != null ||
                    cell.GetComponent<YellowMask>() != null
                )
            )
            {
                cell.GetComponent<Mask>().Activate(board);
            }
        }

        board.AnimateRemoveMaskAt(Row, Column);
        Destroy(gameObject);
    }
}