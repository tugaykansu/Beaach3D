using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheSphereBehaviour : MonoBehaviour
{
    public float theSphereSpeed = 9.0f;
    public Text ScoreText;

    private Vector3 angle;         // rotation angle
    private double timeLastChangeDirection;
    private double timeToChangeDirection;
    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        angle = Random.insideUnitSphere * theSphereSpeed;   
        timeLastChangeDirection = 0.0;         
        timeToChangeDirection = Random.value * 6;
    }

    // Update is called once per frame
    void Update()
    {
        if( Time.time - timeLastChangeDirection > timeToChangeDirection ){
            angle = Random.insideUnitSphere * theSphereSpeed;    // speed varies
            timeLastChangeDirection = Time.time;
            timeToChangeDirection = Random.value * 6;
        }

        if (Time.timeScale != 0) {    // if game is not over
            transform.Rotate(angle);
        }

        
    }
    
    void OnCollisionEnter(Collision collision){
        collision.gameObject.GetComponent<NeedleBehaviour>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.transform.parent = transform;
        UpdateScore();
    }

    void UpdateScore(){
        score += 10;
        ScoreText.text = "Score : " + score;
    }
}
