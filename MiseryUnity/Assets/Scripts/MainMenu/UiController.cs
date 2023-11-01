using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Slider _musicSlider, _sfxslider;

    private void Awake()
    {
        _musicSlider.value = AudioManager.instance.musicSource.volume; //essas duas coisas fizeram os sliders marcarem posição
        _sfxslider.value = AudioManager.instance.sfxSource.volume;
    }
    public void ToggleMusic()
    {
        AudioManager.instance.toggleMusic();
    }
    public void ToggleSfx()
    {
        AudioManager.instance.ToggleSfx();
    }
    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }
    public void SfxVolume()
    {
        AudioManager.instance.SfxVolume(_sfxslider.value);
    }
}
