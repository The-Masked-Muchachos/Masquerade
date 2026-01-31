
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GreenMask : Mask
{
    public override string ID
    {
        get => "G";
    }
    
    private int[,] rotations = new int[8,2] {{-1,1}, {0,1}, {1,1}, {1,0}, {1,-1}, {0,-1}, {-1,-1}, {-1,0}};
    public override void Activate(Board board)
    {
        List<Vector2Int> positions = new List<Vector2Int>();
        List<Mask> masks = new List<Mask>();
        
        Debug.Log(rotations.GetLength(0));

        for (int i = 0; i < rotations.GetLength(0); i++)
        {
            Debug.Log(i);
            Vector2Int cord = new Vector2Int(base.Row, base.Column);
            cord.x += rotations[i, 0];
            cord.y += rotations[i, 1];

            Mask mask;
            if (board[cord.x, cord.y] == null) { mask = null; }
            else { mask = board[cord.x, cord.y].GetComponent<Mask>(); }
            
            positions.Add(cord);
            masks.Add(mask);
            Debug.Log(rotations[i, 0] + "x" + rotations[i, 1] + "y  |" + cord);
        }

        Vector2Int first = positions[0];
        positions.RemoveAt(0);
        positions.Add(first);
        
        /*Debug.Log(positions);
        Debug.Log(masks);*/

        for (int i = 0; i < positions.Count; i++)
        {
            Debug.Log(positions[i]);
        }

        for (int i = 0; i < positions.Count; i++)
        {
            Vector2Int pos = positions[i];
            Vector2Int prev;
            if (i > 0) { prev = new Vector2Int(positions[i-1].x, positions[i-1].y); }
            else {prev = new Vector2Int(positions[positions.Count-1].x, positions[positions.Count-1].y); }
            Debug.Log(prev);
            
            Mask mask = masks[i];
            if (mask != null)
            {
                mask.Row = pos.x;
                mask.Column = pos.y;
                board.SetMaskAt(pos.x, pos.y, mask.gameObject);
            }
            else
            {
                board.SetMaskAt(pos.x, pos.y, null);
            }
            
            board.AnimateMoveMaskFromTo(prev.x, prev.y, pos.x, pos.y);
        }
        
        board.SetMaskAt(Row, Column, null);
        Destroy(gameObject);
    }
}
