using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : SteeringBehaviour
{
    public Boid target;
    public GameObject scout;
    public float initDistance;
    public float distance;

    Vector3 targetPos;

    public bool detected = false;

    // Start is called before the first frame update
    void Start()
    {
        scout = GameObject.Find("red_scout");
        initDistance = (transform.position - scout.transform.position).magnitude;
    }

    public override Vector3 Calculate()
    {
        if(detected){
            float dist = Vector3.Distance(target.transform.position, transform.position);
            float time = dist / boid.maxSpeed;

            targetPos = target.transform.position + (target.velocity * time);

            return boid.SeekForce(targetPos);
        }else{
            return Vector3.zero;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (transform.position - scout.transform.position).magnitude;
        if(distance < (initDistance - 20.0f)){
            detected = true;
        }

    }
}
