using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _jumpForce = 2f;
    [Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;
    
    [SerializeField] private bool _airControl = false;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _ceilingCheck;

    const float groundRadius = .2f;
    private bool grounded;
    const float ceilingRadius = .2f;
    private Vector3 velocity = Vector3.zero;
    

    public float horizontal_Input;
    public float vertical_Input;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
     transform.position= new Vector3(0,0.5f,0); 
     //rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // transform.Translate(Vector3.right* _speed * Time.deltaTime);

       /* horizontal_Input = Input.GetAxis("Horizontal") * Time.deltaTime *_speed;
        vertical_Input = Input.GetAxis("Jump")* Time.deltaTime *_speed;
        //Debug.Log(vertical_Input);
        transform.Translate(horizontal_Input, vertical_Input, 0);
        if(vertical_Input ==1)
        {
            //transform.Translate(Vector3.up*vertical_Input* _speed *Time.deltaTime);
            rb.AddForce(new Vector3(0,_jumpForce,0),ForceMode.Impulse);
           // rb.AddForce(new Vector3(0f, _jumpForce,0));
           //transform.Translate(Vector3.up* vertical_Input * _speed * Time.deltaTime);
        }*/
        //transform.Translate(Vector3.right* horizontal_Input * _speed * Time.deltaTime);
        
        //vertical_Input = Input.GetAxis("Jump")* Time.deltaTime *_speed;
        //if(vertical_Input==1)
       // rb.AddForce(new Vector3(0f,_jumpForce,0));
        //transform.Translate(Vector3.up* vertical_Input * _speed * Time.deltaTime);

    }
}
