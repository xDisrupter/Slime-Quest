using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(1f* speed * Time.deltaTime,0f,0f);
        transform.Translate(direction);
        Vector3 down = transform.TransformDirection(Vector3.down);


        bool groundInfo = Physics.Raycast(groundDetection.position, down, distance);

        if(groundInfo ==true)
        {
            Debug.Log("on ground");
        }
        else Debug.Log("Not ground");
    }
}
