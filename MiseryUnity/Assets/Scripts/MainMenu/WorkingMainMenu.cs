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
    [SerializeField]
    private GameObject PainelSounds;

    public Misery playerSctript;
    
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo); 
        playerSctript.talking = true;
        SceneManager.UnloadSceneAsync("MainMenu"); //descarrega a cena
        AudioManager.instance.PlayMusic("ThemeGame"); //faz com que toque a pr�xima m�sica quando aperta o play

        playerSctript.talking = false;
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
    public void AbrirSongs()
    {
        PainelOp�oes.SetActive(false);
        PainelSounds.SetActive(true);
    }

    public void FecharSongs()
    {
        PainelSounds.SetActive(false);
        PainelOp�oes.SetActive(true);
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
