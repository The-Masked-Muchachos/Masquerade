using UnityEngine;

public class CenterBackground : MonoBehaviour
{
    public void Center()
    {
        gameObject.transform.position = 0.5f * (Vector2.zero + new Vector2(Board.Instance.NumberOfColumns - 1, -Board.Instance.NumberOfRows + 1));
        gameObject.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 5);
    }
}
