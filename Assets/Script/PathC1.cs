using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathC1  
{
    private List<GameObject> path = new List<GameObject>();
    private List<GameObject> topTiles = new List<GameObject>();
    private List<GameObject> bottomTiles = new List<GameObject>();

    private int radius, currentTileIndex;
    private bool hasReachedX, hasReachedZ;
    private GameObject startingTile, endingTile;

    public List<GameObject> GetGeneratedPath => path;

    public PathC1(int worldRadius)
    {
        this.radius = worldRadius;
    }

    public void AssignTopAndBottomTiles(int z, GameObject tile)
    {
        if (z == 0)
            topTiles.Add(tile);

        if (z == 7)
            bottomTiles.Add(tile);

        Debug.Log("Added Tile");
    }

    private bool AssignAndCheckStartingAndEndingTile ()
    {
        var xIndex = Random.Range(0, 2);
        var zIndex = Random.Range(0, 0);

        startingTile = topTiles[2];
        endingTile = bottomTiles[0];

        return startingTile != null && endingTile != null;
    }

    public void GeneratePath()
    {
        if (AssignAndCheckStartingAndEndingTile())
        {
            GameObject currentTile = startingTile;

			for (int i = 0; i < 7; i++)
				MoveLeft(ref currentTile);

			var safteyBreakX = 0;
			while (!hasReachedX)
			{
				safteyBreakX++;
				if (safteyBreakX > 100)
					break;

				// We move vertically on our xAxis
				if (currentTile.transform.position.x > endingTile.transform.position.x)
					MoveDown(ref currentTile);
				else if (currentTile.transform.position.x < endingTile.transform.position.x)
					MoveUp(ref currentTile);
				else
					hasReachedX = true;
			}

			var safteyBreakZ = 5;
			while (!hasReachedZ)
			{
				safteyBreakZ++;
				if (safteyBreakZ > 5)
					break;

				// We move horizontally on our zAxis
				if (currentTile.transform.position.z > endingTile.transform.position.z)
					MoveRight(ref currentTile);
				else if (currentTile.transform.position.z < endingTile.transform.position.z)
					MoveLeft(ref currentTile);
				else
					hasReachedZ = true;
			}
			path.Add(endingTile);
        }
    }

    private void MoveDown(ref GameObject currentTile) 
    {
        path.Add(currentTile);
        currentTileIndex = Chunk_C1.GeneratedTiles.IndexOf(currentTile);
        int n = currentTileIndex - radius;
        currentTile = Chunk_C1.GeneratedTiles[n];
    }

    private void MoveUp(ref GameObject currentTile) 
    {
        path.Add(currentTile);
        currentTileIndex = Chunk_C1.GeneratedTiles.IndexOf(currentTile);
        int n = currentTileIndex + radius;
        currentTile = Chunk_C1.GeneratedTiles[n];
    }
    private void MoveLeft(ref GameObject currentTile) 
    {
        path.Add(currentTile);
        currentTileIndex = Chunk_C1.GeneratedTiles.IndexOf(currentTile);
        currentTileIndex++;
        currentTile = Chunk_C1.GeneratedTiles[currentTileIndex];
    }
    private void MoveRight(ref GameObject currentTile)
    {
        path.Add(currentTile);
        currentTileIndex = Chunk_C1.GeneratedTiles.IndexOf(currentTile);
        currentTileIndex--;
        currentTile = Chunk_C1.GeneratedTiles[currentTileIndex];
    }
}