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

    public GameObject rock;
    public GameObject trap;
    public GameObject spawner; 

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
    public bool obstacled = true;
    bool paintNextTile = true;

    bool firstTilePainted = false; //refers only to the path's first tile

    int rockCounter = 0;

 

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
            obstacled = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obstacle">The type of obstacle to be added</param>
    /// <param name="minimumPoint">The minimun point x and y in which the obstacles will appear (Max is the map border)</param>
    /// <param name="times">How much times the obstacle will be spawned</param>
    /// <returns></returns>
    void  AddObstacle(GameObject obstacle, Vector2 minimumPoint, int times)
    {
        Vector2 posit;

        for (int i = 0; i < times; i++)
        {
            posit.x = Random.Range(minimumPoint.x, 7);
            posit.y = Random.Range(minimumPoint.y, 7);

            Instantiate(obstacle, posit, Quaternion.identity);
            rockCounter += 1;
        }

        obstacled = true;
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

        if (voidPainted && rockCounter < 3)
        {
            AddObstacle(spawner, new Vector2(2, 6), 3);
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
