using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOffice : MonoBehaviour
{
    private bool isInside = false; // Flag para controlar se o jogador est� dentro da �rea

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInside)
        {
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlayMusic("Office");
            AudioManager.instance.PlaySfx("step");
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Se o jogador sair da �rea, redefine a flag para permitir a reprodu��o da m�sica novamente ao entrar
        isInside = false;
        AudioManager.instance.PlayMusic("ThemeGame");
        AudioManager.instance.sfxSource.Stop();
    }
}
