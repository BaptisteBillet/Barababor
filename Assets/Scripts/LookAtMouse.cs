
using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour
{
    Vector3 last_mousePos= new Vector3();
    Vector3 mousePos = new Vector3();
    Vector4 last_GamepadPos = new Vector3();
    public Ship m_Ship;

    

    bool m_IsGamepadMode;

    bool m_AimLock;

    float angle;

    [HideInInspector]
    public int m_TrueAngle;
    void Start()
    {
        mousePos = Input.mousePosition;
        last_mousePos = mousePos;
    }

    

    void Update()
    {

        //Mouse mode
        if ((Input.GetAxis("R_XAxis_1") == 0) && (Input.GetAxis("R_YAxis_1") == 0) && m_IsGamepadMode == false)
        {
            
            mousePos = Input.mousePosition;
            mousePos.z = 0f;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = (mousePos.x - objectPos.x);
            mousePos.y = (mousePos.y - objectPos.y) * -1;
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg-90;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

            m_IsGamepadMode = false;

        }//GamePad Mode
        else if (((Input.GetAxis("R_XAxis_1") != 0) || (Input.GetAxis("R_YAxis_1") != 0)))
        {
            mousePos = new Vector3((Input.GetAxis("R_YAxis_1")), (Input.GetAxis("R_XAxis_1"))*-1, 0);
            last_GamepadPos= new Vector3((Input.GetAxis("R_YAxis_1")), (Input.GetAxis("R_XAxis_1")) * -1, 0);
            mousePos.z = 0;
            last_GamepadPos.z = 0;

            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg -90;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle,0 ));

            m_IsGamepadMode = true;

            // last_mousePos = mousePos;
        }
        else if (m_IsGamepadMode == true && (Input.GetAxis("R_XAxis_1") == 0) && (Input.GetAxis("R_YAxis_1") == 0) && m_AimLock==true)
        {
            angle = Mathf.Atan2(last_GamepadPos.y, last_GamepadPos.x) * Mathf.Rad2Deg-90;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

            m_IsGamepadMode = true;

        }


        if (Input.GetButtonDown("R_StickClick"))
        {
            m_AimLock = !m_AimLock;
        }



    }
}

/*
  //rotation
            mousePos = Input.mousePosition;
            mousePos.z = 0f;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = (mousePos.x - objectPos.x);
            mousePos.y = (mousePos.y - objectPos.y)*-1;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            Debug.Log(angle);
            m_Ship.m_AngleAttack = angle;
            m_IsGamepadMode = false;
*/


