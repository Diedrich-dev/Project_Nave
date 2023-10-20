using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirController : MonoBehaviour
{
    public float tempoVida;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
