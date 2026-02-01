using UnityEngine;

public class Jig : MonoBehaviour
{
    private Vector2 startPosition;

    void Awake()
    {
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = startPosition + 10 * new Vector2(
            Mathf.Cos(Time.time * 3),
            Mathf.Abs(Mathf.Sin(2 * Time.time * 3))
        );

        GetComponent<RectTransform>().rotation = Quaternion.identity;

        GetComponent<RectTransform>().Rotate(new Vector3(
            0,
            0,
            - Mathf.Sin(Time.time * 3) * -8f
        ));
    }
}
