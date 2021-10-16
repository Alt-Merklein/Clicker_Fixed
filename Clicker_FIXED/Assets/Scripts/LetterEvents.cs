using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LetterEvents : MonoBehaviour
{
    public GameObject carta;
    public Evento[] allEvents;
    private Money money;
    private int consequenceIndex = 0;

    [Header("GUI")]
    public TextMeshProUGUI remetente;
    public TextMeshProUGUI mensagem;
    void Start(){
        money = GameObject.Find("MoneyManager").GetComponent<Money>();
        carta.SetActive(false);
    }
    
    public void Consequencias(){
        if (consequenceIndex == 1){ //80K
            money.currency += 80000;
            StartCoroutine(Desligamento());
        }
        else if (consequenceIndex == 2){
            SceneManager.LoadScene("StartScene");
        }
        EndLetter(); 
        //ADICIONAR MAIS EVENTOS AQUI
    }

    void StartLetter(Evento escolhido){
        consequenceIndex = escolhido.consequenciaIndex;
        remetente.text = escolhido.remetente;
        mensagem.text = escolhido.mensagem;
        carta.SetActive(true);
        RemoveEvento(escolhido.consequenciaIndex);

    }

    private void RemoveEvento(int index){
        foreach (Evento e in allEvents){
            if (e.consequenciaIndex == index){
                e.consequenciaIndex = 0;
                e.mensagem = "";
                e.remetente = "";
            }
        }
    }

    public void EndLetter(){
        if (consequenceIndex == 2) SceneManager.LoadScene("StartScene");
        carta.SetActive(false);
    }

    void Update(){
        if (money.currency > 1000){
            if (allEvents[0].consequenciaIndex != 0) StartLetter(allEvents[0]);
        }
    }

    IEnumerator Desligamento(){
        yield return new WaitForSeconds(30);
        StartLetter(allEvents[1]); //Evento de desligamento

    }
}