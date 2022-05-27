using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public GameObject focusTarget;
    // Start is called before the first frame update
    void Start()
    {
        focusTarget = GameObject.Find("transport");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = focusTarget.transform.position + new Vector3(0, 0, -1);
        //transform.LookAt(focusTarget.transform);
        transform.rotation = Quaternion.Lerp(transform.rotation, focusTarget.transform.rotation, 0.1f);
    }
}
