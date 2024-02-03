using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldus_Especial : MonoBehaviour
{

    private bool permitirLeitura = false;
    public bool disparar = true;
    private bool especial = false;
    public bool conversor;
    public float posicaoPositiva;
    public float posicaoNegativa;
    public int quantidadePermitidaBisturi;
    public int contaAtaques;
    public int contagemBisturi;
    public int contagemSeringa;

    [SerializeField] private Camera_Segue cameraSegue;
    [SerializeField] private Efeitos_Visuais efeitosVisuais;
    public Transform pontoDisparoBisturi;
    public Animator anim;
    public AudioSource aS;
    public AudioClip risadaAudio;
    public AudioClip especialAudio;
    public GameObject bisturi;
    public GameObject seringa;

    public void SetEspecial(bool _permitirEspecial)
    {
        especial = _permitirEspecial;
    }

    public bool GetEspecial()
    {
        return especial;
    }

    public void SetPermitirLeituraMovimento(bool _permitirLeitura)
    {
        permitirLeitura = _permitirLeitura;
    }

    public bool GetPermitirLeitura()
    {
        return permitirLeitura;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();

        StartCoroutine(DisparaAtaque());

        quantidadePermitidaBisturi = 2;
    }

    private void Update()
    {
        if (GetPermitirLeitura() == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (quantidadePermitidaBisturi < 12)
                {
                    quantidadePermitidaBisturi++;
                }
            }

            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
            {
                if(contaAtaques < 3)
                {
                    contaAtaques++;
                    StartCoroutine(Especial());
                }
            }
        }
    }

    public void Celebrating()
    {
        if (aS != null)
        {
            aS.clip = risadaAudio;
            aS.Play();
            anim.SetTrigger("Celebrating");
        }
    }
    public IEnumerator DisparaAtaque()
    {
        contagemBisturi = 0;
        posicaoPositiva = 2025f;
        posicaoNegativa = 2005f;

        for (int i = contagemBisturi; i < quantidadePermitidaBisturi; i++)
        {
            yield return new WaitForSeconds(2);

            DefinidorPosicao();
            BisturiMovimento();
            disparar = true;
        }

        yield return new WaitForSeconds(2);

        StartCoroutine(DisparaAtaque());
    }

    public IEnumerator Especial()
    {
        if (contaAtaques == 3)
        {
            contaAtaques = 0;

            SetEspecial(true);

            cameraSegue.CameraAldusEspecial();

            anim.SetTrigger("Special");

            aS.clip = especialAudio;
            aS.Play();

            yield return new WaitForSeconds(3.5f);

            efeitosVisuais.AldusEspecial();
            cameraSegue.camNormal();

            contagemBisturi = 0;
            posicaoPositiva = 2025f;
            posicaoNegativa = 2005f;

            for (int i = contagemBisturi; i < quantidadePermitidaBisturi; i++)
            {
                DefinidorPosicao();
                BisturiMovimento();
                disparar = true;
            }

            SetEspecial(false);

        }
    }

    public void DefinidorPosicao()
    {
        posicaoPositiva += 5;
        posicaoNegativa -= 5;

        conversor =! conversor;

        if (conversor)
        {
            pontoDisparoBisturi.position = new Vector2(posicaoPositiva, 60f);
        }
        else
        {
            pontoDisparoBisturi.position = new Vector2(posicaoNegativa, 60f);
        }
    }

    public void BisturiMovimento()
    {
        if (disparar == true)
        {
            //Estancia um clone do bisturi na cena
            GameObject bisturiTemp = (GameObject)(Instantiate(bisturi, pontoDisparoBisturi.position, pontoDisparoBisturi.rotation));

            disparar = false;
        }
    }

    /*
    public void SeringaMovimento()
    {
        if (disparar == true)
        {
            Estancia um clone da seringa na cena
            GameObject seringaTemp = (GameObject)(Instantiate(seringa, pontoDisparoSeringa[contagemSeringa].transform.position, Quaternion.identity));

            if (contagemSeringa % 2 == 0)
            {
                seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.left);
            }
            else
            {
                seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.right);
            }

            disparar = false;
        }

    }
    */
}
