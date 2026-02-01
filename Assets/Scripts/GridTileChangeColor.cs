using UnityEngine;

public class GridTileChangeColor : MonoBehaviour
{
    public void GoYellow()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 0.85f);
    }

    public void GoWhite()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.85f);
    }
}
