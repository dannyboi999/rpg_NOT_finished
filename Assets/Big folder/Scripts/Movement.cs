using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public CharacterController controller;
    public Transform cam;
    Camera camm;
    public Interactable focus;

    [SerializeField]
    private float speed = 6f;
    [SerializeField]
    private float gravity = 1f;
    [SerializeField]
    private float jumpSpeed = 3.5f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float directionY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camm = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;


        //makes it walk around 

        Vector3 movement = new Vector3(0, 0, 0);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            movement += moveDir.normalized * speed;
        }

        //makes it jump 
        if (controller.isGrounded)//no double jump 
        {
            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpSpeed;
            }
        }

        directionY -= gravity * Time.deltaTime;//gravity 

        movement += directionY * Vector3.up * jumpSpeed;//jump thing 

        //this makes it all happen at once the jump maff and the move maff
        controller.Move(movement * Time.deltaTime);

        //interactible things 
        if (Input.GetMouseButtonDown(1)) //draws a line from the player to where the camera is facing 
        {
            Ray ray = camm.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    Setfocus(interactable);
                }
                else
                {
                    Setfocus(null);
                    focus.OnDefocused();
                }
            }
        }
    }
    void Setfocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }
}
