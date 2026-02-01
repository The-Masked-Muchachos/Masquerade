using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Mask : MonoBehaviour
{
    public abstract string ID
    {
        get;
    }
    private Camera cam;
    [NonSerialized]
    public int Row;
    [NonSerialized]
    public int Column;

    private bool hovering;
    private IEnumerator lastHover;

    [SerializeField] private Sprite maskSprite;
    [SerializeField] private Sprite arrowSprite;
    private SpriteRenderer spriteRenderer;

    public void OnClick()
    {
        Activate(Board.Instance);
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        if (hovering)
        {
            transform.Rotate(new Vector3(0, 0, Mathf.Cos(Time.time * 20) * 10f));
            transform.localScale = Vector3.one * Mathf.Cos(Time.time * 20) * 0.15f + Vector3.one;
        }
        float mouseX = Mouse.current.position.x.ReadValue();
        float mouseY = Mouse.current.position.y.ReadValue();
        Vector2 mousePosInWorld = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
        RaycastHit2D hit = Physics2D.Raycast(mousePosInWorld, Vector2.zero, 0f);

        if (hit.collider && (hit.collider.gameObject.GetInstanceID() == this.gameObject.GetInstanceID()))
        {
            LevelManager.Instance.HoverOverGridTileAt(Row, Column);

            if (!Mouse.current.leftButton.wasPressedThisFrame)
            {
                Hover();
                return;
            }
            Debug.Log(hit.collider.gameObject.GetInstanceID());

            if (LevelManager.Instance.CurrentMoveType == LevelManager.MoveType.Trigger)
            {
                Board.Instance.SaveCurrentState();

                Activate(Board.Instance);
                LevelManager.Instance.MoveInProgress();
                return;
            }

            if (LevelManager.Instance.CurrentMoveType == LevelManager.MoveType.Swap)
            {
                LevelManager.Instance.AddSwap(this);
                return;
            }
        }
    }

    private void Hover()
    {
        if (lastHover != null)
        {
            StopCoroutine(lastHover);
        }
        lastHover = StopHoveringAfterDelay();
        StartCoroutine(lastHover);
    }

    public IEnumerator StopHoveringAfterDelay()
    {
        hovering = true;

        yield return new WaitForSeconds(0.25f);
        hovering = false;
    }

    // Activates the masks's special function
    public abstract void Activate(Board board);

    public virtual void ViewMask() { spriteRenderer.sprite = maskSprite; }

    public virtual void ViewArrow() {spriteRenderer.sprite = arrowSprite; }
}