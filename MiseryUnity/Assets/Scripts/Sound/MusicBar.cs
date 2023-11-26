using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBar : MonoBehaviour
{
    private bool isInside = false; // Flag para controlar se o jogador est� dentro da �rea
    private string[] musicOptions = { "Bar1", "Bar2", "Bar3" }; // Nomes das m�sicas dispon�veis

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
        // Se o jogador sair da �rea, redefine a flag para permitir a reprodu��o da m�sica novamente ao entrar
        isInside = false;
        AudioManager.instance.PlayMusic("ThemeGame");
    }

    private void PlayRandomMusic()
    {
        // Escolhe aleatoriamente uma m�sica do array
        int randomIndex = Random.Range(0, musicOptions.Length);
        string randomMusic = musicOptions[randomIndex];

        // Toca a m�sica escolhida
        AudioManager.instance.PlayMusic(randomMusic);
    }
}