using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    [SerializeField] GameObject baseInvasion;
    [SerializeField] GameObject mainCamera;
    bool spawned = false;

    void SpawnBaseInvader()
    {
        GameObject.Find("Misery").GetComponent<Misery>().invading = true;

        spawned = true;

        Instantiate(baseInvasion, mainCamera.transform);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!spawned)
        {
            SpawnBaseInvader();
        }
    }
}
