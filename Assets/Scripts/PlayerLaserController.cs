using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{
    public GameObject impactoDoLaserDoJogador;
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
        if(collider.gameObject.CompareTag("Inimigo"))
        {
            collider.gameObject.GetComponent<InimigosController>().MachucarInimigo(dano);
            Instantiate(impactoDoLaserDoJogador, transform.position, transform.rotation);
            EfeitosSonoros.instance.somDeImpacto.Play();
            Destroy(this.gameObject);
        }
    }
}
