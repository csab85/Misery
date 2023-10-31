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
    public GameObject ally;
    public GameObject enemy;

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

        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(ally, new Vector3(Random.Range(0.5f, 8.6f), 0.5f, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(enemy, new Vector3(Random.Range(0.5f, 8.6f), 8.5f, 0), Quaternion.identity);
        }
    }

    #endregion
    //========================
}
