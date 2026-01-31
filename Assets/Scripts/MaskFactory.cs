using UnityEngine;

public class MaskFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject maskPrefab;

    public Mask CreateMaskOfType(char type, int row, int column)
    {
        // TODO add mask subclasses
        switch(type)
        {
            case 'S':
                GameObject silverMask = Instantiate(maskPrefab, new Vector2(row, column), Quaternion.identity);
                silverMask.AddComponent<SilverMask>();
                silverMask.GetComponent<SilverMask>().Row = row;
                silverMask.GetComponent<SilverMask>().Column = column;

                return silverMask.GetComponent<SilverMask>();
            // case 'R':
            //     break;
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
            // case 'W':
            //     break;
            default:
                break;
        }

        return null;
    }
}
