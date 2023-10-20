using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruidorDeInimigos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Inimigo"))
        {
            Destroy(collider.gameObject);
        }
    }
}
