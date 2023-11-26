using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBar : MonoBehaviour
{
    private bool isInside = false; // Flag para controlar se o jogador está dentro da área
    private string[] musicOptions = { "Bar1", "Bar2", "Bar3" }; // Nomes das músicas disponíveis

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInside)
        {
            AudioManager.instance.musicSource.Stop();
            PlayRandomMusic();
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Se o jogador sair da área, redefine a flag para permitir a reprodução da música novamente ao entrar
        isInside = false;
        AudioManager.instance.PlayMusic("ThemeGame");
    }

    private void PlayRandomMusic()
    {
        // Escolhe aleatoriamente uma música do array
        int randomIndex = Random.Range(0, musicOptions.Length);
        string randomMusic = musicOptions[randomIndex];

        // Toca a música escolhida
        AudioManager.instance.PlayMusic(randomMusic);
    }
}