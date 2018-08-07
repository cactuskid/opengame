using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelCube : MonoBehaviour {

    private static List<GameObject> cubes;
    private float timeToFade = 2.0f;
    private Color alphaColor;
    private int cubeSize;
    private bool fadeOut = false;

	void Start () {

        cubes = new List<GameObject>();

        cubeSize = 3;

        for (int a = 0; a < 4; a+= 1)

            for (int b = 0; b < 4; b += 1)

                for (int i = 0; i < cubeSize; i++)
                    for (int j = 0; j < cubeSize; j++)
                        for (int k = 0; k < cubeSize; k++)
                        {
                        GameObject cube = VoxelTools.MakeCube(10*a + i, 1 + j, 10* b + k);
                            cubes.Add(cube);

                            cube.AddComponent<Rigidbody>();
                            cube.GetComponent<Rigidbody>().mass = 5;
                            cube.GetComponent<Rigidbody>().useGravity = true;
                            cube.GetComponent<Rigidbody>().isKinematic = false;
                            cube.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");



                        }
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (GameObject x in cubes){

                float speed = 30;
                x.GetComponent<Rigidbody>().AddRelativeForce(5*Random.onUnitSphere * speed, ForceMode.Impulse);


            }

            fadeOut = true;
        }


        if (fadeOut){

            foreach (GameObject x in cubes)
            {

                alphaColor = x.GetComponent<MeshRenderer>().material.color;
                alphaColor.a = 0;

                x.GetComponent<MeshRenderer>().material.color = Color.Lerp(x.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);

                if (x.GetComponent<MeshRenderer>().material.color.a < 0.01)
                { 
                    fadeOut = false;
                    Destroy(x);
                }
                
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R)){
            foreach (GameObject x in cubes)
            {Destroy(x); }
            fadeOut = false;
            Start();
        }

     
    }


	
}
