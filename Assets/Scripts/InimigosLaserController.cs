using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosLaserController : MonoBehaviour
{
    public GameObject impactoDoLaserDoInimigo;
    public float velocidadeLaser;
    public int dano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }

    private void MovimentarLaser()
    {
        transform.Translate(Vector3.up * velocidadeLaser * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<VidaController>().MachucarJogador(dano);

            Instantiate(impactoDoLaserDoInimigo, transform.position, transform.rotation);
            
            Destroy(this.gameObject);
        }
    }
}
