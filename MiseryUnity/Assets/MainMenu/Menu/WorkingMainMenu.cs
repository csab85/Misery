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
    private GameObject PainelOpçoes;
    [SerializeField]
    private GameObject PainelSounds;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo);
    }

    public void AbrirOpçoes()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpçoes.SetActive(true);
    }

    public void FecharOpçoes()
    {
        PainelOpçoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }
    public void AbrirSongs()
    {
        PainelOpçoes.SetActive(false);
        PainelSounds.SetActive(true);
    }

    public void FecharSongs()
    {
        PainelSounds.SetActive(false);
        PainelOpçoes.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void VelocidadePersonagem()
    {
        Misery.speed = 10;

    }
}
