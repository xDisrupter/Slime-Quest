using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool movingRight = true;
    public Transform groundDetection;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
private void Update()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    if(movingRight){
    transform.Translate(2 * Time.deltaTime *speed, 0,0);
    //transform.localScale = new Vector2(2,2);
    }
    else{
        transform.Translate(-2 * Time.deltaTime * speed, 0,0);
        //transform.localScale = new Vector2(-2,2);
    }
    }

private void OnTriggerEnter(Collider collider)
{
   // if(collider.gameObject.CompareTag("turn")){
        if(movingRight ==true)
        {
            movingRight = false;
           // Debug.Log("moveing Right");
        }
        else{
            movingRight = true;
           // Debug.Log("Moving Left");
        }   
    //}
}

}
