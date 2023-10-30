using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EgoMap : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public Tilemap egoTilemap;
    public Tile egoVoid;
    public Tile egoPath;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //Size
    public Vector2 mapSize;

    //Paint speed
    public float voidPaintSpeed;
    public float pathPaintSpeed;

    //Position
    Vector3Int actualPosition = new Vector3Int(0, 0, 0);
    Vector3Int newPosition = new Vector3Int(0, 0, 0);

    //Functions progress
    public bool voidPainted = false;
    public bool pathPainted = true;
    bool paintNextTile = true;

    bool firstTilePainted = false; //refers only to the path's first tile

    //Function values
    int none = 0;
    int right = 1;
    int left = -1;
    int up = 2;

    int[] directions = {1, -1, 2};
    public List<int> path;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Paints a floor the size specified by mapSize
    /// </summary>
    /// <returns></returns>
    IEnumerator PaintVoid()
    {
        if (actualPosition.y <= (mapSize.y - 1))
        {
            egoTilemap.SetTile(actualPosition, egoVoid);
            paintNextTile = false;

            if (actualPosition.x >= (mapSize.x - 1))
            {
                actualPosition.x = 0;
                actualPosition.y += 1;
            }

            else
            {
                actualPosition.x += 1;
            }

            yield return new WaitForSecondsRealtime(1 / voidPaintSpeed);
            paintNextTile = true;
        }

        else
        {
            voidPainted = true;
            pathPainted = false;
        }
    }

    IEnumerator PaintPath()
    {
        //choose first tile
        if (!firstTilePainted)
        {
            actualPosition.y = 0;
            actualPosition.x = (int)(mapSize.x / 2);

            newPosition = actualPosition;

            firstTilePainted = true;
        }

        //paint tile
        if (egoTilemap.GetTile(actualPosition) != egoPath)
        {
            egoTilemap.SetTile(actualPosition, egoPath);
            paintNextTile = false;
        }

        //if got to the last tile
        if (actualPosition.y == (mapSize.y - 1))
        {
            pathPainted = true;
            path.Add(none);
            return;
        }

        //get random tile
        if (firstTilePainted)
        {
            int direction = directions[Random.Range(0, 3)];

            if (direction == up)
            {
                newPosition.y += 1;
            }

            if (direction == left)
            {
                newPosition.x -= 1;
            }

            if (direction == right)
            {
                newPosition.x += 1;
            }

            //check if position is okay
            if (newPosition.x < mapSize.x && newPosition.x >= 0 && newPosition.y < mapSize.y && newPosition.y >= 0)
            {
                if (egoTilemap.GetTile(newPosition) != egoPath) //free slot
                {
                    actualPosition = newPosition;
                    path.Add(direction);
                    yield return new WaitForSecondsRealtime(1 / pathPaintSpeed);
                    paintNextTile = true;
                }

                if (egoTilemap.GetTile(newPosition) == egoPath)
                {
                    newPosition = actualPosition;
                    paintNextTile = true;
                }
            }

            else
            {
                newPosition = actualPosition;
                paintNextTile = true;
            }
        }
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        
    }

    //Update
    void Update()
    {
        if (!voidPainted && paintNextTile)
        {
            StartCoroutine(PaintVoid());
        }

        if (!pathPainted && paintNextTile)
        {
            StartCoroutine(PaintPath());
        }
    }

    #endregion
    //========================
}
