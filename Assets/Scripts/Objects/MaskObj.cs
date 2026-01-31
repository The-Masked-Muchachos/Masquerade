
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MaskObj : MonoBehaviour
{
    public Mask Mask;

    public void OnClick()
    {
        Mask.Activate(BoardObj.Instance.board);
    }
}
