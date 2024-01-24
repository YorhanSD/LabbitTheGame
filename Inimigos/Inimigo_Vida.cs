using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo_Vida : MonoBehaviour
{
    public float vidaCompleta = 50;
    public bool permitirDrop = true;
    public bool resistenciaCenouras = false;
    private int randomProbabilidade;

    public Animator anim;
    public Text vidaTexto;
    public Slider barraDeVida;
    public GameObject[] dropItem;
    public GameObject inimigo;

    public bool isAldos;

    [SerializeField] private Player_Vida playerVida;
    [SerializeField] private Controle_Emocional controleEmocional;
    [SerializeField] private TrocaDeEstado trocaDeEstado;

    public Inimigo_Patrulha inimigoPatrulha;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        vidaTexto.text = vidaCompleta + " / " + barraDeVida.value;

        if (barraDeVida.value <= 0)
        {
            if (permitirDrop == true)
            {
                Drop();
            }

            GanharCoragem(50);
            Morte();
        }
       
    }
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (resistenciaCenouras == true)
        {
            DanoMinimo(_other);
        }
        else
        {
            DanoMaximo(_other);

            if (_other.CompareTag("GolpeKarate"))
            {
                TomaDano(20);
            }
        }
    }

    public void DanoMinimo(Collider2D _other)
    {
        if (_other.gameObject.tag == "CenouraLaranja")
        {
            TomaDano(GameObject.FindGameObjectWithTag("CenouraLaranja").GetComponent<Cenoura_Laranja>().GetDano() / 3);
        }
        else if (_other.gameObject.tag == "CenouraPreta")
        {
            TomaDano(GameObject.FindGameObjectWithTag("CenouraPreta").GetComponent<Cenoura_Preta>().GetDano() / 3);
        }
        else if (_other.gameObject.tag == "SuperCenouraPreta")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraPreta").GetComponent<Super_CenouraPreta>().GetDano());
        }
        else if (_other.gameObject.tag == "SuperCenouraVerde")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraVerde").GetComponent<Super_CenouraVerde>().GetDano());
        }
        else if (_other.gameObject.tag == "SuperCenouraAzul")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraAzul").GetComponent<Super_CenouraAzul>().GetDano());
            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraAzul").GetComponent<Super_CenouraAzul>().GetCura();
            playerVida.TocaMusicaCura();
        }
        else if (_other.gameObject.tag == "SuperCenouraLaranja")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraLaranja").GetComponent<Super_CenouraLaranja>().GetDano());
            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraLaranja").GetComponent<Super_CenouraLaranja>().GetCura();
            playerVida.TocaMusicaCura();
        }
    }
    public void DanoMaximo(Collider2D _other)
    {
        if(_other.gameObject.tag == "CenouraLaranja")
        {
            TomaDano(GameObject.FindGameObjectWithTag("CenouraLaranja").GetComponent<Cenoura_Laranja>().GetDano());
        }
        else if(_other.gameObject.tag == "CenouraPreta")
        {
            TomaDano(GameObject.FindGameObjectWithTag("CenouraPreta").GetComponent<Cenoura_Preta>().GetDano());
        }
        else if (_other.gameObject.tag == "SuperCenouraAzul")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraAzul").GetComponent<Super_CenouraAzul>().GetDano());
            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraAzul").GetComponent<Super_CenouraAzul>().GetCura();
            playerVida.TocaMusicaCura();
        }
        else if (_other.gameObject.tag == "SuperCenouraLaranja")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraLaranja").GetComponent<Super_CenouraLaranja>().GetDano());
            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraLaranja").GetComponent<Super_CenouraLaranja>().GetCura();
            playerVida.TocaMusicaCura();
        }
        else if(_other.gameObject.tag == "SuperCenouraPreta")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraPreta").GetComponent<Super_CenouraPreta>().GetDano());
        }
        else if (_other.gameObject.tag == "SuperCenouraVerde")
        {
            TomaDano(GameObject.FindGameObjectWithTag("SuperCenouraVerde").GetComponent<Super_CenouraVerde>().GetDano());
        }
    }
    public void Drop()
    {
        randomProbabilidade = Random.Range(0, 2);

        Instantiate(dropItem[randomProbabilidade], gameObject.transform.position, gameObject.transform.rotation);

        Debug.Log("Dropou DNA Resultado : " + randomProbabilidade);
    }
    private void TomaDano(int _dano)
    {
        barraDeVida.value -= _dano;
        StartCoroutine(AnimacaoSofrendoDano());
    }

    private IEnumerator AnimacaoSofrendoDano()
    {
        if (inimigoPatrulha != null)
        {
            inimigoPatrulha.SetPararInimigo(true);
        }

        anim.SetTrigger("Suffering");

        yield return new WaitForSeconds(1f);

        if (inimigoPatrulha != null)
        {
            inimigoPatrulha.SetPararInimigo(false);
        }
    }

    private void GanharCoragem(int _nivelCoragem)
    {
        controleEmocional.Coragem(_nivelCoragem);
    }
    private void Morte()
    {
        if (isAldos)
        {
            trocaDeEstado.AtivarAldosTunado();
        }
        Destroy(gameObject);
    }
}
