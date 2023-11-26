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

    public Misery playerSctript;
    
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo); 
        playerSctript.talking = true;
        SceneManager.UnloadSceneAsync("MainMenu"); //descarrega a cena
        AudioManager.instance.PlayMusic("ThemeGame"); //faz com que toque a próxima música quando aperta o play

        playerSctript.talking = false;
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

    private void Start()
    {
        playerSctript = GameObject.Find("Misery").GetComponent<Misery>();
    }
}
