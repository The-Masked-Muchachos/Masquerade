using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMask : Mask
{
    public override void Activate(Board board)
    {
        Debug.Log("YellowMask activated");

        StartCoroutine(ActivateAfterDelay(board));
    }

    private IEnumerator ActivateAfterDelay(Board board)
    {
        yield return new WaitForSeconds(0.2f);
        List<GameObject> adjacentCells = new List<GameObject>();
        if (Column > 0) adjacentCells.Add(board[Row, Column - 1]);
        if (Column < board.NumberOfColumns - 1) adjacentCells.Add(board[Row, Column + 1]);

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