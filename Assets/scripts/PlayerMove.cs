using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        basespeed = speed;
        controller = GetComponent<CharacterController>();



    }

    public float accelerate = 0.5f;
    public float deccelerate = 0.5f;
    public float topSpeed = 10;
    public float runSpeed = 20;
    public float speed = 1f;
    private float basespeed;
    CharacterController controller;
    public GameObject cam;
    private float pitch = 0;
    private float yaw =0;
    public float pitchMax = 60;
    public float pitchMin = -60;


    // Update is called once per frame
    void Update()
    {
        
        
        
        
        //sprint
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
        else if (speed > basespeed)
        {
            speed -= deccelerate;
            if (speed < basespeed)
            {
                speed = basespeed;
            }
        }

        

        //movement

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = Quaternion.Euler(0,transform.eulerAngles.y,0) * moveDirection;
        

        controller.Move(move * speed * Time.deltaTime);


        //camera
        pitch += Input.GetAxis("Mouse Y");
        if (pitch < pitchMin)
        {
            pitch = pitchMin;
        }
        if (pitch > pitchMax)
        {
            pitch = pitchMax;
        }

        yaw += Input.GetAxis("Mouse X");
        
        cam.transform.rotation = Quaternion.Euler(-pitch, yaw, 0);
        transform.rotation = Quaternion.Euler(0, yaw, 0);
















    }
    
    

}
