
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

            if (cord.x < 0 || cord.x > board.NumberOfColumns)
            {
                continue;
            }
            if (cord.y < 0 || cord.y > board.NumberOfRows)
            {
                continue;
            }
            
            Mask mask = board[cord.x, cord.y].GetComponent<Mask>();
            positions.Add(cord);
            masks.Add(mask);
            Debug.Log(rotations[i, 0] + "x" + rotations[i, 1] + "y  |" + cord);
        }

        Vector2Int first = positions[0];
        positions.RemoveAt(0);
        positions.Add(first);

        for (int i = 0; i < positions.Count; i++)
        {
            Vector2Int pos = positions[i];
            Mask mask = masks[i];
            Vector2Int prev = new Vector2Int(mask.Row, mask.Column);
            
            mask.Row = pos.x;
            mask.Column = pos.y;
            board.SetMaskAt(pos.x, pos.y, mask.gameObject);
            board.AnimateMoveMaskFromTo(prev.x, prev.y, pos.x, pos.y);
        }
    }
}
