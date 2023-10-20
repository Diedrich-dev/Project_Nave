using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosController : MonoBehaviour
{
    public GameObject gameObjectLaserInimigo;
    public Transform localDoDisparo;
    public GameObject itemParaDropar;
    public GameObject efeitoDeExplosao;
    public float velocidadeInimigo;

    public int vidaAtual;
    public int vidaMaxima;

    public int pontosParaDar;
    public int chanceParaDropar;

    public int dano;
    public float tempoMaximoEntreLasers;
    public float tempoAtualLasers;

    public bool isAtirador;
    public bool isInimigoAtivado;
    // Start is called before the first frame update
    void Start()
    {
        isInimigoAtivado = false;
        vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
        if(isAtirador && isInimigoAtivado)
        {
            AtirarLaser();
        }
        
    }

    public void AtivarInimigo()
    {
        isInimigoAtivado = true;
    }

    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidadeInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualLasers -= Time.deltaTime;
        if(tempoAtualLasers <= 0)
        {
            Instantiate(gameObjectLaserInimigo, localDoDisparo.position, Quaternion.Euler(0F, 0F, 90F));
            tempoAtualLasers = tempoMaximoEntreLasers;
        }
    }

    public void MachucarInimigo(int dano)
    {
        vidaAtual -= dano;
        if(vidaAtual <= 0)
        {
            GameManager.instance.AumentarPontuacao(pontosParaDar);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            EfeitosSonoros.instance.somDaExplosao.Play();

            int numeroAleatorio = Random.Range(0, 100);

            if(numeroAleatorio <= chanceParaDropar)
            {
                Instantiate(itemParaDropar, transform.position, Quaternion.Euler(0F, 0F, 0F));
            }
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaController>().MachucarJogador(dano);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            EfeitosSonoros.instance.somDaExplosao.Play();
            Destroy(this.gameObject);
        }
    }
}
