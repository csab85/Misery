using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOffice : MonoBehaviour
{
    private bool isInside = false; // Flag para controlar se o jogador está dentro da área

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
        // Se o jogador sair da área, redefine a flag para permitir a reprodução da música novamente ao entrar
        isInside = false;
        AudioManager.instance.PlayMusic("ThemeGame");
        AudioManager.instance.sfxSource.Stop();
    }
}
