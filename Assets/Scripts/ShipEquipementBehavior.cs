using UnityEngine;
using System.Collections;

public class ShipEquipementBehavior : MonoBehaviour {

    Ship m_Ship;

    public GameObject[] m_EquipementArray = new GameObject[4];

    EquipmentShip m_EquipmentShip;

    bool m_ActionCurrentlyUsed;

    bool m_TriggerLUp;
    bool m_TriggerRUp;
	// Use this for initialization
	void Start ()
    {
        m_ActionCurrentlyUsed = false;
        m_Ship = GetComponent<Ship>();

        foreach (GameObject go in m_EquipementArray)
        {
            if (go != null)
            {
                m_EquipmentShip = go.GetComponent<EquipmentShip>();
                m_EquipmentShip.m_ShipEquipmentBehavior = this;
            }
        }
    }
	
    void ChangeTheActionCurrentlyUsed()
    {
        StopUsingAnyAction();
        m_ActionCurrentlyUsed = true;
    }

    public void StopUsingAnyAction()
    {
        m_ActionCurrentlyUsed = false;

        foreach(GameObject go in m_EquipementArray)
        {
            if(go!=null)
            {
                m_EquipmentShip = go.GetComponent<EquipmentShip>();
                m_EquipmentShip.StopUsing();
            }
        }
    }

    // Update is called once per frame
	void Update ()
    {
        #region Input Action
        if (Input.GetButtonDown("1"))
        {
            if (m_EquipementArray[0]!=null)
            {
                ChangeTheActionCurrentlyUsed();
                m_EquipmentShip = m_EquipementArray[0].GetComponent<EquipmentShip>();
            }
            
        }

        if (Input.GetButtonDown("2") || (Input.GetAxis("TriggersL_1")==1 && m_TriggerLUp==true))
        {
            m_TriggerLUp = false;
            if (m_EquipementArray[1] != null)
            {
                ChangeTheActionCurrentlyUsed();
                m_EquipmentShip = m_EquipementArray[1].GetComponent<EquipmentShip>();
            }
        }

        if (Input.GetButtonDown("3") || (Input.GetAxis("TriggersR_1") == 1 && m_TriggerRUp == true))
        {
            m_TriggerRUp = false;
            if (m_EquipementArray[2] != null)
            {
                ChangeTheActionCurrentlyUsed();
                m_EquipmentShip = m_EquipementArray[2].GetComponent<EquipmentShip>();
            }
        }

        if (Input.GetButtonDown("4"))
        {
            if (m_EquipementArray[3] != null)
            {
                ChangeTheActionCurrentlyUsed();
                m_EquipmentShip = m_EquipementArray[3].GetComponent<EquipmentShip>();
            }
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
}
