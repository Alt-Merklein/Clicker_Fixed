using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour
{
    public void BacktoMenu(){
        SceneManager.LoadScene("StartScene");
    }
}
