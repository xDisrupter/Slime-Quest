using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _health;
    public float _damageRate;

    // Start is called before the first frame update
    void Start()
    {
     transform.position= new Vector3(0,0.5f,0); 
     //rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            Debug.Log("Player Health Decreases by 1 "+ _health);
            _health -= (_damageRate*Time.deltaTime);
        }
    }
}
