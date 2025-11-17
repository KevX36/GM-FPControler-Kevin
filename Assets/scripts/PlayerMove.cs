using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        basespeed = speed;




    }
    
    

    public float speed = 1f;
    private float basespeed;

    // Update is called once per frame
    void Update()
    {
        //movement
        Vector3 move = transform.position;
         
         
        if (Input.GetKey(KeyCode.W))
        {
            move.z++;
            transform.position = Vector3.MoveTowards(transform.position,move,speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x--;
            transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            move.x++;
            transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.z--;
            transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.deltaTime);
        }
        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed++;
            if (speed > basespeed * 2)
            {
                speed = basespeed * 2;
            }
        }
        else if (Input.GetKey(KeyCode.RightShift))
        {
            speed++;
            if (speed > basespeed * 2)
            {
                speed = basespeed * 2;
            }
        }
        else if (speed > basespeed)
        {
            speed--;
            if (speed< basespeed)
            {
                speed = basespeed;
            }
        }
    }
}
