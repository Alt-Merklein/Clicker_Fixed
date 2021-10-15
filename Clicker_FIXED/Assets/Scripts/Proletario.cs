using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Proletario : MonoBehaviour
{
    float timeCounter = 0;
    private int quantidade = 0, level = 1;

     [SerializeField]
    private int multiplicadorBase; //valor do minion a cada segundo

    public float upgrade;

    public int precoBase; //preco inical
    private float preco, precoup; 
    private float multiplicadorPreco = 1.1f, multiplicadorPrecoup = 2f;

    public TextMeshProUGUI precoText, precoupText;

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

    void Upgrade()
    {
        if (money.currency >= precoup)
        {
            level++;
            money.currency -= (int) precoup;
            precoup *= multiplicadorPrecoup;
        }
    }

    void AtualizaUp()
    {
        precoupText.text = string.Concat("R$", ((int) precoup).ToString());
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
