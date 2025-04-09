using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobeGenerator : MonoBehaviour
{
    public GameObject cubePrefad;
    public int totalCubes = 10;
    public float cubeSpacing = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        GenCobe();
    }

    // Update is called once per frame
    public void GenCobe()
    {
        Vector3 myPositton = transform.position;

        GameObject firestCube = Instantiate(cubePrefad, myPositton, Quaternion.identity);

        for (int i = 1; i < totalCubes; i++)
        {
            Vector3 position = new Vector3(myPositton.x, myPositton.y, myPositton.z + (i * cubeSpacing));
            Instantiate(cubePrefad, position, Quaternion.identity);
        }
    }
}
