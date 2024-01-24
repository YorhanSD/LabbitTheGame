using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Buffs_Nerfs : MonoBehaviour
{
    [SerializeField] private BuffNerff_Cenouras buffarAndNerffarCenouras;
    [SerializeField] private Player_Movimento playerMovimento;


    [SerializeField] private Cenoura_Laranja cenouraLaranja;
    [SerializeField] private Cenoura_Preta cenouraPreta;


    [SerializeField] private Super_CenouraAzul superCenouraAzul;
    [SerializeField] private Super_CenouraLaranja superCenouraLaranja;
    [SerializeField] private Super_CenouraVerde superCenouraVerde;
    [SerializeField] private Super_CenouraPreta superCenouraPreta;

    

    public void CoragemMaxima() //Metodo coragem maxima
    {
        playerMovimento.SetPlayerVelocidade(20);
        playerMovimento.SetPlayerForcaPulo(45);

        buffarAndNerffarCenouras.BuffarDanoCenouras();
    }

    public void AtributosNormais() //Atributos Padroes
    {
        playerMovimento.SetPlayerVelocidade(15);
        playerMovimento.SetPlayerForcaPulo(35);

        cenouraLaranja.SetDano(10);
        cenouraLaranja.SetCura(30);

        cenouraPreta.SetDano(30);
        cenouraPreta.SetCura(10);

        //cenouraVerde.SetDano(20);
        //cenouraVerde.SetCura(20);

        //cenouraAzul.SetDano(30);
        //cenouraAzul.SetCura(30);

        superCenouraLaranja.SetDano(10);
        superCenouraLaranja.SetCura(30);

        superCenouraPreta.SetDano(50);

        superCenouraVerde.SetDano(40);

        superCenouraAzul.SetDano(20);
        superCenouraAzul.SetCura(40);
    }

    public void MedoMaximo() //Medo Maximo
    {
        playerMovimento.SetPlayerVelocidade(30);
        playerMovimento.SetPlayerForcaPulo(40);

        buffarAndNerffarCenouras.BuffarCuraCenouras();
    }


}