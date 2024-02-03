using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Persegue : Movimento
{
    [SerializeField] private Ataque ataque;

    private void Start()
    {
        SetPodeAndar(true);
    }

    void Update()
    {
        if(GetPodeAndar() == true)
        {
            SeguirPlayer();
        }
    }
}
