using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkingMainMenu : MonoBehaviour
{
    [SerializeField]
    private string NomeDoLevelDeJogo;
    [SerializeField]
    private GameObject PainelMenuInicial;
    [SerializeField]
    private GameObject PainelOp�oes;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo);
    }

    public void AbrirOp�oes()
    {
        PainelMenuInicial.SetActive(false);
        PainelOp�oes.SetActive(true);
    }

    public void FecharOp�oes()
    {
        PainelOp�oes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
