using UnityEngine;
using System.Collections;

public class WorldGameObject : MonoBehaviour
{

    private WorldData world = new WorldData();  // Holds all the data about our world

    public Transform chunkPrefab; // A template of a chunk
    public Transform[,,] chunkGO; // A list of our chunks coords

    void Start()
    {
        // So we start by initializing a grid for our chunks
        // In our world data script we run a function that
        // Creates a 3 dimensional array and sets the coords
        // For each Chunk
        world.InitChunkGrid();

        // After initializing our grid for our chunks
        // We can now go ahead and instantiat our chunks
        // Referencing their Transform
        CreateChunks();
    }

    private void CreateChunks()
    {
        // This will only contain the locations of our chunks
        // The actually chunk data gets stored in our ChunkData script
        chunkGO = new Transform[world.ChunksX, world.ChunksY, world.ChunksZ];

        // 3 for loops, x,y,z each increment will represent a chunk
        // We only want to go as high as the amount of chunks in our
        // World so we set the loop amount as ChunksX,ChunksY,ChunksZ
        for (int x = 0; x < world.ChunksX; x++)
        {
            for (int y = 0; y < world.ChunksY; y++)
            {
                for (int z = 0; z < world.ChunksZ; z++)
                {
                    // We get the chunk from the array located at x,y,z
                    // And store it as the current chunk we're working on
                    ChunkData curChunk = world.chunks[x, y, z];

                    // Here we create a Vector3 of where the chunk will be placed
                    // the x position on our vector3 is the current chunk's x coord multiplied
                    // By the chunk width for example if curChunk is 2 we multiply it by our ChunkWidth,
                    // Which in this case would be 32 because our chunks are 32x32x128 meaning
                    // the chunks x position would be 64, we don't need to worry about Y because
                    // Our chunk height is 1, then we do the same on the Z axis
                    Vector3 chunkInstPos = new Vector3(curChunk.X * world.ChunkWidth, 0, curChunk.Y * world.ChunkHeight);

                    // Now that we have where to we want put our chunk lets create a chunk instance
                    Transform chunkInst = Instantiate(chunkPrefab, chunkInstPos, Quaternion.identity) as Transform;

                    chunkInst.GetComponent<MeshRenderer>().material.color = GetRandomColor();

                    // After creating an instance of a chunk lets set the parent to our World GameObject
                    chunkInst.parent = transform;

                    // Lets rename the chunk to something more managable
                    // In our ChunkData script is a function called ToString
                    // This basically returns a string of the chunks position
                    // It will return something like Chunk ( 1,0,1 )
                    chunkInst.name = curChunk.ToString();

                    // Now our chunk exists lets make a reference of it's
                    // Position by adding it to our array
                    chunkGO[x, y, z] = chunkInst;
                }
            }
        }
    }

    public static Color GetRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        //make grey/sludge colors less likely
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            if (Random.Range(0, 10) > 1)
            {
                int a = Random.Range(0, 3);
                if (a == 0)
                    r = 0;
                if (a == 1)
                    g = 0;
                if (a == 2)
                    b = 0;
            }
        }

        return new Color(r, g, b);
    }
}