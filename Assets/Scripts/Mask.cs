public abstract class Mask
{
    // The mask's own row
    protected int row;

    // The mask's own column
    protected int column;

    public Mask(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    // Activates the masks's special function
    public abstract void Activate(Board board);
}