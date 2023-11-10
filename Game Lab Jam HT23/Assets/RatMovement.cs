using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RatMovement : MonoBehaviour
{
    [SerializeField] MouseActions actions;
    [SerializeField] float speed;
    [SerializeField] Animator anim;
    void Start()
    {
        actions = new MouseActions();
        actions.Actions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 inputValue = actions.Actions.Movement.ReadValue<Vector2>();
        Vector3 movementValue = new Vector3(inputValue.x, 0, inputValue.y);

        if(movementValue != Vector3.zero)
        {
            transform.position += movementValue;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementValue), 0.25f);
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }


    }

    public void OnMovement(InputValue value)
    {
        transform.position += new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y) * speed * Time.deltaTime;
    }

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    if (context.performed && !movementLocked && !actionLocked && !dead)
    //        movement.Jump();

    //    if (context.canceled.)
    //}
}
