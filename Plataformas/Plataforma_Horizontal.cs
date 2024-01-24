using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Horizontal : Movimento
{
    void Update()
    {
        MovimentoHorizontal();
    }

    public override bool MovimentoHorizontal()
    {
        return base.MovimentoHorizontal();
    }
}
