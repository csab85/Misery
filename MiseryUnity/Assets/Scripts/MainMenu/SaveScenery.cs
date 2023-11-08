using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScenery : MonoBehaviour
{
    public Slider meuSlider; // Refer�ncia ao Slider

    void Start()
    {
        // Verifica se h� um valor salvo para o Slider no PlayerPrefs
        if (PlayerPrefs.HasKey("SliderValue"))
        {
            // Se houver, carrega o valor do PlayerPrefs para o Slider
            meuSlider.value = PlayerPrefs.GetFloat("SliderValue");
        }
    }
}
