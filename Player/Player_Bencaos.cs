using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bencaos : MonoBehaviour
{
    [SerializeField] Controle_Emocional cE;
    [SerializeField] Player_Vida pV;

    public SpriteRenderer sR;

    public GameObject particulaRegeneracao;

    public GameObject escudoUltravioleta;

    public GameObject particulaBiohazard;

    [SerializeField] private bool ressuscitar = false;

    [SerializeField] private bool regeneracao = false;

    [SerializeField] private bool imunidadeUltravioleta = false;

    [SerializeField] private bool imunidadeToxicidade = false;

    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Ultravioleta")
        {
            ChecaImunidadeUltravioleta();
        }
        if (_player.gameObject.tag == "BioHazard")
        {
            ChecaImunidadeToxicidade();
        }
        if(_player.gameObject.tag == "Serra")
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 60;
            cE.Medo(50);

            SetRessuscitar(false);
            SetRegeneracao(false);
            SetImunidadeToxicidade(false);
            SetImunidadeUltravioleta(false);
        }
        if(_player.gameObject.tag == "Bisturi")
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 30;
            cE.Medo(50);

            SetImunidadeToxicidade(false);
            SetImunidadeUltravioleta(false);
        }
    }

    public bool ChecaImunidadeUltravioleta()
    {
        if (GetImuneUltravioleta() == false && pV.GetImuneDano() == false)
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 40;
            cE.Medo(50);
        }

        return false;
    }
    public bool ChecaImunidadeToxicidade()
    {
        if (GetImuneToxicidade() == false && pV.GetImuneDano() == false)
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 40;
            cE.Medo(50);
        }

        return false;
    }

    public void SetRessuscitar(bool _ressuscitar)
    {
        ressuscitar = _ressuscitar;

        if (_ressuscitar == true)
        {
            sR.color = Color.yellow;
        }
    }

    public bool GetRessuscitar()
    {
        return ressuscitar;
    }

    public void SetRegeneracao(bool _regeneracao)
    {
        regeneracao = _regeneracao;
        if (_regeneracao == true) 
        { 
            particulaRegeneracao.SetActive(true);
        
            StartCoroutine(TempRegenerar());
        }
        else
            particulaRegeneracao.SetActive(false);
    }

    public void SetImunidadeUltravioleta(bool _imunidadeUltravioleta)
    {
        imunidadeUltravioleta = _imunidadeUltravioleta;

        if (_imunidadeUltravioleta == true)
        {
            escudoUltravioleta.SetActive(true);
        }
        else
            escudoUltravioleta.SetActive(false);
    }
    public void SetImunidadeToxicidade(bool _imunidadeToxicidade)
    {
        imunidadeToxicidade = _imunidadeToxicidade;

        if (_imunidadeToxicidade == true)
            particulaBiohazard.SetActive(true);
        else
            particulaBiohazard.SetActive(false);
    }

    public bool GetRegeneracao()
    {
        return regeneracao;
    }
    public bool GetImuneToxicidade()
    {
        return imunidadeToxicidade;
    }
    public bool GetImuneUltravioleta()
    {
        return imunidadeUltravioleta;
    }
    IEnumerator TempRegenerar()
    {
        while(GetRegeneracao() == true)
        {
            yield return new WaitForSeconds(2f);

            if (pV.barraDeVida.value < 100)
            {
                pV.barraDeVida.value += 30;
            }
        }
        
    }
}
