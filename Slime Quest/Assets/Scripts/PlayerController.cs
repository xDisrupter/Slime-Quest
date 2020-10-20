using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  //  private Rigidbody rb;
    public float speed;
    [SerializeField] private float _jumpForce = 2f;
    public CharacterController controller;
    public float rotationSpeed;
    public GameObject player;

    private Vector3 moveDirection;
    public float gravityScale;
    private bool _groundedPlayer;
    private Vector3 _playerVelocity;

    Animator animator;

    public bool isWalking;
    public bool idle;
    public bool jumping;
    public float distance;
    public LayerMask whatIsLadder;
    public float inputVertical;
    public bool canClimb;
    public float inputHorizontal;

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

        // moveDirection = new Vector3(moveInput * speed, moveDirection.y, 0f);
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
        if (canClimb == true)
        {
         //   LadderMovement();
           // Debug.Log("Can Climb");
            moveDirection = new Vector3(inputHorizontal,inputVertical,0);
            controller.Move(moveDirection *Time.deltaTime*speed);
         /*   if (moveDirection != Vector3.zero)
            {
                if (inputVertical > 0 || inputVertical < 0)
                {
                    gameObject.transform.forward = new Vector3(0, 1, 0);
                }
                else
                {
                    gameObject.transform.forward = moveDirection;
                }
               // animator.SetBool("isWalking", true);
            }
            else {//animator.SetBool("isWalking", false);
            }*/
        }
        else if(canClimb==false){
           // Debug.Log("Cant climb");

            _groundedPlayer = controller.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }
            //

            // moveInput = Input.GetAxisRaw("Horizontal");
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            controller.Move(moveDirection * Time.deltaTime * speed);
            if (moveDirection != Vector3.zero)
            {
                gameObject.transform.forward = moveDirection;
                animator.SetBool("isWalking", true);
            }
            else animator.SetBool("isWalking", false);

            if (Input.GetButtonDown("Jump") && _groundedPlayer)
            {
                _playerVelocity.y += Mathf.Sqrt(_jumpForce * -3.0f * gravityScale);
                animator.SetBool("jumping", true);
            }
            else animator.SetBool("jumping", false);

            _playerVelocity.y += gravityScale * Time.deltaTime;
            controller.Move(_playerVelocity * Time.deltaTime);
        }
       
      /*  _groundedPlayer = controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
        //

        // moveInput = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(moveDirection * Time.deltaTime * speed);
        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
            animator.SetBool("isWalking", true);
        }else animator.SetBool("isWalking", false);

        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpForce * -3.0f * gravityScale);
            animator.SetBool("jumping", true);
        }else animator.SetBool("jumping", false);

        _playerVelocity.y += gravityScale * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime);*/
    }

    void LadderMovement()
    {
        if (inputVertical > 0)
        {
            Debug.Log("Go up");
          //  transform.Translate(new Vector3(0,1,0));

        }
        else if (inputVertical < 0)
        {
            Debug.Log("Go down");
           // transform.Translate(new Vector3(0,-1,0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
           // Debug.Log("This is ladder");
            canClimb = true;
          //  Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
          //  Debug.Log("Exit");
            canClimb = false;
        }
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
