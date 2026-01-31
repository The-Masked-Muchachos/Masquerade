using System.Collections.Generic;
using UnityEngine;

public class RedMask : Mask
{
    public override void Activate(Board board)
    {
        Debug.Log("RedMask activated");

        List<GameObject> adjacentCells = new List<GameObject>();
        if (Row > 0) adjacentCells.Add(board[Row - 1, Column]);
        if (Row < board.NumberOfRows - 1) adjacentCells.Add(board[Row + 1, Column]);

        board.SetMaskAt(Row, Column, null);

        foreach (GameObject cell in adjacentCells)
        {
            if (cell == null) continue;
            if (
                cell.GetComponent<RedMask>() != null ||
                cell.GetComponent<OrangeMask>() != null ||
                cell.GetComponent<YellowMask>() != null
            )
            {
                cell.GetComponent<Mask>().Activate(board);
            }
            else
            {
                board.SetMaskAt(cell.GetComponent<Mask>().Row, cell.GetComponent<Mask>().Column, null);
                Destroy(cell);
            }
        }

        board.AnimateRemoveMaskAt(Row, Column);
        Destroy(gameObject);
    }
}