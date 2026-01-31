using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public abstract class Mask : MonoBehaviour
{
    private Camera cam;
    [NonSerialized]
    public int Row;
    [NonSerialized]
    public int Column;

    public void OnClick()
    {
        Activate(Board.Instance);
    }

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

        if (hit.collider && (hit.collider.gameObject.GetInstanceID() == this.gameObject.GetInstanceID()) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log(hit.collider.gameObject.GetInstanceID());

            if (LevelManager.Instance.CurrentMoveType == LevelManager.MoveType.Trigger)
            {
                Activate(Board.Instance);
                LevelManager.Instance.NextMove();
            }

            else
            {
                LevelManager.Instance.AddSwap(this);
            }
        }
    }

    // Activates the masks's special function
    public abstract void Activate(Board board);
}