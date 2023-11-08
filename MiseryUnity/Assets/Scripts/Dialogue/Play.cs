using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string nomeDaCena; // Nome da cena que voc� deseja carregar (no caso, "BaseInvader")

    public void CarregarCenaBaseInvader()
    {
        SceneManager.LoadScene(nomeDaCena); // Carrega a cena com o nome especificado
    }
}
