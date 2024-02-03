using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive_Punch : MonoBehaviour
{
    public float raioArea;

    public string animacaoIdle;
    public string animacaoAtaque;

    public bool ladoDireito;
    private bool proximoAtaque = true;
    public bool isPlayer;

    public LayerMask playerLayer;
    public Transform areaAtaque;

    public Transform areaDano;

    public float pocicaoAreaDano_X;
    public float pocicaoAreaDano_Y;
    public float pocicaoAreaAtaque_X;
    public float pocicaoAreaAtaque_Y;

    private Animator anim;
    public AudioSource audioSource;
    public AudioClip somAtaque;

    [SerializeField] private Inimigo_Patrulha inimigoPatrulha;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        proximoAtaque = true;
    }

    void Update()
    {
        ControlePosicao();
        
        isPlayer = Physics2D.OverlapCircle(areaAtaque.position, raioArea, playerLayer); //Cria o Range de Ataque
        
        if(proximoAtaque == true && isPlayer == true)
        {
            proximoAtaque = false;
            StartCoroutine(AnimacaoAtaque());
        }
    }

    private bool ControlePosicao()
    {
        if (inimigoPatrulha != null && inimigoPatrulha.posicaoInicial > gameObject.transform.position.x)
        {
            areaAtaque.localPosition = new Vector2(pocicaoAreaAtaque_X, pocicaoAreaAtaque_Y);

            areaDano.localPosition = new Vector2(pocicaoAreaDano_X, pocicaoAreaDano_Y);

            ladoDireito = true;

            return false;
        }

        if (inimigoPatrulha != null && inimigoPatrulha.posicaoFinal < gameObject.transform.position.x)
        {
            areaAtaque.localPosition = new Vector2(-pocicaoAreaAtaque_X, pocicaoAreaAtaque_Y);

            areaDano.localPosition = new Vector2(-pocicaoAreaDano_X, pocicaoAreaDano_Y);

            ladoDireito = false;
        }

        return false;
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(areaAtaque.position, raioArea);
    }

    private IEnumerator AnimacaoAtaque()
    {
        if (inimigoPatrulha != null)
        {
            inimigoPatrulha.SetPararInimigo(true);
        }

        anim.SetTrigger(animacaoAtaque);

        audioSource.clip = somAtaque;
        audioSource.Play();

        yield return new WaitForSecondsRealtime(1);

        anim.SetTrigger(animacaoIdle);

        yield return new WaitForSecondsRealtime(2);

        if (inimigoPatrulha != null)
        {
            inimigoPatrulha.SetPararInimigo(false);
        }

        proximoAtaque = true;
    }
    
}
