using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float xRot = 0f;
    private float yRot = 0f;
    public GameObject followObject;
    public float camMoveSpeed = 120.0f;
    public float inputSensivity = 150.0f;
    private float inputX;
    private float inputY;
    public float clampAngle = 80.0f;
    public LayerMask enemyMask;

    

    
    


    // Start is called before the first frame update
    void Start()
    {        
        
        CursorManager.LockCursor();
        Vector3 rot = transform.localRotation.eulerAngles;
        yRot = rot.y;
        xRot = rot.x;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        
    }

    private void LateUpdate()
    {
        CameraUpdater();
        
    }

    void CameraUpdater()
    {
        Transform target = followObject.transform;

        float step = camMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

   
    }
             

    void Rotate()
    {
      
            inputX = InputManager.CameraHorziontal();
            inputY = InputManager.CameraVertical();

            yRot += inputY * inputSensivity * Time.deltaTime;
            xRot += inputX * inputSensivity * Time.deltaTime;

            yRot = Mathf.Clamp(yRot, -clampAngle, clampAngle);

      
            Quaternion localRotation = Quaternion.Euler(yRot, xRot, 0.0f);



            transform.rotation = localRotation;
            
        
    }

}
