using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Proletario : MonoBehaviour
{
    double timeCounter = 0;
    private int quantidade = 0, level = 0;
    public int levelMax = 3; //padrão é 3, mas tem alguns com 4

    public ulong precoBase; //preco inical
    public ulong precoUpBase;
    private double preco, precoup; 

    [Header("Multiplicadores")]
    [SerializeField]
    private ulong multiplicadorBase; //valor do minion a cada segundo
    private double[] multiplicadorDeUpBase = {2, 1.7, 1.5, 2}; //valor q aumenta ao dar update no minion
    [SerializeField]
    private double multiplicadorPreco = 1.1;
    [SerializeField]
    private double multiplicadorPrecoUp = 2;

    [Header("Textos")]
    public string[] descricoes;
    public TextMeshProUGUI precoText;
    public TextMeshProUGUI precoUpText;
    public TextMeshProUGUI ganhosText;
    public TextMeshProUGUI quantidadeText;
    public TextMeshProUGUI nomeText;


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
            money.currency -= (ulong) preco;
            preco *= multiplicadorPreco;
            money.income += multiplicadorBase;
            AtualizaPreco();
            FindObjectOfType<AudioManager>().PlaySound("compraProletario");
        }
    }

    void AtualizaPreco()
    {
        precoText.text = string.Concat("R$", ((ulong) preco).ToString());
        ganhosText.text = ((ulong)quantidade * multiplicadorBase).ToString() + "/s";
    }

    public void LevelUp()
    {
        if (money.currency >= precoup && level < levelMax)
        {
            FindObjectOfType<AudioManager>().PlaySound("mouseClick");
            money.currency -= (ulong) precoup;
            money.income -= multiplicadorBase * (ulong) quantidade;
            multiplicadorBase = (ulong) (((double) multiplicadorBase) * multiplicadorDeUpBase[level]);
            ganhosText.text = ((ulong) quantidade * multiplicadorBase).ToString() + "/s";
            money.income += multiplicadorBase * (ulong) quantidade;
            level++;
            AtualizaUp();
            
        }
    }

    void AtualizaUp()
    {
        if(level == levelMax-1)
        {
            precoUpText.text = "NÍVEL MÁXIMO";
            sprite.sprite = fotos[level];
            nomeText.text = descricoes[level];
            precoup = 9223372036854775800;
        }
        else
        {
            precoUpText.text = string.Concat("R$", ((ulong) precoup).ToString());
            sprite.sprite = fotos[level];
            nomeText.text = descricoes[level];
            precoup *= multiplicadorPrecoUp;
        }
    }
    void Start(){
        money = GameObject.Find("MoneyManager").GetComponent<Money>();
        preco = precoBase;
        precoup = precoUpBase;
        sprite.sprite = fotos[0];
        nomeText.text = descricoes[0];
        AtualizaPreco();
        AtualizaUp();
    }

    void Update(){
        if (money.currency >= preco) botaoDeCompra.color = green;
        else botaoDeCompra.color = red;
    }
}
