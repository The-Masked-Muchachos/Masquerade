using UnityEngine;

public class WeldingMask : Mask
{
    public override string ID
    {
        get => "W";
    }

    public override void Activate(Board board)
    {
        Debug.Log("WeldingMask activated");
    }
}