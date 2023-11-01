using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlider : MonoBehaviour
{
    public Slider meuSlider; // Referência ao Slider

    void Start()
    {
        // Verifica se há um valor salvo para o Slider no PlayerPrefs
        if (PlayerPrefs.HasKey("SliderValue"))
        {
            // Se houver, carrega o valor do PlayerPrefs para o Slider
            meuSlider.value = PlayerPrefs.GetFloat("SliderValue");
        }
    }

    // Este método pode ser chamado para salvar a posição do Slider
    public void SalvarPosicaoDoSlider()
    {
        // Salva o valor atual do Slider no PlayerPrefs
        PlayerPrefs.SetFloat("SliderValue", meuSlider.value);
        PlayerPrefs.Save(); // Salva os dados no PlayerPrefs
    }
}