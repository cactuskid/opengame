using System.Collections;

public class WorldData
{

    private int chunkWidth = 100, chunkHeight = 100, chunkDepth = 100;        // The dimensions of each chunk in blocks, so each chunk is 32 blocks in width and depth but 128 blocks in height
    private int chunksX = 10, chunksY = 10, chunksZ = 1;                        // How many chunks we want to generate in the world along each axis

    public ChunkData[,,] chunks;                                            // And array of our chunks so we can keep track of them

    public const int BottomChunkBorderRow = 0, LeftChunkBorderColumn = 0;

    public void InitChunkGrid()
    {
        // Lets initialize our array where our chunk data will be stored
        chunks = new ChunkData[chunksX, chunksY, chunksZ];

        // Our for loops so we can iterate through and set our chunk
        // Position in the array
        for (int x = LeftChunkBorderColumn; x <= RightChunkBorderColumn; x++)
        {
            for (int y = BottomChunkBorderRow; y <= TopChunkBorderRow; y++)
            {
                for (int z = 0; z < chunksZ; z++)
                {
                    // Create a new set of ChunkData at x,y,z
                    chunks[x, y, z] = new ChunkData(x, y, z);
                }
            }
        }
    }

    // Chunk width,height,depth Functions just allow us
    // To get and set the value of our vars because they're private
    public int ChunkWidth
    {
        get { return chunkWidth; }
        set { chunkWidth = value; }
    }

    public int ChunkHeight
    {
        get { return chunkHeight; }
        set { chunkHeight = value; }
    }

    public int ChunkDepth
    {
        get { return chunkDepth; }
        set { chunkDepth = value; }
    }

    // Chunks X,Y,Z Functions just allow us
    // To get and set the value of our vars because they're private
    public int ChunksX
    {
        get { return chunksX; }
        set { chunksX = value; }
    }

    public int ChunksY
    {
        get { return chunksY; }
        set { chunksY = value; }
    }

    public int ChunksZ
    {
        get { return chunksZ; }
        set { chunksZ = value; }
    }

    public int TopChunkBorderRow
    {
        get { return chunksY - 1; }
    }

    public int RightChunkBorderColumn
    {
        get { return chunksX - 1; }
    }
}