using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinVariante;
    public Vector3[] spawnPoints;
    private float timeCounter = 0;

    void Update(){
        int indexEscolhido = Random.Range(0, spawnPoints.Length - 1);
        if (timeCounter >= 1.5f){
            GameObject moeda = Instantiate(coinVariante, spawnPoints[indexEscolhido], Quaternion.identity);
            Destroy(moeda, 10);
            timeCounter = 0;
        }
        timeCounter += Time.deltaTime;
    }
}
