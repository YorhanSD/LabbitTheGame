using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Bioxugo_Ataque : Ataque
{
    public Transform posicaoPlayer;

    public GameObject[] OndaEletrica = new GameObject[3];

    public Transform[] Choque;

    public SpriteRenderer spriteXugo;

    public Animator anim;

    public SpriteRenderer[] spriteOndaEletrica;

    public AudioSource aS;

    public AudioClip somBioxugo;

    public AudioClip somRaio;

    public Rigidbody2D rigi2D;

    [SerializeField] private Inimigo_Persegue inimigoPersegue;

    [SerializeField] private Inimigo_Vida inimigoVida;

    void Start()
    {
        SetPodeAtacar(true);
        
        rigi2D = GetComponent<Rigidbody2D>();

        spriteXugo = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ChecaPosicao();
       
        ControlePosicao();

        verificaAlvo = Physics2D.OverlapCircle(areaAtaque.position, tamanhoRaioAtaque, alvo); //Cria o Range de Ataque

        if (GetPodeAtacar() == true && verificaAlvo == true)
        {
            SetPodeAtacar(false);

            inimigoPersegue.SetPodeAndar(false);

            anim.SetTrigger("Attack");

            rigi2D.velocity = new Vector2(0, rigi2D.velocity.y);
            anim.SetFloat("velocidade", 0);
        }
    }

    private void ControlePosicao()
    {
        if (inimigoPersegue.posicaoPlayer.position.x < gameObject.transform.position.x)
        {
            spriteXugo.flipX = false;

            PosicaoConjurarTrovao(-4, 15);

            PosicaoRajadaEletrica(-4, 1f, false);

            FliparRaios(false);

        }

        if (inimigoPersegue.posicaoPlayer.position.x > gameObject.transform.position.x)
        {
            spriteXugo.flipX = true;

            PosicaoConjurarTrovao(4, 15);

            PosicaoRajadaEletrica(4, 1f, true);

            FliparRaios(true);
        }
    }

    public void PosicaoRajadaEletrica(float posicaoX, float posicaoY, bool _conversor)
    {
        for (int i = 0; i < 3; i++) // Rajada Eletrica
        {
            if (_conversor == true)
            {
                posicaoX += 5;

            } else 
            { 
                posicaoX -= 5;
            }

            Debug.Log($"Posição X da Rajada {i} : {posicaoX}");
            Choque[i].localPosition = new Vector2(posicaoX, posicaoY);
        }
    }

    public void PosicaoConjurarTrovao(float posicaoX, float posicaoY)
    {
        for (int i = 3; i < 6; i++) // Conjurar Trovão
        {
            posicaoY -= 5;
            Debug.Log($"Posição Y do Raio {i} : {posicaoY}");
            Choque[i].localPosition = new Vector2(posicaoX, posicaoY);
        }
    }

    public void FliparRaios(bool _virar)
    {
        for(int i = 0;i < 6; i++)
        {
            spriteOndaEletrica[i].flipX = _virar;
        }
    }

    public IEnumerator IniciaRajadaEletrica()
    {
        aS.clip = somBioxugo;
        aS.Play();

        yield return new WaitForSeconds(0.1f);
        OndaEletrica[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        OndaEletrica[1].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        OndaEletrica[2].SetActive(true);

        StartCoroutine(FinalizaRajadaEletrica());
    }

    public IEnumerator FinalizaRajadaEletrica()
    {
       yield return new WaitForSeconds(0.1f);
       OndaEletrica[0].SetActive(false);
       yield return new WaitForSeconds(0.2f);
       OndaEletrica[1].SetActive(false);
       yield return new WaitForSeconds(0.3f);
       OndaEletrica[2].SetActive(false);

       yield return new WaitForSeconds(2f);

       inimigoPersegue.SetPodeAndar(true);

       SetPodeAtacar(true);

    }

    public void AtivaRaio()
    {
        if (GetPodeAtacar() == true)
        {
            anim.SetTrigger("Attack_Plus");

            inimigoPersegue.SetPodeAndar(false);

            SetPodeAtacar(false);

            inimigoVida.ImuneDano();
        }
    }
    
    IEnumerator IniciaRaio()
    {
        aS.clip = somRaio;
        aS.Play();

        yield return new WaitForSeconds(0.1f);
        OndaEletrica[3].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        OndaEletrica[4].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        OndaEletrica[5].SetActive(true);

        StartCoroutine(FinalizaRaio());
    }

    IEnumerator FinalizaRaio()
    {
        yield return new WaitForSeconds(0.1f);
        OndaEletrica[3].SetActive(false);
        yield return new WaitForSeconds(0.2f);
        OndaEletrica[4].SetActive(false);
        yield return new WaitForSeconds(0.3f);
        OndaEletrica[5].SetActive(false);

        yield return new WaitForSeconds(1.5f);

        inimigoVida.ImuneDano();

        yield return new WaitForSeconds(1.5f);

        inimigoPersegue.SetPodeAndar(true);

        SetPodeAtacar(true);
    }
}
