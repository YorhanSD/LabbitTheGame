using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Patrulha : Movimento
{
    private bool parar = false;

    public void SetPararInimigo(bool _parar)
    {
        parar = _parar;
    }

    public bool GetParar()
    {
        return parar;
    }

    void FixedUpdate()
    {
        MovimentoHorizontal();
    }

    public override bool MovimentoHorizontal()
    {
        if (GetParar() == false)
        {
            return base.MovimentoHorizontal();
        }

        return false;
    }
}
