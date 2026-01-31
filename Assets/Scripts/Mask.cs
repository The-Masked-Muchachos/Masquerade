public abstract class Mask(int row, int column)
{
    // The mask's own row
    private int row = row;

    // The mask's own column
    private int column = column;

    // Activates the masks's special function
    public abstract void Activate(Board<Mask> board);
}