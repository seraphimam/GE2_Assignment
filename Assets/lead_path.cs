using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lead_path : MonoBehaviour
{
    public int target_waypoint_id = 0;
    public float speed = 5.0f;
    public float turn_rate = 30.0f;
    public float dist = 0.0f;
    public List<Transform> pathway = new List<Transform>();
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GameObject startpoint = GameObject.Find("Waypoint_1");

        path_init(startpoint);

    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    void path_init(GameObject init_point){

        if(pathway.Count > 0){
            pathway.Clear();
        }

            pathway.Add(init_point.transform);
        
        foreach (Transform t in init_point.transform){
            pathway.Add(t);
        }

        //debug
        for (int i = 0; i < pathway.Count; i++){
            Debug.Log("pos " + i + ": " + pathway[i].position);
        }
    }

    void follow(){
        target = pathway[target_waypoint_id].transform;

        transform.position = Vector3.MoveTowards(transform.position, pathway[target_waypoint_id].position, speed * Time.deltaTime);

        var rotation = Quaternion.LookRotation(pathway[target_waypoint_id].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turn_rate * Time.deltaTime);

        arrive_point();
    }

    void arrive_point(){
        dist = (transform.position - target.position).magnitude;

        if(dist <= 0.5f){
            target_waypoint_id = (target_waypoint_id + 1) % pathway.Count;
        }
    }
}
