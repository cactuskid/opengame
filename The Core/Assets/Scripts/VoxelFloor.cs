using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelFloor : MonoBehaviour {

    public Color color = new Color(0.2F, 0.3F, 0.4F, 0.5F);

    void Start()
    {

        for (int i = 0; i < 16; i++)
            for (int j = 0; j < 16; j++)
        {
                GameObject cube = VoxelTools.MakeCube(i, 0, j, color);
                cube.AddComponent<Rigidbody>();
                cube.GetComponent<Rigidbody>().useGravity = false;
                cube.GetComponent<Rigidbody>().isKinematic = true;
        }


    }
}
