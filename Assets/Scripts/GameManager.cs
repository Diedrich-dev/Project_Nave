using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource musicaDoJogo;
    public AudioSource musicaDeGameOver;
    public Text textoDePontuacaoAtual;
    public GameObject panelDeGameOver;
    public Text textoDePontuacaoFinal;
    public Text textoDeHighscore;
    public float velocidadeAumentada;
    public float tempoDescontadoEntreOsSpawns;
    public float tempoMinimoEntreOsSpawns;
    public int pontuacaoAtual;
    public int pontuacaoParaAumentarDificuldade;
    public int pontuacaoParaDificuldade;
    public int chanceDiminuidaParaDropar;
    public int chanceMinimaParaDropar;
 
    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1F;
        musicaDoJogo.Play();
        pontuacaoAtual = 0;
        textoDePontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
        pontuacaoParaDificuldade = pontuacaoParaAumentarDificuldade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AumentarPontuacao(int pontosParaGanhar)
    {
        pontuacaoAtual += pontosParaGanhar;
        textoDePontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
        if(pontuacaoAtual >= pontuacaoParaDificuldade)
        {
            pontuacaoParaDificuldade += pontuacaoParaAumentarDificuldade;
            AumentarDificuldadeDoJogo();
        }
    }
    public void AumentarDificuldadeDoJogo()
    {
        velocidadeAumentada++;
        if (chanceDiminuidaParaDropar >= chanceMinimaParaDropar)
        {
            chanceDiminuidaParaDropar--;
        }

        if(GeradorDeObjetosController.instance.tempoMaximoEntreOsSpawns >= tempoMinimoEntreOsSpawns){
            GeradorDeObjetosController.instance.tempoMaximoEntreOsSpawns -= tempoDescontadoEntreOsSpawns;
        }

    }

    public void GameOver()
    {
        //Parar o jogo
        Time.timeScale = 0F;
        
        musicaDoJogo.Stop();
        musicaDeGameOver.Play();
        panelDeGameOver.SetActive(true);
        textoDePontuacaoFinal.text = "PONTUAÇÃO: " + pontuacaoAtual;

        if(pontuacaoAtual > PlayerPrefs.GetInt("Highscore"))
        {
            //Salvar na memória 
            PlayerPrefs.SetInt("Highscore", pontuacaoAtual);
        }

        textoDeHighscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore"); 
    }
}
