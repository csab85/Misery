using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSong : MonoBehaviour
{
    private bool isInside = false; // Flag para controlar se o jogador est� dentro da �rea
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInside)
        {
            AudioManager.instance.PlaySfx("door_open");
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Se o jogador sair da �rea, redefine a flag para permitir a reprodu��o da m�sica novamente ao entrar
        isInside = false;
        AudioManager.instance.PlaySfx("door_close");
        //AudioManager.instance.sfxSource.Stop();
    }
}
