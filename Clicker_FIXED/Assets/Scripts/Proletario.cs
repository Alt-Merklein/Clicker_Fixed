using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Proletario : MonoBehaviour
{
    float timeCounter = 0;
    private int quantidade = 0, level = 1;
    public int precoBase; //preco inical
    private float preco, precoup; 
    [Header("Multiplicadores")]
    [SerializeField]
    private int multiplicadorBase; //valor do minion a cada segundo

    [SerializeField]
    private float multiplicadorPreco = 1.1f;
    [SerializeField]
    private float multiplicadorPrecoUp = 2f;

    [Header("Textos")]
    public TextMeshProUGUI precoText;
    public TextMeshProUGUI precoUpText;
    public TextMeshProUGUI ganhosText;

    [Header("Cores")]
    public Image sprite;
    public Image botaoDeCompra;
    public Color green;
    public Color red;

    [HideInInspector]
    public Money money;

    public void AumentaQuantidade()
    {
        if (money.currency >= preco){
            if (quantidade == 0){ //PRIMEIRA COMPRA
                sprite.color = new Color(1,1,1,1);
            }
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
            precoup *= multiplicadorPrecoUp;
        }
    }

    void AtualizaUp()
    {
        precoUpText.text = string.Concat("R$", ((int) precoup).ToString());
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
            ganhosText.text = (quantidade * multiplicadorBase).ToString() + "/s";
        }
        timeCounter += Time.deltaTime;
        if (money.currency >= preco) botaoDeCompra.color = green;
        else botaoDeCompra.color = red;
    }
}
