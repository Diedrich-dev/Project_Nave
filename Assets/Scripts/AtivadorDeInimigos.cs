using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeInimigos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Inimigo"))
        {
            collider.gameObject.GetComponent<InimigosController>().AtivarInimigo();
        }
    }
}
