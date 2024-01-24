using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeMovimento : MonoBehaviour
{
    [SerializeField] private Aldos_IA aldosIA;

    void Start()
    {
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            aldosIA.probabilidadeAtirar();
        }
    }
}
