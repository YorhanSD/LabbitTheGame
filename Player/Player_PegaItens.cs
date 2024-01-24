using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_PegaItens : MonoBehaviour
{
    [SerializeField] private Cria_Itens criaItens;
    public bool pegouChave;

    private void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "CenouraLaranja")
        {
            criaItens.CriaCenouraLaranja();

            Debug.Log("Pegou Cenoura Laranja!");
        }
        if (_Player.gameObject.tag == "CenouraPreta")
        {
            criaItens.CriaCenouraPreta();
        }
        if (_Player.gameObject.tag == "DNA Azul")
        {
            criaItens.CriaDNAAzul();
        }
        if (_Player.gameObject.tag == "DNA Laranja")
        {
            criaItens.CriaDNALaranja();
        }
        if (_Player.gameObject.tag == "DNA Preto")
        {
            criaItens.CriaDNAPreto();
        }
        if (_Player.gameObject.tag == "DNA Verde")
        {
            criaItens.CriaDNAVerde();
        }
        if (_Player.gameObject.tag == "Chave")
        {
            pegouChave = true;
            Debug.Log("Pegou a Chave!");
        }

    }
}
