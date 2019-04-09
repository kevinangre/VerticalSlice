using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Animator anim;
    private Rigidbody rb;
    private float moveAmount;
    [Header("Stats")]
    public float moveSpeed = 2f;
    public float rotateSpeed = 3f;
    [HideInInspector]
    public float runSpeed = 3.5f;
    [HideInInspector]
    private bool run;

    Vector3 moveDir;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        UpdateMovement();


        Movement();
        HandleAnimations();
    }



    private void UpdateMovement()
    {
        Vector3 v = InputManager.PlayerVertical() * Camera.main.transform.forward;
        Vector3 h = InputManager.PlayerHorizontal() * Camera.main.transform.right;
        moveDir = (v + h).normalized;
        float m = Mathf.Abs(InputManager.PlayerHorizontal()) + Mathf.Abs(InputManager.PlayerVertical());
        moveAmount = Mathf.Clamp(m, 0, 1);

    }
    private void Movement()
    {
        float targetSpeed = moveSpeed;
        if (run)
        {
            targetSpeed = runSpeed;
        }

        rb.velocity = moveDir * (targetSpeed * moveAmount);

        Vector3 targetDir = moveDir;
        targetDir.y = 0;
        if (targetDir == Vector3.zero)
            targetDir = transform.forward;
        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, Time.deltaTime * moveAmount * rotateSpeed);
        transform.rotation = targetRotation;

    }
    private void HandleAnimations()
    {
        anim.SetFloat("vertical", moveAmount, 0.4f, Time.deltaTime);
    }

 
}
