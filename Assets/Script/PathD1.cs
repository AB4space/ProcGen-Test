using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathD1  
{
    private List<GameObject> path = new List<GameObject>();
    private List<GameObject> topTiles = new List<GameObject>();
    private List<GameObject> bottomTiles = new List<GameObject>();

    private int radius, currentTileIndex;
    private int tile1, currentTile1Index;
    private int tile2, currentTile2Index;
    private bool hasReachedX, hasReachedZ;
    private GameObject startingTile, endingTile;
    private GameObject startingTile2, endingTile2;

    public List<GameObject> GetGeneratedPath => path;

    public PathD1(int worldRadius)
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
        var xIndex = Random.Range(0, 7);
        var zIndex = Random.Range(0, 8);

        startingTile = topTiles[4];
        endingTile = bottomTiles[12];

        return startingTile != null && endingTile != null;
    }

    public void GeneratePath()
    {
        if (AssignAndCheckStartingAndEndingTile())
        {
            GameObject currentTile = startingTile;
            GameObject currentTile1 = endingTile;
            GameObject currentTile2 = startingTile;
            GameObject currentTile3 = startingTile;
            GameObject currentTile4 = startingTile;

            for (int i = 0; i < 4; i++)
				MoveLeft(ref currentTile);

            for (int i = 0; i < 2; i++)
				MoveDown(ref currentTile1);

			for (int i = 0; i < 8; i++)
				MoveRight(ref currentTile2);

			for (int i = 0; i < 7; i++)
				MoveLeft(ref currentTile3);

			var safteyBreakX = 0;
			while (!hasReachedX)
			{
				safteyBreakX++;
				if (safteyBreakX > 7)
					break;

				// We move vertically on our xAxis
				if (currentTile.transform.position.x > endingTile.transform.position.x)
					MoveDown(ref currentTile);
				else if (currentTile.transform.position.x < endingTile.transform.position.x)
					MoveUp(ref currentTile);
				else
					hasReachedX = true;
			}

			var safteyBreakZ = 2;
			while (!hasReachedZ)
			{
				safteyBreakZ++;
				if (safteyBreakZ > 6)
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
        currentTileIndex = Chunk_D1.GeneratedTiles.IndexOf(currentTile);
        int n = currentTileIndex - radius;
        currentTile = Chunk_D1.GeneratedTiles[n];
    }

    private void MoveUp(ref GameObject currentTile) 
    {
        path.Add(currentTile);
        currentTileIndex = Chunk_D1.GeneratedTiles.IndexOf(currentTile);
        int n = currentTileIndex + radius;
        currentTile = Chunk_D1.GeneratedTiles[n];
    }
    private void MoveLeft(ref GameObject currentTile) 
    {
        path.Add(currentTile);
        currentTileIndex = Chunk_D1.GeneratedTiles.IndexOf(currentTile);
        currentTileIndex++;
        currentTile = Chunk_D1.GeneratedTiles[currentTileIndex];
    }
    private void MoveRight(ref GameObject currentTile)
    {
        path.Add(currentTile);
        currentTileIndex = Chunk_D1.GeneratedTiles.IndexOf(currentTile);
        currentTileIndex--;
        currentTile = Chunk_D1.GeneratedTiles[currentTileIndex];
    }
}