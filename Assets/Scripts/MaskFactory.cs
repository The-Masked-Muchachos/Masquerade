using UnityEngine;

public class MaskFactory
{
    public static Mask CreateMaskOfType(char type, int row, int column)
    {
        // TODO add mask subclasses
        switch(type)
        {
            case 'S':
                return new SilverMask(row, column);
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
