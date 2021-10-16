using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PainelDireito : MonoBehaviour
{
    //ESSE SCRIPT É PRA ESCONDER/MOSTRAR O PAINEL DA DIREITA QUANDO APERTAR NO BOTÃO COM A SETINHA
    int abertoesq = 1;
    int abertodir = 1; //F atribuições
    public float width;
    public RectTransform toggleButton;
    public void AbreFechaDireito(){
        FindObjectOfType<AudioManager>().PlaySound("mouseClick");
        abertodir = 1 - abertodir;
        toggleButton.localScale = new Vector3 (-toggleButton.localScale.x, toggleButton.localScale.y, toggleButton.localScale.z);
        if (abertodir == 0){
            GetComponent<RectTransform>().localPosition += Vector3.right * width;
        }
        else GetComponent<RectTransform>().localPosition += Vector3.left * width;
    }
    public void AbreFechaEsquerdo(){
        FindObjectOfType<AudioManager>().PlaySound("mouseClick");
        abertoesq = 1 - abertoesq;
        toggleButton.localScale = new Vector3 (-toggleButton.localScale.x, toggleButton.localScale.y, toggleButton.localScale.z);
        if (abertoesq == 0){
            GetComponent<RectTransform>().localPosition += Vector3.left * width;
        }
        else GetComponent<RectTransform>().localPosition += Vector3.right * width;
    }
}
