using UnityEngine;
using System.Collections;
using System.Collections.Generic; // For List class;

public class Chunk
{

    // Size of the Chunk
    public int sizeX = 50;
    public int sizeY = 30;
    public int sizeZ = 50;

    // Declare the 3D block Array
    public int[,,] blocksArray;


    // Initialize the block array
    public void Initialize()
    {
        blocksArray = new int[sizeX, sizeY, sizeZ];
    }
}