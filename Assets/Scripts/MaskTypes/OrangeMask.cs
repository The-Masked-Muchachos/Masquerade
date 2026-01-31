using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMask : Mask
{
    // Explosion to play when a mask is destroyed
    [SerializeField]
    private GameObject explosionPrefab;

    public override string ID
    {
        get => "O";
    }
    
    public override void Activate(Board board)
    {
        Debug.Log("OrangeMask activated");

        StartCoroutine(ActivateAfterDelay(board));
    }

    private IEnumerator ActivateAfterDelay(Board board)
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(explosionPrefab, new Vector2(Column, -Row), Quaternion.identity);

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
