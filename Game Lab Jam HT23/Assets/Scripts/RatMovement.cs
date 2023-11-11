using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RatMovement : MonoBehaviour
{
    [SerializeField] RatActions actions;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] Animator anim;
    [SerializeField] Collider groundCheckBox;
    [SerializeField] LayerMask groundLayerMask;
    Rat rat;
    void Start()
    {
        actions = new RatActions();
        rat = GetComponent<Rat>();
        actions.Patrick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        
        Vector2 inputValue = actions.Patrick.Movement.ReadValue<Vector2>();
        Vector3 movementValue = new Vector3(inputValue.x, 0, inputValue.y);

        if(movementValue != Vector3.zero)
        {
            transform.position += movementValue * speed * Time.deltaTime;
            //transform.position += Vector3.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementValue), 0.025f);
            anim.SetBool("IsMoving", true);

        }
        else
        {
            anim.SetBool("IsMoving", false);
        }


    }

    public void Jump()
    {
        if (!isGrounded)
            return;

        GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
    }

    public void CheckGrounded()
    {
        isGrounded = Physics.CheckBox(groundCheckBox.bounds.center, groundCheckBox.bounds.extents, Quaternion.identity, groundLayerMask);
        
    }

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    if (context.performed && !movementLocked && !actionLocked && !dead)
    //        movement.Jump();

    //    if (context.canceled.)
    //}
}
