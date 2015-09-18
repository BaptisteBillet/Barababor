using UnityEngine;
using System.Collections;

public class ShipDashBehavior : MonoBehaviour {

    Ship m_Ship;

    bool m_DashStick;
    bool m_FirstDashFromStick;

    float m_StickDelay;

    [HideInInspector]
    public float m_DashCoolDown;

    public bool m_IsDashReady;

    int m_Desceleration=7;
    float m_DelayDesceleration=0.001f;

    [HideInInspector]
    public float timer = 0;

    // Use this for initialization
    void Start ()
    {
        m_Ship = GetComponent<Ship>();
        m_IsDashReady = true;
        m_StickDelay = 0.5f;
        m_DashCoolDown = 7;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //If the dash can be done
        if (m_IsDashReady)
        {
            //Keyboard
            if (Input.GetButtonDown("Shift") || Input.GetButtonDown("A"))
            {
                LetsDash();
            }
        }
            //GamePad
            #region Gamepad

            /*
            if (Input.GetAxis("R_YAxis_1") < 0)
            {
                //First Dash
                if (m_FirstDashFromStick == false)
                {
                    if (m_DashStick == false)
                    {
                        m_DashStick = true;
                        m_FirstDashFromStick = true;
                        StartCoroutine(CWaitForDash());
                    }
                }
                else //Second Dash
                {
                    //Stick was relached
                    if (m_DashStick == false)
                    {
                        StopCoroutine(CWaitForDash());
                        m_DashStick = true;
                        m_FirstDashFromStick = false;
                        LetsDash();
                    }
                }

            }
            

            if (Input.GetButtonDown("A"))
            {
                LetsDash();
            }


        }

        if (Input.GetAxis("R_YAxis_1") == 0)
        {
            m_DashStick = false;
        }
        */
    }

    IEnumerator CWaitForDash()
    {
        yield return new WaitForSeconds(m_StickDelay);
        m_FirstDashFromStick = false;

    }
    #endregion

    void LetsDash()
    {
        if (m_IsDashReady == true)
        {
            m_IsDashReady = false;
            StopAllCoroutines();
            StartCoroutine(DashEffect());
            StartCoroutine(DashCooldown());
        }
    }

    IEnumerator DashCooldown()
    {
        m_DashCoolDown = m_DashCoolDown * (m_Ship.m_CCooldown / 100);

        timer = 0;
        UIManager.instance.ActualizeUIDashBar();

        while (timer < m_DashCoolDown)
        {
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
            UIManager.instance.ActualizeUIDashBar();
            m_DashCoolDown = m_DashCoolDown * (m_Ship.m_CCooldown / 100);
        }

        timer = m_DashCoolDown;
        UIManager.instance.ActualizeUIDashBar();

        m_IsDashReady = true;

    }

    IEnumerator DashEffect()
    {
        float difference = m_Ship.m_CSpeed - 500;

        m_Ship.m_CSpeed = 500;

        m_Ship.m_ShipMoveBehavior.Dash(true);

        m_Ship.m_ShipSpurBehavior.ActivateSpur(true);

        yield return new WaitForSeconds(1);

        m_Ship.m_ShipSpurBehavior.ActivateSpur(false);

        StartCoroutine(DashDescelleration((int)(m_Ship.m_CSpeed + difference)));


    }

    IEnumerator DashDescelleration(int objective)
    {
        while(m_Ship.m_CSpeed> objective)
        {
            m_Ship.m_CSpeed -= m_Desceleration;

            yield return new WaitForSeconds(m_DelayDesceleration);

        }
        m_Ship.m_ShipMoveBehavior.Dash(false);

    }
}
