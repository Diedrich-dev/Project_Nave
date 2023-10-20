using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public GameObject gameObjectLaser;
    public Transform localDoDisparoUnico;
    public Transform localDoDisparoEsquerda;
    public Transform localDoDisparoDireita;
    public float tempoMaximoDosLasersDuplos;
    public float tempoAtualDosLasersDuplos;
    public float velocidadeNave;
    public bool isLaserDuplo;
    public bool isJogadorVivo;
    private Vector2 teclasApertadas;
    // Start is called before the first frame update
    void Start()
    {
        isLaserDuplo = false;
        isJogadorVivo = true;
        tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarNave();
        if(isJogadorVivo)
        {
            AtirarLaser();
        }
        VerificarLaserDuplo();
    }

    private void MovimentarNave() 
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidbody2D.velocity = teclasApertadas.normalized * velocidadeNave;
    }

    private void AtirarLaser()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            if(!isLaserDuplo)
            {
                Instantiate(gameObjectLaser, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
            else
            {
                Instantiate(gameObjectLaser, localDoDisparoEsquerda.position, localDoDisparoEsquerda.rotation);
                Instantiate(gameObjectLaser, localDoDisparoDireita.position, localDoDisparoDireita.rotation);
            }

            EfeitosSonoros.instance.somDoLaserDoJogador.Play();
        }
        
    }

    private void VerificarLaserDuplo()
    {
        if(isLaserDuplo)
        {
            tempoAtualDosLasersDuplos -= Time.deltaTime;

            if(tempoAtualDosLasersDuplos <= 0)
            {   
                DesativarLaserDuplo();
            }
        }
    }

    private void DesativarLaserDuplo()
    {
        isLaserDuplo = false;
        tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos;
    }
}
