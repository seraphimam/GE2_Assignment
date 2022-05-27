using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : SteeringBehaviour
{
    public GameObject targetGameObject = null;
    public GameObject enemyGameObject = null;
    public float enemyDistance = 0.0f;
    public Vector3 target = Vector3.zero;
    public float detectionRadius = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = targetGameObject.transform.position;
    }

    public override Vector3 Calculate()
    {
        if(enemyDistance < detectionRadius){
            return boid.SeekForce(target);
        }else{
            return Vector3.zero;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyGameObject != null){
            enemyDistance = (transform.position - enemyGameObject.transform.position).magnitude;
        }
        
    }
}
