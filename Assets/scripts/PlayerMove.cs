using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crouching = false;
        basespeed = speed;
        controller = GetComponent<CharacterController>();
        if (gravity > 0)
        {
            gravity *= -1;
        }
        
        height=transform.localScale.y;



    }
    public float turnspeed = 2;
    public float accelerate = 0.3f;
    public float deccelerate = 0.1f;
    public float topSpeed = 5;
    public float runSpeed = 10;
    public float speed = 1f;
    public float crawlSpeed;
    private float basespeed;
    CharacterController controller;
    public GameObject cam;
    private float pitch = 0;
    private float yaw =0;
    public float pitchMax = 60;
    public float pitchMin = -60;
    private bool crouching = false;
    public float jumphight = 1.5f;
    public float gravity = -9;
    private Vector3 playerVelocity;
    private float height=1;
    public float crouchHeight=0.5f;
    public float curentHeight;
    public float getUpAndDownSpeed = 2;
    




    // Update is called once per frame
    void Update()
    {





        //sprint
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed += accelerate;
                if (speed > runSpeed)
                {
                    speed = runSpeed;
                }
            }
            else if (Input.GetKey(KeyCode.RightShift))
            {
                speed += accelerate;
                if (speed > runSpeed)
                {
                    speed = runSpeed;
                }
            }
            else if (speed > topSpeed)
            {
                speed -= deccelerate;

            }

            
        }
        else if (speed > topSpeed)
        {
            speed -= deccelerate;

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (speed < topSpeed)
            {
                speed += accelerate;
            }
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            if (speed < topSpeed)
            {
                speed += accelerate;
            }
        }
        else if (speed > basespeed)
        {
            speed -= deccelerate;

        }
        //crouch
        var cast = transform.position + new Vector3(0, curentHeight, 0);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouching = true;
            if (speed > topSpeed)
            {
                speed = topSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.RightControl))
        {
            crouching = true;
            if (speed > topSpeed)
            {
                speed = topSpeed;
            }
        }
        else if (crouching == false && Physics.Raycast(cast, Vector3.up, out RaycastHit hit, 0.2f))
        {
            crouching = true;
        }
        else
        {
            crouching = false;


        }
        crawlSpeed = speed / 2;
        


            if (crouching == true)
        {
            curentHeight -= Time.deltaTime*getUpAndDownSpeed;
            if (curentHeight <= crouchHeight)
            {
                curentHeight = crouchHeight;
            }
        }



        if (crouching == false)
        {
            curentHeight += Time.deltaTime*getUpAndDownSpeed;
            if (curentHeight >= height)
            {
                curentHeight = height;
            }
        }
        transform.localScale = new Vector3(transform.localScale.x, curentHeight, transform.localScale.z);
        //jump

        if (controller.isGrounded)
        {
            playerVelocity.y = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerVelocity.y = Mathf.Sqrt(jumphight * gravity*-1);
            }
        }
        playerVelocity.y += gravity * Time.deltaTime;






        //movement

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), playerVelocity.y, Input.GetAxis("Vertical"));
        Vector3 move = Quaternion.Euler(0,transform.eulerAngles.y,0) * moveDirection;

        if (crouching == false)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        if (crouching == true)
        {
            controller.Move(move * crawlSpeed * Time.deltaTime);
        }


        //camera
        pitch += Input.GetAxis("Mouse Y")*turnspeed;
        if (pitch < pitchMin)
        {
            pitch = pitchMin;
        }
        if (pitch > pitchMax)
        {
            pitch = pitchMax;
        }

        yaw += Input.GetAxis("Mouse X")*turnspeed;
        
        cam.transform.rotation = Quaternion.Euler(-pitch, yaw, 0);
        transform.rotation = Quaternion.Euler(0, yaw, 0);
















    }
    
    
}
