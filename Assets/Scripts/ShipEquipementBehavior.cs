using UnityEngine;
using System.Collections;

public class ShipEquipementBehavior : MonoBehaviour {

    //Main Parent
    [HideInInspector]
    public Ship m_Ship;

    //Action List of Equipment
    public GameObject[] m_EquipmentArray = new GameObject[4];

    //Instance
    EquipmentShip m_EquipmentShip;

    //To be sure the player can't use an action that is currently used
    bool m_ActionCurrentlyUsed;

    //For Gamepad
    bool m_TriggerLUp;
    bool m_TriggerRUp;

    //ViewPoint
    [HideInInspector]
    public ShipViewPoint m_ShipViewPoint;

    public GameObject m_ShipAims;
    public LookAtMouse m_DirectionScript;

	// Use this for initialization
	void Awake ()
    {
        //No action currently used
        m_ActionCurrentlyUsed = false;

        //Get the main script
        m_Ship = GetComponent<Ship>();

        m_ShipViewPoint = GetComponent<ShipViewPoint>();

        int number = -1;

        //If they are Equipment equipt in the Equipment Array, then we linked it to this script
        foreach (GameObject go in m_EquipmentArray)
        {
            if (go != null)
            {
                if(go.GetComponent<EquipmentShip>())
                {
                    m_EquipmentShip = go.GetComponent<EquipmentShip>();
                    m_EquipmentShip.m_ShipEquipmentBehavior = this;
                    number++;
                    m_EquipmentShip.m_ActionNumber = number;
                }
            }
        }
    }
	

    void ChangeTheActionCurrentlyUsed(int number)
    {

        if(m_EquipmentShip!= m_EquipmentArray[number].GetComponent<EquipmentShip>())
        {
            //We stop other action
            StopUsingAnyAction();
            m_EquipmentShip = m_EquipmentArray[number].GetComponent<EquipmentShip>();
        }
        //Let's do the action, aim first, use after
        m_EquipmentShip.EquipmentManager();

        //We currently use an action
        m_ActionCurrentlyUsed = true;
    }

    public void StopUsingAnyAction()
    {
        m_ActionCurrentlyUsed = false;

        foreach(GameObject go in m_EquipmentArray)
        {
            if(go!=null)
            {
                m_EquipmentShip = go.GetComponent<EquipmentShip>();
                m_EquipmentShip.StopUsing();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        #region Input Action
        if (Input.GetButtonDown("1"))
        {
            ButtonAction(1);

        }

        if (Input.GetButtonDown("2") || (Input.GetAxis("TriggersL_1") == 1 && m_TriggerLUp == true))
        {
            m_TriggerLUp = false;
            ButtonAction(2);
        }

        if (Input.GetButtonDown("3") || (Input.GetAxis("TriggersR_1") == 1 && m_TriggerRUp == true))
        {
            m_TriggerRUp = false;
            ButtonAction(3);
        }

        if (Input.GetButtonDown("4"))
        {
            ButtonAction(4);
        }
        #endregion

        //For reset Triggers
        if (Input.GetAxis("TriggersR_1") == 0)
        {
            m_TriggerRUp = true;
        }

        if (Input.GetAxis("TriggersL_1") == 0)
        {
            m_TriggerLUp = true;
        }

        //For Canceling any action button
        if (Input.GetButtonDown("B"))
        {
            StopUsingAnyAction();
        }
    }

    public void ButtonAction(int number)
    {
        if (m_EquipmentArray[number-1] != null)
        {
            ChangeTheActionCurrentlyUsed(number-1);
            UIManager.instance.ButtonActionAnimator(number - 1, "Use");
        }
    }

    public int GetAngleOfAims()
    {
        int angle;
        angle = (int)(m_DirectionScript.transform.localRotation.eulerAngles.y);
        if( angle<0)
        {
            angle += 359;
        }
        return angle;
    }

}
