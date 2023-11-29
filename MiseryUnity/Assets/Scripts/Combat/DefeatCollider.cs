using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatCollider : MonoBehaviour
{
    [SerializeField] Misery miseryScript;
    [SerializeField] EgoMap egoMapScript;

    IEnumerator LoseInvasion()
    {
        foreach (GameObject unit in egoMapScript.activeUnits)
        {
            Destroy(unit);
        }

        egoMapScript.invasionText.text = "TU PERDEU";
        egoMapScript.textFading = true;
        egoMapScript.textUnfading = false;

        yield return new WaitForSecondsRealtime(5);

        egoMapScript.unfading = true;
        egoMapScript.fading = false;

        yield return new WaitForSecondsRealtime(2);

        miseryScript.invading = false;
        miseryScript.talking = false;

        Destroy(GameObject.Find("Base Invasion(Clone)"));

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LoseInvasion();
            print("aaaa");
        }
    }
}
