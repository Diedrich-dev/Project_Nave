using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaController : MonoBehaviour
{
    public Slider barraDeVidaJogador;
    public Slider barraDeEnergiaDoEscudo;
    public GameObject escudoDoJogador;
    public int vidaMaxima;
    public int vidaAtual;
    public int vidaMaximaEscudo;
    public int vidaAtualEscudo;

    public bool isEscudo;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
        vidaAtualEscudo = vidaMaximaEscudo;
        
        barraDeVidaJogador.maxValue = vidaMaxima;
        barraDeVidaJogador.value = vidaAtual;

        barraDeEnergiaDoEscudo.maxValue = vidaMaximaEscudo;
        barraDeEnergiaDoEscudo.value = vidaAtualEscudo;
        barraDeEnergiaDoEscudo.gameObject.SetActive(false);
        escudoDoJogador.SetActive(false);
        isEscudo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarEscudo()
    {
        barraDeEnergiaDoEscudo.gameObject.SetActive(true);
        vidaAtualEscudo = vidaMaximaEscudo;
        barraDeEnergiaDoEscudo.value = vidaAtualEscudo;
        escudoDoJogador.SetActive(true);
        isEscudo = true;
    }

    public void GanharVida(int vidaParaReceber)
    {
        if(vidaAtual + vidaParaReceber <= vidaMaxima)
        {
            vidaAtual += vidaParaReceber;
        }
        else
        {
            vidaAtual = vidaMaxima;
        }

        barraDeVidaJogador.value = vidaAtual;
    }

    public void MachucarJogador(int danoReceber)
    {
        if(!isEscudo)
        {
            vidaAtual -= danoReceber;
            barraDeVidaJogador.value = vidaAtual;
            if(vidaAtual <= 0)
            {
                //Buscar Script em cena
                FindObjectOfType<PlayerController>().isJogadorVivo = false;
                GameManager.instance.GameOver();
            }
        }
        else 
        {
            vidaAtualEscudo -= danoReceber;
            barraDeEnergiaDoEscudo.value -= vidaAtualEscudo;
            if(vidaAtualEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);
                isEscudo = false;
                barraDeEnergiaDoEscudo.gameObject.SetActive(false);
            }
        }
    }
}
