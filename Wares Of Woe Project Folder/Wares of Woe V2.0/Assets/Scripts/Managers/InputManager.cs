using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static float PlayerVertical() 
    {
        float vertical = Input.GetAxis("Vertical");
        return vertical;
        
    }

    public static float PlayerHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal");
        return horizontal;
    }
  
    
    public static float CameraVertical()
    {

        float inputY = 0.0f;
        if(Input.GetAxis("Mouse Y") != 0)
        {
            inputY = Input.GetAxis("Mouse Y");
        }else if(Input.GetAxis("RightStickVert") != 0)
        {
            inputY = Input.GetAxis("RightStickVert");
        }

        return inputY;
    }

    public static float CameraHorziontal()
    {
        float inputX = 0.0f;
        if(Input.GetAxis("Mouse X") != 0)
        {
            inputX = Input.GetAxis("Mouse X");
        }
        else if(Input.GetAxis("RightStickHorz") != 0)
        {
            inputX = Input.GetAxis("RightStickHorz");
        }

        return inputX;
    }
}
