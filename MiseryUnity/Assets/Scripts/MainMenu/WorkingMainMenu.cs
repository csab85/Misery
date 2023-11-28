using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Slider volumeSlider; // Adicionando um Slider
    private const string VolumePrefsKey = "Volume"; // Chave para salvar o valor do slider

    private void Start()
    {
        playerSctript = GameObject.Find("Misery").GetComponent<Misery>();
        // Carregar o valor salvo do slider ao iniciar
        LoadVolume();
    }

    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo);
        SceneManager.UnloadSceneAsync("MainMenu");
        AudioManager.instance.PlayMusic("ThemeGame");
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

    // Função para salvar o valor do slider
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(VolumePrefsKey, volumeSlider.value);
        PlayerPrefs.Save();
    }

    // Função para carregar o valor salvo do slider
    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey(VolumePrefsKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefsKey);
            volumeSlider.value = savedVolume;
        }
    }
}