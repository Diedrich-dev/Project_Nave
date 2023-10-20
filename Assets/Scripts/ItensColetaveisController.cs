using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveisController : MonoBehaviour
{
    public bool isItemEscudo;
    public bool isItemLaserDuplo;
    public bool isItemVida;
    public int vidaParaDar;
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player"))
        {
            if(isItemEscudo)
            {
                collider.gameObject.GetComponent<VidaController>().AtivarEscudo();
            }

            if(isItemLaserDuplo)
            {
                collider.gameObject.GetComponent<PlayerController>().isLaserDuplo = false;
                collider.gameObject.GetComponent<PlayerController>().tempoAtualDosLasersDuplos = collider.gameObject.GetComponent<PlayerController>().tempoMaximoDosLasersDuplos;
                collider.gameObject.GetComponent<PlayerController>().isLaserDuplo = true;
            }

            if(isItemVida)
            {
                collider.gameObject.GetComponent<VidaController>().GanharVida(vidaParaDar);
            }

            Destroy(this.gameObject);
            
        }
    }
}
