using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlider : MonoBehaviour
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

    // Este m�todo pode ser chamado para salvar a posi��o do Slider
    public void SalvarPosicaoDoSlider()
    {
        // Salva o valor atual do Slider no PlayerPrefs
        PlayerPrefs.SetFloat("SliderValue", meuSlider.value);
        PlayerPrefs.Save(); // Salva os dados no PlayerPrefs
    }
}