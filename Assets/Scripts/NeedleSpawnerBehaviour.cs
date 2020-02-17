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
            if(!needleMoving && Input.GetMouseButtonDown(0) ){
                            needleMoving = true;
                            lastMoveTime = Time.time;
                            iSinstantiated = false;
                            MoveNeedle();
            }
            
            if(Time.time - lastMoveTime > SpawnPeriod){
                            needleMoving = false;
            }
            
            if ( !needleMoving && !iSinstantiated ){
                            InstantiateNeedle();
                            iSinstantiated = true;
            }
            
            
            /*if(Time.time - lastMoveTime > SpawnPeriod){
                needleMoving = false;
                lastMoveTime = Time.time;
            }
            
            if ( !needleMoving && !iSinstantiated ){
                InstantiateNeedle();
                iSinstantiated = true;
            }
                    
            if( Input.GetMouseButtonDown(0) ){
                needleMoving = true;
                iSinstantiated = false;
                MoveNeedle();
            }*/
            
            /*if( Input.GetMouseButtonDown(0) && Time.time - lastMoveTime > SpawnPeriod ){
                lastMoveTime = Time.time;
                InstantiateNeedle();
                MoveNeedle();
            }*/
        }
        
        void InstantiateNeedle(){
            instantiated = Instantiate(NeedlePrefab, new Vector3(0, 0, -15), Quaternion.identity);
        }
        
        void MoveNeedle(){
            instantiated.GetComponent<NeedleBehaviour>().enabled = true;
        }
}
