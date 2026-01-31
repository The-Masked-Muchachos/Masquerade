
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MaskObj : MonoBehaviour
{
    public Mask Mask;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        float mouseX = Mouse.current.position.x.ReadValue();
        float mouseY = Mouse.current.position.y.ReadValue();
        Vector2 mousePosInWorld = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
        RaycastHit2D hit = Physics2D.Raycast(mousePosInWorld, Vector2.zero, 0f);
        
        if (hit.collider && (hit.collider.gameObject.GetInstanceID() == this.gameObject.GetInstanceID()))
        {
            Debug.Log(hit.collider.gameObject.GetInstanceID());
        }
    }

    public void OnClick()
    {
        Mask.Activate(BoardObj.Instance.board);
    }
}
