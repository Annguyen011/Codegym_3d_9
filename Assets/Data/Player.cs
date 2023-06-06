using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpForce;

    private int idle;
    private int run;
    private int walk;
    private int fall;
    private int jump;


    private void Start()
    {
        idle = Animator.StringToHash("Idle");
        run = Animator.StringToHash("Run");
        walk = Animator.StringToHash("Walk");
        fall = Animator.StringToHash("Fall");
        jump = Animator.StringToHash("Jump");
        AnimIdle();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal != 0)
        {
            rb.AddTorque(new Vector3(0, moveHorizontal* rotateSpeed), ForceMode.Force);
            
        }
        if (moveVertical != 0)
        {
            AnimWalk();
            Vector3 move = transform.forward * moveVertical;
            rb.AddForce(move * moveSpeed, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimJump();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            // Pendent
        }
        else
        {
            AnimIdle();
        }
    }
    


    [ContextMenu("Play Walk")]
    public void AnimWalk()
    {
        animator.SetBool(walk, true);
        animator.SetBool(run, false);
        animator.SetBool(idle, false);
        animator.SetBool(fall, false);
        animator.SetBool(jump, false);
    }
    [ContextMenu("Play Idle")]
    public void AnimIdle()
    {
        animator.SetBool(walk, false);
        animator.SetBool(run, false);
        animator.SetBool(idle, true);
        animator.SetBool(fall, false);
        animator.SetBool(jump, false);
    }
    [ContextMenu("Play Run")]
    public void AnimRun()
    {
        animator.SetBool(walk, false);
        animator.SetBool(run, true);
        animator.SetBool(idle, false);
        animator.SetBool(fall, false);
        animator.SetBool(jump, false);
    }
    [ContextMenu("Play Jump")]
    public void AnimJump()
    {
        animator.SetBool(walk, false);
        animator.SetBool(run, false);
        animator.SetBool(idle, false);
        animator.SetBool(fall, false);
        animator.SetBool(jump, true);
    }
    [ContextMenu("Play Fall")]
    public void AnimFall()
    {
        animator.SetBool(walk, false);
        animator.SetBool(run, false);
        animator.SetBool(idle, false);
        animator.SetBool(fall, true);
        animator.SetBool(jump, false);
    }
}
