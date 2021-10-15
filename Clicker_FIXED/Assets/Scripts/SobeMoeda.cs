using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SobeMoeda : MonoBehaviour
{
    //Literalmente só faz a moeda subir
    public float velocidade;
    void Update()
    {
        transform.position += Vector3.up * velocidade * Time.deltaTime;
    }
}
