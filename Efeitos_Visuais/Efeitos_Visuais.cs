using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class Efeitos_Visuais : MonoBehaviour
{
    public float transparencia = 0;

    [SerializeField] private Controle_Emocional controleEmocional;

    public AudioSource aS;
    public AudioClip trocaEstado;
    public Light2D luzGlobalCoragem;
    public Light2D luzGlobalMedo;
    public Light2D luzGlobalNormal;

    public Image[] imagens;

    private void FixedUpdate()
    {
        Enel();
    }

    public bool Enel()
    {
        if (controleEmocional.emocaoSlider.value == 50)
        {
            AtivaTelaNormal();

            return false;
        }
        else if (controleEmocional.emocaoSlider.value == 100)
        {
            aS.clip = trocaEstado;
            aS.Play();

            AtivaTelaCoragem();

            return false;
        }
        else if (controleEmocional.emocaoSlider.value == 0)
        {
            aS.clip = trocaEstado;
            aS.Play();

            AtivaTelaMedo();

            return false;
        }

        return false;
    }

    public void AtivaTelaNormal()
    {
        luzGlobalCoragem.gameObject.SetActive(false);

        luzGlobalMedo.gameObject.SetActive(false);

        luzGlobalNormal.gameObject.SetActive(true);

        luzGlobalCoragem.intensity = 0f;

        luzGlobalMedo.intensity = 0f;
    }

    public void AtivaTelaCoragem() 
    {
        luzGlobalNormal.gameObject.SetActive(false);

        luzGlobalMedo.gameObject.SetActive(false);

        luzGlobalCoragem.gameObject.SetActive(true);

        if (luzGlobalCoragem.intensity < 1.3)
        {
            luzGlobalCoragem.intensity += 0.1f * Time.deltaTime;
        }
    }

    public void AtivaTelaMedo()
    {
        luzGlobalNormal.gameObject.SetActive(false);

        luzGlobalCoragem.gameObject.SetActive(false);

        luzGlobalMedo.gameObject.SetActive(true);

        if (luzGlobalMedo.intensity < 1.3)
        {
            luzGlobalMedo.intensity += 0.1f * Time.deltaTime;
        }
    }
}
