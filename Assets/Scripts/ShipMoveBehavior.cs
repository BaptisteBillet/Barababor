using UnityEngine;
using System.Collections;

public class ShipMoveBehavior : MonoBehaviour {

    // If the ship is currently moving
    bool m_IsMoving;
    // If the ship is currently Rotating to the left
    bool m_IsRotatingLeft;
    // If the ship is currently Rotating to the right
    bool m_IsRotatingRight;

    #region Input
    // If the player use the gamepad or the keyboard
    bool m_IsUsingGamePad;
    // Which Button the player is pushing
    bool m_Up;
    bool m_Down;
    bool m_Left;
    bool m_Right;
    #endregion 

    // Stats of the ship
    public float m_MoveSpeed;
    public float m_MoveMaxSpeed;
    public float m_RotateSpeed;
    public float m_DegreMax;


  
    //Components
    Rigidbody m_Rigidbody;
    public Animator m_MeshAnimator;


    //References
    Ship m_Ship;
    ShipCameraBehavior m_PlayerCameraBehavior;

    // Use this for initialization
    void Start ()
    {
        #region Initialisation
        //Components
        m_Rigidbody = GetComponent<Rigidbody>();

        //References
        m_Ship = GetComponent<Ship>();
        m_PlayerCameraBehavior = GetComponent<ShipCameraBehavior>();

        //Members
        m_IsUsingGamePad = false;

        m_IsMoving=false;
        m_IsRotatingLeft=false;
        m_IsRotatingRight=false;

        m_MoveMaxSpeed = m_Ship.m_CSpeed / 10;
        m_RotateSpeed = m_MoveMaxSpeed * 4;
        #endregion
    }

    // Update is called once per frame
    void Update () {

        if(m_Ship.m_CanMove==true)
        {
            if(m_MeshAnimator.enabled==false)
            {
                m_MeshAnimator.enabled = true;
            }

            m_MoveMaxSpeed = m_Ship.m_CSpeed / 10;
            m_RotateSpeed = m_MoveMaxSpeed * 4;

            //InputDetection for etablish which button is pushed 
            InputDetection();

            //Define Direction for applying the speed or the transform and the camera mouvement
            DefineDirection();

            // Move the ship
            m_Rigidbody.velocity = transform.forward * m_MoveSpeed;

            //Play the animations
            AnimationOnTheMesh();
        }
        else
        {
            m_MoveSpeed = 0;
            m_Rigidbody.velocity = Vector3.zero;
            m_MeshAnimator.enabled = false;
        }
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

    void DefineDirection()
    {
        //Front or back
        if (m_Up || m_Down)
        {
            
            if (m_Up == true)
            {
                m_MoveSpeed = m_MoveMaxSpeed;
            }
            if (m_Down == true)
            {
                m_MoveSpeed = m_MoveMaxSpeed * -1;
            }

            //If the ship is damn
            if(m_Ship.m_IsDamn==true)
            {
                m_MoveSpeed = m_MoveSpeed * -1;
            }

            m_IsMoving = true;

        }
        else
        {
            m_IsMoving = false;
            m_Rigidbody.velocity = Vector3.zero;
            m_MoveSpeed = 0;
        }

        if (m_Left ^ m_Right)
        {
            //If the ship is damn
            if (m_Ship.m_IsDamn == true)
            {
                if (!m_Left && m_Right)
                {
                    transform.Rotate(Vector3.down, m_RotateSpeed * Time.deltaTime);
                    m_IsRotatingLeft = true;
                    m_IsRotatingRight = false;

                    //Camera to the left
                    m_PlayerCameraBehavior.MoveCameraToLeft();

                }

                if (m_Left && !m_Right)
                {
                    transform.Rotate(Vector3.up, m_RotateSpeed * Time.deltaTime);
                    m_IsRotatingLeft = false;
                    m_IsRotatingRight = true;

                    //Camera to the right
                    m_PlayerCameraBehavior.MoveCameraToRight();
                }
            }
            else
            {
                if (m_Left && !m_Right)
                {
                    transform.Rotate(Vector3.down, m_RotateSpeed * Time.deltaTime);
                    m_IsRotatingLeft = true;
                    m_IsRotatingRight = false;

                    //Camera to the left
                    m_PlayerCameraBehavior.MoveCameraToLeft();

                }

                if (!m_Left && m_Right)
                {
                    transform.Rotate(Vector3.up, m_RotateSpeed * Time.deltaTime);
                    m_IsRotatingLeft = false;
                    m_IsRotatingRight = true;

                    //Camera to the right
                    m_PlayerCameraBehavior.MoveCameraToRight();
                }
            }
        }
        else
        {
            m_IsRotatingLeft = false;
            m_IsRotatingRight = false;

            //Camera to the idle
            m_PlayerCameraBehavior.MoveCameraToIdle();
        }






    }

    void AnimationOnTheMesh()
    {
        m_MeshAnimator.SetBool("IsMoving", m_IsMoving);
        m_MeshAnimator.SetBool("Left", m_IsRotatingLeft);
        m_MeshAnimator.SetBool("Right", m_IsRotatingRight);
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
