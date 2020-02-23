using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleSpawnerBehaviour : MonoBehaviour
{
        public GameObject NeedlePrefab;
        public float SpawnPeriod = 2.0f;
        
        private GameObject instantiated;
        private float lastMoveTime = 0.0f;
        private bool needleMoving = false;
        private bool iSinstantiated = true;
        
        void Start(){
            instantiated = Instantiate(NeedlePrefab, new Vector3(0, 0, -15), Quaternion.identity);
        }
    
        void Update()
        {
            if(!needleMoving && Input.GetMouseButtonDown(0) ){        // shoot
                            needleMoving = true;
                            lastMoveTime = Time.time;
                            iSinstantiated = false;
                            MoveNeedle();
            }
            
            if(Time.time - lastMoveTime > SpawnPeriod){    // wait for spawn
                            needleMoving = false;
            }
            
            if ( !needleMoving && !iSinstantiated ){    // spawn
                            InstantiateNeedle();
                            iSinstantiated = true;
            }
        }
        
        void InstantiateNeedle(){
            instantiated = Instantiate(NeedlePrefab, new Vector3(0, 0, -15), Quaternion.identity);
        }
        
        void MoveNeedle(){
            instantiated.GetComponent<NeedleBehaviour>().enabled = true;
        }
}
