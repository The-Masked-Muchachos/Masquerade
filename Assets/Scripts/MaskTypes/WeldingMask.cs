using UnityEngine;

public class WeldingMask : Mask
{
    // The mask's own row
    public int Row;

    // The mask's own column
    public int Column;
    
    public override void Activate(Board board)
    {
        Debug.Log("WeldingMask activated");
    }
}