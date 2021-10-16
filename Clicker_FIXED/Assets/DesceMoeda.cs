using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesceMoeda : MonoBehaviour
{
    public float velocidade;
    void Update(){
        transform.position += Vector3.down * velocidade * Time.deltaTime;
    }
}
