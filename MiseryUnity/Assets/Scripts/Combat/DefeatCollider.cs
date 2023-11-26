using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatCollider : MonoBehaviour
{
    [SerializeField] Misery miseryScript;
    [SerializeField] EgoMap egoMapScript;

    void LoseInvasion()
    {
        foreach (GameObject unit in egoMapScript.activeUnits)
        {
            Destroy(unit);
        }

        miseryScript.defeatedGhosts -= 1;
        miseryScript.occupied = false;
        Destroy(GameObject.Find("Base Invasion(Clone)"));
    }

    // Start is called before the first frame update
    void Start()
    {
        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LoseInvasion();
        }
    }
}
