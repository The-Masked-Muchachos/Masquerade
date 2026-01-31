using UnityEngine;

public class SilverMask : Mask
{
    public SilverMask(int row, int column) : base(row, column)
    {
        
    }

    public override void Activate(Board board)
    {
        Debug.Log("SilverMask activated");
    }
}
