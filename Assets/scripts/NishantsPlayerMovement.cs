using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float rotSpeed = 10f;

    void Update()
    {
        ForwardMovement();
        Turning();
        Actions();
    }

    private void ForwardMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walking", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
            }
        }
        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }
    }

    private void Turning()
    {
        bool turningLeft = false;
        bool turningRight = false;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotSpeed * 15 * Time.deltaTime, 0);
            turningLeft = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotSpeed * 15 * Time.deltaTime, 0);
            turningRight = true;
        }

        anim.SetBool("TurnLeft", turningLeft);
        anim.SetBool("TurnRight", turningRight);
    }

    private void Actions()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Wave");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Dance");
        }
    }
}