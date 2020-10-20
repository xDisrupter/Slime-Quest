using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _health;
    public float _maxHealth;
    public float _damageRate;
    private float inputVertical;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
     transform.position= new Vector3(0,0.5f,0);
        animator = GetComponent<Animator>();
     //rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            Debug.Log("Player Health Decreases by 1 "+ _health);
            _health -= (_damageRate*Time.deltaTime);
            animator.SetBool("takingDMG",true);
        }

        if (other.gameObject.CompareTag("Health Pickup"))
        {
            _health += 1;
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
             if (other.gameObject.CompareTag("SpikeTrap"))
        {
            SpikeTrapDemo spiketrap = other.gameObject.GetComponent<SpikeTrapDemo>();
            if (spiketrap.takeDmg)
            {
                _health -= (_damageRate * Time.deltaTime);
            }          
        }

        if (other.CompareTag("TwoWayPlatform"))
        {
            // Debug.Log("Working");
            
          BoxCollider bx=  other.gameObject.GetComponent<BoxCollider>();
            if (transform.position.y > other.gameObject.transform.position.y)
            { 
            bx.isTrigger = false;
                if (inputVertical < 0)
                {
                    bx.isTrigger = true;
                }
            }

            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("takingDMG", false);
        }

        if (other.CompareTag("TwoWayPlatform"))
        {
            // Debug.Log("Working");
            
          BoxCollider bx=  other.gameObject.GetComponent<BoxCollider>();
            bx.isTrigger=true;

            
        }

    }
}
