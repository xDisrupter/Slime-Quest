using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  //  private Rigidbody rb;
    public float speed;
    [SerializeField] private float _jumpForce = 2f;
    private float moveInput;
    public CharacterController controller;
    public float rotationSpeed;
    public GameObject player;

    private Vector3 moveDirection;
    public float gravityScale;

    Animator animator;

    public bool isWalking;
    public bool idle;
    public bool jumping;

    // Start is called before the first frame update
    void Start()
    {

     controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(moveInput * speed, moveDirection.y, 0f);

        if (moveInput == 1 || moveInput == -1)
        {
            Debug.Log("is walking");
            isWalking = true;
            if (moveInput == 1)
            {
                //rotate the player 150
                //  moveDirection = transform.TransformDirection(moveInput * speed, 150, 0);
                // moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                //transform.Rotate(0, 1 * rotationSpeed, 0);
                // var forward = transform.TransformDirection(Vector3.forward);
                //controller.Move(moveDirection * Time.deltaTime);
                //float curSpeed = speed * Input.GetAxis("Vertical");
                //controller.SimpleMove(forward * curSpeed);
                //  transform.Rotate(0,1 * rotationSpeed,0);
                // transform.rotation = Quaternion.LookRotation(new Vector3 (0,0,210));
              //  Debug.Log("Rotate right");
                //transform.Rotate(Vector3.up * rotationSpeed);
                
            }
            if (moveInput == -1)
            {
                //rotate the player -150
                // moveDirection = transform.TransformDirection(moveInput * speed, -150, 0);
                // transform.Rotate();
                // transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -210));
                //transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime); 
                
            } 
            animator.SetBool("isWalking", true);
        }
        else {
           // Debug.Log("Stoped walking");
            isWalking = true;
            animator.SetBool("isWalking",false);
        }

        if (controller.isGrounded)
        {
            if (Input.GetAxis("Jump") == 1)
            {
                moveDirection.y = _jumpForce;
                animator.SetBool("jumping", true);
            }
        }
        else { animator.SetBool("jumping",false); }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        //transform.rotation = Quaternion.LookRotation(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);

    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform") && controller.isGrounded == true)
        {
           player.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }*/
}
