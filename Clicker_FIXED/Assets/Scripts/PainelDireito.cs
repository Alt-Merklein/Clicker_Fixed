using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PainelDireito : MonoBehaviour
{
    //ESSE SCRIPT É PRA ESCONDER/MOSTRAR O PAINEL DA DIREITA QUANDO APERTAR NO BOTÃO COM A SETINHA
    int aberto = 1;
    public float width;
    public RectTransform toggleButton;
    public void AbreFecha(){
        aberto = 1 - aberto;
        toggleButton.localScale = new Vector3 (-toggleButton.localScale.x, toggleButton.localScale.y, toggleButton.localScale.z);
        if (aberto == 0){
            GetComponent<RectTransform>().localPosition += Vector3.right * width;
        }
        else GetComponent<RectTransform>().localPosition += Vector3.left * width;
    }
}
