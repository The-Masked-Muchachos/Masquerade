
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MaskObj : MonoBehaviour
{
    [SerializeField] private Mask mask;

    public void OnClick()
    {
        mask.Activate(BoardObj.Instance.board);
    }
}
