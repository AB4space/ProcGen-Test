using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeGenerator : MonoBehaviour
{
    public GameObject[] GreenCube;
    public GameObject[] BrownCube;


    public int GreenCubeCount = 30;
    public int BrownCubeCount = 50;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < GreenCubeCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * 7;
            pos.y = 0;
            GameObject selected = GreenCube[Random.Range(0, GreenCube.Length)];
            
            GameObject ground = Instantiate(selected, pos, selected.transform.rotation);
            ground.transform.rotation = Quaternion.Euler(-90, Random.Range(0, 360), 0);
        }
        for(int i = 0; i < BrownCubeCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * 7;
            pos.y = 0; 
            GameObject selected = BrownCube[Random.Range(1, BrownCube.Length)];
            
            GameObject ground = Instantiate(selected, pos, selected.transform.rotation);
            ground.transform.rotation = Quaternion.Euler(-90, Random.Range(0, 360), 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
          
    }
}
