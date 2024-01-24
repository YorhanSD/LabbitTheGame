using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Segue : MonoBehaviour
{
    public float segueVelocidade;
    public float yOffSet = 1f;
    public Transform playerPosicao;
    Vector3 novaPosicao;
    Controle_Emocional cE;
    public Camera cam;

    void Awake()
    {
        cE = GameObject.FindObjectOfType<Controle_Emocional>();
    }
    private void Start()
    {
        gameObject.transform.position = playerPosicao.position;
    }

    private void FixedUpdate()
    {
        if (cE.emocaoSlider.value >= 100)
        {
            camFar();
        }
        else if (cE.emocaoSlider.value <= 0)
        {
            camNear();
        }
        else
        {
            camNormal();
        }

        if (playerPosicao != null)
        {
            transform.position = Vector3.Slerp(transform.position, novaPosicao, segueVelocidade * Time.deltaTime);

            novaPosicao = new Vector3(playerPosicao.position.x, playerPosicao.position.y + yOffSet, -60);
        }
    }

    void camNear()
    {
        segueVelocidade = 10f;

        if (cam.orthographicSize < 25)
        {
            cam.orthographicSize += 1 * Time.deltaTime;
        }

        if (gameObject.transform.position.y < 24 && yOffSet < 18)
        {
            //yOffSet += 2 * Time.deltaTime;
        }
        else if (yOffSet > 17)
        {
            //yOffSet = 18;
        }
    }

    void camNormal()
    {
        segueVelocidade = 1f;

        if (cam.orthographicSize > 20)
        {
            cam.orthographicSize -= 3 * Time.deltaTime;
        }

        if(gameObject.transform.position.y < 18 && yOffSet < 12)
        {
            //yOffSet += 2 * Time.deltaTime;
        }
        else if(yOffSet > 11)
        {
            //yOffSet = 12;
        }
    }

    void camFar()
    {
        segueVelocidade = 10f;

        if (cam.orthographicSize < 35)
        {
            cam.orthographicSize += 1 * Time.deltaTime;
        }

        if (gameObject.transform.position.y < 30 && yOffSet < 24)
        {
            //yOffSet += 2 * Time.deltaTime;
        }
        else if (yOffSet > 23)
        {
            //yOffSet = 24;
        }
    }

}
