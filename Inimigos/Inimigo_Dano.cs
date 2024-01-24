using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Dano : MonoBehaviour
{
    public int danoInimigo = 30;

    [SerializeField] private Player_Vida playerVida;
    [SerializeField] private Controle_Emocional controleEmocional;
    [SerializeField] private Player_Suffering playerSuffering;

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.CompareTag("Player"))
        {
            if (playerVida.GetImuneDano() != true)
            {
                playerSuffering.SofrendoDano();
                playerVida.SetImuneDano(true);
                playerVida.barraDeVida.value -= danoInimigo;
                controleEmocional.Medo(50);
            }
        }
    }
}
