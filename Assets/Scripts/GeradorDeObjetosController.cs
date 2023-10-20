using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObjetosController : MonoBehaviour
{
    public static GeradorDeObjetosController instance;
    public GameObject[] gameObjectsSpawns;
    public Transform[] pontosDeSpawns;

    public float tempoMaximoEntreOsSpawns;
    public float tempoAtualDosSpawns;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        tempoAtualDosSpawns = tempoMaximoEntreOsSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualDosSpawns -= Time.deltaTime;

        if(tempoAtualDosSpawns <= 0)
        {
            SpawnarObject();
        }
    }

    private void SpawnarObject()
    {
        int objetoAleatorio = Random.Range(0, gameObjectsSpawns.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawns.Length);

        Instantiate(gameObjectsSpawns[objetoAleatorio], pontosDeSpawns[pontoAleatorio].position, Quaternion.Euler(0F, 0F, -90F));
        tempoAtualDosSpawns = tempoMaximoEntreOsSpawns;
    }
}
