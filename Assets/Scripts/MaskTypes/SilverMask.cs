using UnityEngine;

public class SilverMask : Mask
{
    public override string ID
    {
        get => "S";
    }
    
    public override void Activate(Board board)
    {
        Debug.Log("SilverMask activated");
        board.SetMaskAt(Row, Column, null);
        board.AnimateRemoveMaskAt(Row, Column);
        Destroy(gameObject);
    }
}