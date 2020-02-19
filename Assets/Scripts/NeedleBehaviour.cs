using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleBehaviour : MonoBehaviour
{
    public float NeedleSpeed = 6.0f;
    
	private Text GameOverText;

	void Start()
    {
        GameOverText = GameObject.FindWithTag("Finish").GetComponent<Text>();
    }    

    void Update()
    {
        TranslateNeedle();
    }
    
    
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Needle"))
            {
                GameOver();
            }
    }

	void GameOver(){
		GameOverText.text = "Game Over";
		Time.timeScale = 0;
	}

	void TranslateNeedle(){
		transform.Translate(Vector3.forward * Time.deltaTime * NeedleSpeed);
	}
}
