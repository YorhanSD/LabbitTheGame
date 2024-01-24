using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffNerff_Cenouras : MonoBehaviour
{
    [SerializeField] private Cenoura_Laranja cenouraLaranja;
    [SerializeField] private Cenoura_Preta cenouraPreta;

    [SerializeField] private Super_CenouraAzul superCenouraAzul;
    [SerializeField] private Super_CenouraLaranja superCenouraLaranja;
    [SerializeField] private Super_CenouraVerde superCenouraVerde;
    [SerializeField] private Super_CenouraPreta superCenouraPreta;

    void Awake()
    {
        //As cenouras precisam estar na cena

        //cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        //cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        //cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        //cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        //superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        //superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        //superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
        //superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
    }

    public void BuffarDanoCenouras()
    {
        cenouraLaranja.SetDano(20);
        cenouraPreta.SetDano(60);

        //cenouraVerde.SetDano(50);
        //cenouraAzul.SetDano(40);

        superCenouraLaranja.SetDano(20);
        superCenouraLaranja.SetCura(60);

        superCenouraPreta.SetDano(80);

        superCenouraVerde.SetDano(70);

        superCenouraAzul.SetDano(40);
        superCenouraAzul.SetCura(80);
    }
    public void BuffarCuraCenouras()
    {
        cenouraLaranja.SetCura(60);
        cenouraPreta.SetCura(20);

        //cenouraVerde.SetCura(50);
        //cenouraAzul.SetCura(40);

        superCenouraLaranja.SetDano(20);
        superCenouraLaranja.SetCura(60);

        superCenouraPreta.SetDano(80);

        superCenouraVerde.SetDano(70);

        superCenouraAzul.SetDano(40);
        superCenouraAzul.SetCura(80);
    }
}
