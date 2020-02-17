using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSphereBehaviour : MonoBehaviour
{
    public float theSphereSpeed = 9.0f;

    private Vector3 angle;
    private double timeLastChangeDirection;
    private double timeToChangeDirection;
    
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
            angle = Random.insideUnitSphere * theSphereSpeed;
            timeLastChangeDirection = Time.time;
            timeToChangeDirection = Random.value * 6;
        }
        transform.Rotate(angle);
    }
    
    void OnCollisionEnter(Collision collision){
        collision.gameObject.GetComponent<NeedleBehaviour>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.transform.parent = transform;
    }
}
