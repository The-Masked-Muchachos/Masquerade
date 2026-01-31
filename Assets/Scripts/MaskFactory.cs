using UnityEngine;

public class MaskFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject maskPrefab;

    public GameObject CreateMaskOfType(char type, int row, int column)
    {
        // TODO add mask subclasses
        switch(type)
        {
            case 'S':
                GameObject silverMask = Instantiate(maskPrefab, new Vector2(row, column), Quaternion.identity);
                silverMask.AddComponent<SilverMask>();
                silverMask.GetComponent<Mask>().Row = row;
                silverMask.GetComponent<Mask>().Column = column;

                return silverMask;
            case 'R':
                GameObject redMask = Instantiate(maskPrefab, new Vector2(row, column), Quaternion.identity);
                /*redMask.AddComponent<RedMask>();*/
                redMask.GetComponent<Mask>().Row = row;
                redMask.GetComponent<Mask>().Column = column;

                return redMask;
            // case 'Y':
            //     break;
            // case 'O':
            //     break;
            // case 'B':
            //     break;
            // case 'G':
            //     break;
            // case 'D':
            //     break;
            // case 'P':
            //     break;
            case 'W':
                GameObject weldingMask = Instantiate(maskPrefab, new Vector2(row, column), Quaternion.identity);
                weldingMask.AddComponent<WeldingMask>();
                weldingMask.GetComponent<Mask>().Row = row;
                weldingMask.GetComponent<Mask>().Column = column;

                return weldingMask;
            default:
                break;
        }

        return null;
    }
}
