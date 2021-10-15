using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Proletario : MonoBehaviour
{
    float timeCounter = 0;
    private int quantidade = 0;

     [SerializeField]
    private int multiplicadorBase;

    public int precoBase;
    public float preco;
    private float multiplicadorPreco = 1.1f;

    public TextMeshProUGUI precoText;

    [HideInInspector]
    public Money money;

    public void AumentaQuantidade()
    {
        if (money.currency >= preco){
            quantidade++;
            money.currency -= (int) preco;
            preco *= multiplicadorPreco;
            AtualizaPreco();
        }
    }

    void AtualizaPreco()
    {
        precoText.text = string.Concat("R$", ((int) preco).ToString());
    }

    void Start(){
        money = GameObject.Find("MoneyManager").GetComponent<Money>();
        preco = precoBase;
        AtualizaPreco();
    }

    void Update(){
        if (timeCounter >= 1f/(quantidade * multiplicadorBase)){
            timeCounter = 0f;
            money.currency++;
        }
        timeCounter += Time.deltaTime;
    }
}
