using UnityEngine;

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
    public float speed = 1f;
    private float basespeed;
    CharacterController controller;
    // Update is called once per frame
    void Update()
    {
        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed += accelerate;
            if (speed > topSpeed)
            {
                speed = topSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.RightShift))
        {
            speed += accelerate;
            if (speed > topSpeed)
            {
                speed = topSpeed;
            }
        }
        else if (speed > basespeed)
        {
            speed-=deccelerate;
            if (speed < basespeed)
            {
                speed = basespeed;
            }
        }

        

        //movement
        
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        
        controller.Move(moveDirection*speed*Time.deltaTime);
    }
}
