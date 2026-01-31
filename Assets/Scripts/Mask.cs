public abstract class Mask
{
    // The mask's own row
    private int row = row;

    // The mask's own column
    private int column = column;

    public Mask(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    // Activates the masks's special function
    public abstract void Activate(Board<Mask> board);
}