using System.Collections;

public class ChunkData
{

    private int x, y, z;                            // Create 3 ints called x,y,z to store our position in our WorldData array

    // When ever our chunkData, we will send in
    // The position it will be stored in the WorldData array
    public ChunkData(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    // X,Y,Z Functions just allow us to get and set the value
    // Of our vars x,y,z because they're private
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public int Z
    {
        get { return z; }
    }

    // We will use this when renaming our chunk
    // So it is something more readable and managable
    // Instead of having them all name Chunk(clone)
    public override string ToString()
    {
        return string.Format("Chunk ( {0},{1},{2} )", x, y, z);
    }
}