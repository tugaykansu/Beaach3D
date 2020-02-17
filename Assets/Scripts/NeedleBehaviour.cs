using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleBehaviour : MonoBehaviour
{
    public float NeedleSpeed = 1.0f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * NeedleSpeed);
    }
    
    
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Needle"))
            {
                // GAME OVER
                Debug.Log (" GAME OVER ");
            }
    }
}
