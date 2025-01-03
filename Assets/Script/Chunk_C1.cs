using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk_C1 : MonoBehaviour
{
    public static List<GameObject> GeneratedTiles = new List<GameObject>();

    [SerializeField] private GameObject tilePrefab; 

    private int radius = 13;


    // Start is called before the first frame update
    void Start()
    {
        PathC1 pathGenerator = new PathC1(radius);

        for(int x = 0; x < radius; x++)
        {
            for(int z = 0; z < radius; z++)
            {
                GameObject tile = Instantiate(tilePrefab,
                    new Vector3(x * 1f, 1, z + 26),
                    Quaternion.identity);

                GeneratedTiles.Add(tile);
                pathGenerator.AssignTopAndBottomTiles(z, tile);
            }
        }

        //World Generated
        pathGenerator.GeneratePath();

        foreach(var pObject in pathGenerator.GetGeneratedPath)
        {
            pObject.SetActive(false);
        }
    }
}