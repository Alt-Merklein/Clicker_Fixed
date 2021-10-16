using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadCredits(){
        SceneManager.LoadScene("Creditos");
    }
    public void BacktoMenu(){
        SceneManager.LoadScene("StartScene");
    }
    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
