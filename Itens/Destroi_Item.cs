using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroi_Item : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip bag;

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player" || _player.gameObject.tag == "GolpeKarate")
        {
            Destroy(gameObject);
        }
    }
}
