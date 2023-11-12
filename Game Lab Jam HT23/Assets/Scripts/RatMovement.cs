using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RatMovement : MonoBehaviour
{
    [SerializeField] RatActions actions;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] Animator anim;
    [SerializeField] Collider groundCheckBox;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] DayNightCycle dayNight;
    [SerializeField] GameObject radius;
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
        if (!dayNight.Night)
        {
            return;
        }


        CheckGrounded();
        
        Vector2 inputValue = actions.Patrick.Movement.ReadValue<Vector2>();
        //Vector3 movementValue = inputValue.y;

        if(inputValue.y != 0)
        {
            transform.position += transform.forward * inputValue.y * speed * Time.deltaTime;
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

        if(inputValue.x != 0)
        {
            transform.Rotate(new Vector3(0, inputValue.x, 0) * rotationSpeed * Time.deltaTime);
            //transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (!isGrounded)
        {
            radius.SetActive(false);
        }
        else
        {
            radius.SetActive(true);
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

        if (isGrounded)
            anim.SetBool("IsJumping", false);
        else
            anim.SetBool("IsJumping", true);

    }
}
