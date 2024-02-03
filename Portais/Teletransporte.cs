using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransporte : MonoBehaviour
{
    [Header("Controles do Teletransporte")]

    [SerializeField] private Player_PegaItens playerPegaItens;
    [SerializeField] private Player_Bencaos playerBencaos;

    public AudioSource aS;
    public AudioClip openDoor;

    public GameObject cam;
    public GameObject tela;
    public string nomeFase;
    public string carregaCena;
    public bool resetarHabilidades;

    public TextMeshProUGUI textoFase;
    public Transform playerPosicao;
    public float coordenadaX;
    public float coordenadaY;
    public GameObject feedbackPorta;
    public bool portaTrancada;
    public bool ultimaPorta;

    public void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            if(portaTrancada == false)
            {
                aS.clip = openDoor;
                aS.Play();

                PlayerTeleporte();
            }
            else
            {
                if(playerPegaItens.pegouChave == true)
                {
                    playerPegaItens.pegouChave = false;
                    PlayerTeleporte();
                }
                else
                {
                    feedbackPorta.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player" && playerPegaItens.pegouChave == false && feedbackPorta != null)
        {
            feedbackPorta.SetActive(false);
        }
    }

    void PlayerTeleporte()
    {
        playerPosicao.position = new Vector2(coordenadaX, coordenadaY);

        cam.transform.position = playerPosicao.position;

        if (resetarHabilidades == true)
        {
            playerBencaos.SetImunidadeToxicidade(false);
            playerBencaos.SetImunidadeUltravioleta(false);
            playerBencaos.SetRegeneracao(false);
            playerBencaos.SetRessuscitar(false);
        }

        if (ultimaPorta)
        {
            SceneManager.LoadScene("Cutscene_Final");
        }
    }
}
