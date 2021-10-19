using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Money : MonoBehaviour
{
    public ulong currency;
    public ulong income;
    public double incomeFloat;
    private int clickMultiplier;
    public ulong upgrade = 0, upbasic, aer, aesp, civil, comp, ele, mec, precoup;


    [Header("UI")]
    public TextMeshProUGUI textoDinheiro;
    public TextMeshProUGUI precoText;

    [Header("Prefabs")]
    public GameObject coin;
    void Start(){
        currency = 0;
        clickMultiplier = 1;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (EventSystem.current.IsPointerOverGameObject()) return; //Isso é pra cliques na UI não contarem como cliques pra ganhar dinheiro
            currency += (ulong) (1 * clickMultiplier);
            print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            GameObject moeda = Instantiate(coin,Camera.main.ScreenToWorldPoint(Input.mousePosition) + 10*Vector3.forward,Quaternion.identity);
            Destroy(moeda,.6f);
            FindObjectOfType<AudioManager>().PlaySound("coinClick");
        }
        if (currency < 10000) textoDinheiro.text = "R$" + currency.ToString() + ",00";
        else if (currency < 1000000) textoDinheiro.text = "R$" + ((double) currency/1000).ToString("0.00") + "K";
        else if (currency < 10000000000) textoDinheiro.text = "R$" + ((double) currency/1000000).ToString("0.00") + "M";
        else textoDinheiro.text = "R$" + ((double) currency/1000000000).ToString("0.00") + "B";

        //da dinheiro
        incomeFloat += (income * Time.deltaTime);
        if(incomeFloat >= 1)
        {
            currency += (ulong) incomeFloat;
            incomeFloat -= (double) ((ulong) incomeFloat);
        }

    }

    public void Upgrade(){
        if (currency >= precoup && upgrade < upbasic)
        {
            clickMultiplier *= 5;
            currency = currency - precoup;
            precoup *= 3;
            if (precoup < 10000) precoText.text = "R$" + precoup.ToString() + ",00";
            else if (precoup < 1000000) precoText.text = "R$" + ((float) precoup/1000f).ToString("0.00") + "K";
            else if (precoup < 1000000000000) precoText.text = "R$" + ((float) precoup/1000000f).ToString("0.00") + "M";
            else precoText.text = "R$" + ((double) precoup/1000000000f).ToString("0.00") + "B";
            upgrade++;
        }

        else if (currency >= precoup && upgrade == upbasic)
        {
            
        }
    }
}
