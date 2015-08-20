using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    bool m_CanMove;

    #region Input
    bool m_IsUsingGamePad;

    public bool m_Up;
    public bool m_Down;
    public bool m_Left;
    public bool m_Right;
    #endregion 



    // Use this for initialization
    void Start ()
    {
        #region Initialisation

        m_CanMove = true;
        m_IsUsingGamePad = false;
        #endregion
    }

    // Update is called once per frame
    void Update () {
        InputDetection();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
       
    }


    void InputDetection()
    {

        #region Gamepad
        if (Input.GetAxis("L_XAxis_1") < 0)
        {
            m_Left=true;
            if(m_IsUsingGamePad==false)
            {
                m_IsUsingGamePad = true;
            }
        }
        else
        {
            m_Left = false;

        }
        if (Input.GetAxis("L_XAxis_1") > 0)
        {
            m_Right = true;
            if (m_IsUsingGamePad == false)
            {
                m_IsUsingGamePad = true;
            }
        }
        else
        {
            m_Right = false;
        }
        if (Input.GetAxis("L_YAxis_1") < 0)
        {
            m_Up = true;
            if (m_IsUsingGamePad == false)
            {
                m_IsUsingGamePad = true;
            }
        }
        else
        {
            m_Up = false;
        }
        if (Input.GetAxis("L_YAxis_1") > 0)
        {
            m_Down = true;
            if (m_IsUsingGamePad == false)
            {
                m_IsUsingGamePad = true;
            }
        }
        else
        {
            m_Down = false;
        }
        #endregion


        #region Keyboard
        if (Input.GetKey("up") || Input.GetKey(KeyCode.Z))
        {
            m_Up = true;
            if (m_IsUsingGamePad == true)
            {
                m_IsUsingGamePad = false;
            }
        }
        if(Input.GetKeyUp("up") && Input.GetKeyUp(KeyCode.Z))
        {
            m_Up = false;
        }

        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            m_Down = true;
            if (m_IsUsingGamePad == true)
            {
                m_IsUsingGamePad = false;
            }
        }
        if (Input.GetKeyUp("down") && Input.GetKeyUp(KeyCode.S))
        {
            m_Down = false;
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.Q))
        {
            m_Left = true;
            if (m_IsUsingGamePad == true)
            {
                m_IsUsingGamePad = false;
            }
        }
        if (Input.GetKeyUp("left") && Input.GetKeyUp(KeyCode.Q))
        {
            m_Left = false;
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            m_Right = true;
            if (m_IsUsingGamePad == true)
            {
                m_IsUsingGamePad = false;
            }
        }
        if (Input.GetKeyUp("right") && Input.GetKeyUp(KeyCode.D))
        {
            m_Right = false;
        }
        #endregion


    }


}

/* BUTTON
if (Input.GetButtonDown("A_1"))
{
    Debug.Log("A");
}
if (Input.GetButtonDown("B_1"))
{
    Debug.Log("B");
}
if (Input.GetButtonDown("X_1"))
{
    Debug.Log("X");
}
if (Input.GetButtonDown("Y_1"))
{
    Debug.Log("Y");
}
if (Input.GetButtonDown("Start_1"))
{
    Debug.Log("Start");
}
if (Input.GetButtonDown("Back_1"))
{
    Debug.Log("Select");
}
if (Input.GetButtonDown("LB_1"))
{
    Debug.Log("LB");
}
if (Input.GetButtonDown("RB_1"))
{
    Debug.Log("RB");
}

if (Input.GetAxis("DPad_XAxis_1")>0)
{
    Debug.Log("Pad droit");
}
if (Input.GetAxis("DPad_XAxis_1") < 0)
{
    Debug.Log("Pad gauche");
}

if (Input.GetAxis("L_XAxis_1") < 0)
{
    Debug.Log("Stick Gauche Gauche");
}
if (Input.GetAxis("L_XAxis_1") > 0)
{
    Debug.Log("Stick Gauche Droit");
}
if (Input.GetAxis("L_YAxis_1") < 0)
{
    Debug.Log("Stick Gauche Haut");
}
if (Input.GetAxis("L_YAxis_1") > 0)
{
    Debug.Log("Stick Gauche Bas");
}



if (Input.GetAxis("R_XAxis_1") < 0)
{
    Debug.Log("Stick Droit Gauche");
}
if (Input.GetAxis("R_XAxis_1") > 0)
{
    Debug.Log("Stick Droit Droit");
}
if (Input.GetAxis("R_YAxis_1") < 0)
{
    Debug.Log("Stick Droit Haut");
}
if (Input.GetAxis("R_YAxis_1") > 0)
{
    Debug.Log("Stick Droit Bas");
}
 
Debug.Log("Gachette Droite "+Input.GetAxis("TriggersR_1"));

Debug.Log("Gachette Gauche " + Input.GetAxis("TriggersL_1"));

*/
