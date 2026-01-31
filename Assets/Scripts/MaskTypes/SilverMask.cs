using UnityEngine;

public class SilverMask : Mask
{
    // The mask's own row
    
    public override void Activate(Board board)
    {
        Debug.Log("SilverMask activated");
        board.RemoveMaskAt(base.Row, base.Column);
    }
}