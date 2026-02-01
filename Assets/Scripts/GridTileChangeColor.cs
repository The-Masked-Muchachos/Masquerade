using UnityEngine;

public class GridTileChangeColor : MonoBehaviour
{
    public void GoYellow()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public void GoWhite()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
