using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public abstract class Movimento : MonoBehaviour
{
    public float velocidade = 8f;
    public float posicaoInicial;
    public float posicaoFinal;
    public float rangeMinimo;
    public float rangeMaximo;
    [SerializeField] private bool podeAndar;
    public bool moveDireita;
    public bool moveParaBaixo;

    public Vector3 distanciaPlayer;
    public Transform posicaoPlayer;
    public Animator anim;
    public Rigidbody2D rigid2D;
    public SpriteRenderer sr;
    public AudioSource audioSource;
    public AudioClip somMovimento;

    public void SetPodeAndar(bool _podeAndar)
    {
        podeAndar = _podeAndar;
    }

    public bool GetPodeAndar()
    {
        return podeAndar;
    }

    public virtual void SomMovimento()
    {
        if (audioSource != null)
        {
            audioSource.clip = somMovimento;
            audioSource.Play();
        }
    }

    public virtual bool MovimentoHorizontal()
    {
        if (posicaoInicial > gameObject.transform.position.x)
        {
            moveDireita = true;

            Flip();
        }
        else if (posicaoFinal < gameObject.transform.position.x)
        {
            moveDireita = false;

            Flip();
        }

        if (moveDireita)
        {
            gameObject.transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);

            return false;
        }

        gameObject.transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);

        return false;
    }

    public void Flip()
    {
        if (sr != null)
        {
            sr.flipX = !sr.flipX;
        }
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

    public void SeguirPlayer()
    {
        anim.SetFloat("velocidade", Mathf.Abs(rigid2D.velocity.x));

        distanciaPlayer = posicaoPlayer.transform.position - transform.position;

        if (podeAndar == true && Mathf.Abs(distanciaPlayer.x) < rangeMaximo && Mathf.Abs(distanciaPlayer.x) > rangeMinimo)
        {
            //inimigo se move em direcao ao player
            rigid2D.velocity = new Vector2(velocidade * (distanciaPlayer.x / Mathf.Abs(distanciaPlayer.x)), rigid2D.velocity.y);
        }
        else
        {
            anim.SetFloat("velocidade", 0);

            rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
        }

        if (rigid2D.velocity.x < 0 && sr.flipX == true )//Se a velocidade do inimigo for maior que zero entao:
        {
            Flip();
        }
        else if (rigid2D.velocity.x > 0 && sr.flipX == false)//Se a velocidade do inimigo for menor que zero entao:
        {
            Flip();
        }
    }
}
