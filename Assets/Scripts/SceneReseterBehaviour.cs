using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneReseterBehaviour : MonoBehaviour
{
    public string ResetKey = "r";
        
    void Update()
    {
        if(Input.GetKeyDown(ResetKey)){
            Time.timeScale = 1;
            SceneManager.LoadScene("Main");
        }
    }
}
