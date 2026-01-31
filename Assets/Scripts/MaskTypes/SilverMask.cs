using UnityEngine;

public class SilverMask : Mask
{
    // The mask's own row
    
    public override void Activate(Board board)
    {
        Debug.Log("SilverMask activated");
        board.SetMaskAt(Row, Column, null);
        board.AnimateRemoveMaskAt(Row, Column);
        Destroy(gameObject);
    }
}