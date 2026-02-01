using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMask : Mask
{
    // Explosion to play when a mask is destroyed
    [SerializeField]
    private GameObject explosionPrefab;

    public override string ID
    {
        get => "R";
    }

    public override void Activate(Board board)
    {
        Debug.Log("RedMask activated");
        LevelManager.Instance.MoveInProgress();

        StartCoroutine(ActivateAfterDelay(board));
    }

    private IEnumerator ActivateAfterDelay(Board board)
    {
        List<GameObject> adjacentCells = new List<GameObject>();
        if (Row > 0) adjacentCells.Add(board[Row - 1, Column]);
        if (Row < board.NumberOfRows - 1) adjacentCells.Add(board[Row + 1, Column]);

        board.SetMaskAt(Row, Column, null);

        yield return new WaitForSeconds(0.1f);

        Instantiate(explosionPrefab, new Vector2(Column, -Row), Quaternion.identity);

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