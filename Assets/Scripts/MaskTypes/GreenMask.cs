
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class GreenMask : Mask
{
    private int[,] rotations = new int[8,2] {{-1,1}, {0,1}, {1,1}, {1,0}, {1,-1}, {0,-1}, {-1,-1}, {-1,0}};
    public override void Activate(Board board)
    {
        List<Vector2Int> positions = new List<Vector2Int>();
        List<Mask> masks = new List<Mask>();

        for (int i = 0; i < rotations.Length; i++)
        {
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
            Debug.Log(cord);
        }
        
        
    }
}
