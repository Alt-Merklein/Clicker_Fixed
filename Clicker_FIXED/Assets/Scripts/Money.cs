using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Money : MonoBehaviour
{
    public long currency;
    public long income;
    public double incomeFloat;
    private int clickMultiplier;
    public long upgrade = 0, upbasic, aer, precoup;


    [Header("UI")]
    public TextMeshProUGUI textoDinheiro;

    [Header("Prefabs")]
    public GameObject coin;
    void Start(){
        currency = 0;
        clickMultiplier = 1;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (EventSystem.current.IsPointerOverGameObject()) return; //Isso é pra cliques na UI não contarem como cliques pra ganhar dinheiro
            currency += 1 * clickMultiplier;
            print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            GameObject moeda = Instantiate(coin,Camera.main.ScreenToWorldPoint(Input.mousePosition) + 10*Vector3.forward,Quaternion.identity);
            Destroy(moeda,.6f);
            FindObjectOfType<AudioManager>().PlaySound("coinClick");
        }
        if (currency < 10000) textoDinheiro.text = "R$" + currency.ToString() + ",00";
        else if (currency < 1000000) textoDinheiro.text = "R$" + ((float) currency/1000f).ToString("0.00") + "K";
        else if (currency < 1000000000000) textoDinheiro.text = "R$" + ((float) currency/1000000f).ToString("0.00") + "M";
        else textoDinheiro.text = "R$" + ((double) currency/1000000000f).ToString("0.00") + "B";

        //da dinheiro
        incomeFloat += (income * Time.deltaTime);
        if(incomeFloat >= 1)
        {
            currency += (long) incomeFloat;
            incomeFloat -= (double) ((long) incomeFloat);
        }

        if (currency >= precoup && upgrade < upbasic)
        {
            clickMultiplier *= 3;
            upgrade++;
        }

        else if (currency >= precoup && upgrade == upbasic)
        {
            //criar metodo se selecao de classes
        }

    }
}
