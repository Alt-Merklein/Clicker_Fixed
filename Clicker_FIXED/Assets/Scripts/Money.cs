using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Money : MonoBehaviour
{
    public long currency;
    private int clickMultiplier;

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
        }
        if (currency < 10000) textoDinheiro.text = "R$" + currency.ToString() + ",00";
        else if (currency < 1000000) textoDinheiro.text = "R$" + ((float) currency/1000f).ToString("0.00") + "K";
    }
}
