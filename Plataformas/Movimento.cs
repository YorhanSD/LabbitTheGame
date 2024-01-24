using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movimento : MonoBehaviour
{
    public float velocidade = 8f;

    public float posicaoInicial;
    public float posicaoFinal;

    public bool moveDireita;
    public bool moveParaBaixo;

    public SpriteRenderer sr;

    public virtual bool MovimentoHorizontal()
    {
        if (posicaoInicial > gameObject.transform.position.x)
        {
            moveDireita = true;

            if (sr != null)
            sr.flipX = true;
        }
        else if (posicaoFinal < gameObject.transform.position.x)
        {
            moveDireita = false;

            if(sr != null)
            sr.flipX = false;
        }

        if (moveDireita)
        {
            gameObject.transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);

            return false;
        }

        gameObject.transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);

        return false;
    }

    public virtual bool MovimentoVertical()
    {
        if (transform.position.y > posicaoInicial)
        {
            moveParaBaixo = true;
        }
        else if (transform.position.y < posicaoFinal)
        {
            moveParaBaixo = false;
        }

        if (moveParaBaixo)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);

            return false;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }

        return false;
    }
}
