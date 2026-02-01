using UnityEngine;

public class SilverMask : Mask
{
    [SerializeField]
    private GameObject dustsplosionPrefab;
    public override string ID
    {
        get => "S";
    }
    
    public override void Activate(Board board)
    {
        Debug.Log("SilverMask activated");
        LevelManager.Instance.MoveInProgress();

        Instantiate(dustsplosionPrefab, new Vector2(Column, -Row), Quaternion.identity);

        board.SetMaskAt(Row, Column, null);

        board.AnimateRemoveMaskAt(Row, Column);
        Destroy(gameObject);
    }
}