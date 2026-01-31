using UnityEngine;

public class SilverMask : Mask
{
    // The mask's own row
    public int Row;

    // The mask's own column
    public int Column;
    
    public override void Activate(Board board)
    {
        Debug.Log("SilverMask activated");
        board.RemoveMaskAt(Row, Column);
    }
}