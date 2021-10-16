using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Proletario : MonoBehaviour
{
    double timeCounter = 0;
    private int quantidade = 0, level = 0;
    public int levelMax = 3; //padrão é 3, mas tem alguns com 4

    public long precoBase; //preco inical
    public long precoUpBase;
    private double preco, precoup; 

    [Header("Multiplicadores")]
    [SerializeField]
    private long multiplicadorBase; //valor do minion a cada segundo
    private double[] multiplicadorDeUpBase = {2, 1.7, 1.5, 2}; //valor q aumenta ao dar update no minion
    [SerializeField]
    private double multiplicadorPreco = 1.1;
    [SerializeField]
    private double multiplicadorPrecoUp = 2;

    [Header("Textos")]
    public TextMeshProUGUI precoText;
    public TextMeshProUGUI precoUpText;
    public TextMeshProUGUI ganhosText;
    public TextMeshProUGUI quantidadeText;

    [Header("Cores")]
    public Sprite[] fotos; 
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
            quantidadeText.text = quantidade.ToString();
            money.currency -= (long) preco;
            preco *= multiplicadorPreco;
            money.income += multiplicadorBase;
            AtualizaPreco();
        }
    }

    void AtualizaPreco()
    {
        precoText.text = string.Concat("R$", ((long) preco).ToString());
        ganhosText.text = (quantidade * multiplicadorBase).ToString() + "/s";
    }

    public void LevelUp()
    {
        if (money.currency >= precoup && level < levelMax)
        {
            money.currency -= (long) precoup;
            precoup *= multiplicadorPrecoUp;
            money.income -= multiplicadorBase * quantidade;
            multiplicadorBase = (long) (((double) multiplicadorBase) * multiplicadorDeUpBase[level]);
            ganhosText.text = (quantidade * multiplicadorBase).ToString() + "/s";
            money.income += multiplicadorBase * quantidade;
            level++;
            AtualizaUp();
            
        }
    }

    void AtualizaUp()
    {
        if(level == levelMax)
        {
            precoUpText.text = "NÍVEL MÁXIMO";
        }
        else{
            precoUpText.text = string.Concat("R$", ((long) precoup).ToString());
            sprite.sprite = fotos[level];
            }
    }
    void Start(){
        money = GameObject.Find("MoneyManager").GetComponent<Money>();
        preco = precoBase;
        precoup = precoUpBase;
        sprite.sprite = fotos[0];
        AtualizaPreco();
        AtualizaUp();
    }

    void Update(){
        if (money.currency >= preco) botaoDeCompra.color = green;
        else botaoDeCompra.color = red;
    }
}
