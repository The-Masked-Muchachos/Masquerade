using UnityEngine;

public class MaskFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject silverMaskPrefab;
    [SerializeField]
    private GameObject redMaskPrefab;
    [SerializeField]
    private GameObject orangeMaskPrefab;
    [SerializeField]
    private GameObject yellowMaskPrefab;
    [SerializeField]
    private GameObject weldingMaskPrefab;

    public GameObject CreateMaskOfType(char type, int row, int column)
    {
        // TODO add mask subclasses
        switch (type)
        {
            case 'S':
                GameObject silverMask = Instantiate(silverMaskPrefab, new Vector2(column, -row), Quaternion.identity);
                silverMask.GetComponent<Mask>().Row = row;
                silverMask.GetComponent<Mask>().Column = column;

                return silverMask;
            case 'R':
<<<<<<< HEAD
                GameObject redMask = Instantiate(maskPrefab, new Vector2(row, column), Quaternion.identity);
                /*redMask.AddComponent<RedMask>();*/
=======
                GameObject redMask = Instantiate(redMaskPrefab, new Vector2(column, -row), Quaternion.identity);
>>>>>>> 9d2147455f9e826cd1c0ddb2f913f447d121e344
                redMask.GetComponent<Mask>().Row = row;
                redMask.GetComponent<Mask>().Column = column;

                return redMask;
            case 'Y':
                GameObject yellowMask = Instantiate(yellowMaskPrefab, new Vector2(column, -row), Quaternion.identity);
                yellowMask.GetComponent<Mask>().Row = row;
                yellowMask.GetComponent<Mask>().Column = column;

                return yellowMask;
            case 'O':
                GameObject orangeMask = Instantiate(orangeMaskPrefab, new Vector2(column, -row), Quaternion.identity);
                orangeMask.GetComponent<Mask>().Row = row;
                orangeMask.GetComponent<Mask>().Column = column;

                return orangeMask;
            // case 'B':
            //     break;
            // case 'G':
            //     break;
            // case 'D':
            //     break;
            // case 'P':
            //     break;
            case 'W':
                GameObject weldingMask = Instantiate(weldingMaskPrefab, new Vector2(column, -row), Quaternion.identity);
                weldingMask.GetComponent<Mask>().Row = row;
                weldingMask.GetComponent<Mask>().Column = column;

                return weldingMask;
            default:
                break;
        }

        return null;
    }
}
