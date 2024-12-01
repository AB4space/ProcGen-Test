using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Chuck_C2 : MonoBehaviour
{
    public static List<GameObject> GeneratedTiles = new List<GameObject>();

    [SerializeField] private GameObject tilePrefab; 

    private int radius = 13;


    // Start is called before the first frame update
    void Start()
    {

        for(int x = 0; x < radius; x++)
        {
            for(int z = 0; z < radius; z++)
            {
                GameObject tile = Instantiate(tilePrefab,
                    new Vector3(x * 1f, 0, z + 26),
                    Quaternion.identity);


            }
        }
    }
}