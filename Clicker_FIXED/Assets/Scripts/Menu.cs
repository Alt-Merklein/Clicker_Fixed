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
}
