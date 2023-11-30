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

        miseryScript.invading = false;
        miseryScript.talking = false;

        GameObject.Find("Invasion Text 1").GetComponent<Fader>().progression = 2;

        if (miseryScript.battleLvl == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LoseInvasion();
            print("aaaa");
        }
    }
}
