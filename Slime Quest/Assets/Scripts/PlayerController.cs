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

    private Vector3 moveDirection;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {

     controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      moveInput= Input.GetAxisRaw("Horizontal");
      moveDirection = new Vector3(moveInput*speed, moveDirection.y, 0f);

    if(controller.isGrounded)
    {
      if(Input.GetAxis("Jump") ==1)
      {
          moveDirection.y = _jumpForce;
      }
    }

      moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
      controller.Move(moveDirection*Time.deltaTime);
    }
}
