using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //===========================================================================================GAME OBJECTS===============================================================================================================
    GameObject player;

    public float cameraDrift;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Misery");
    }

    // Update is called once per frame
    void Update()
    {
        float cameraX = player.transform.position.x - Input.GetAxis("Horizontal") * cameraDrift;
        float cameraY = player.transform.position.y - Input.GetAxis("Vertical") * cameraDrift;

        transform.position = new Vector3(cameraX, cameraY, -10);
    }
}
