﻿using UnityEngine;
using System.Collections;

public class ShipTresorBehavior : MonoBehaviour {

    #region Members
    Ship m_Ship;
    [HideInInspector]
    public float m_CooldownHullBreach;
    float m_Timer=0.1f;

    public GameObject m_TresorPrefab;

    public Transform m_EjectPosition;

    bool m_DropingTresor;
    float m_DelayForDroping=0.5f;

    bool m_ChargingTresor;
    float m_DelayForCharging = 0.5f;

    public Harbor m_Harbor;
    public Colonie m_Colonie;

    #endregion

    // Use this for initialization
    void Start ()
    {
        m_Ship = GetComponent<Ship>();
    }

    /// <summary>
    /// Manage the collision
    /// </summary>
    /// <param name="other"></param>
    #region Collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tresor")
        {
            if (m_Ship.m_CCapacity < m_Ship.m_CCapacityBase)
            {
                AddTresorFromChest();
                Destroy(other.transform.parent.gameObject);
            }
        }
      
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Colonie")
        {
            if ((other.gameObject.GetComponent<ColonieSystem>().m_Colonie.m_IsGreen==true && m_Ship.m_IsGreen==true) || (other.gameObject.GetComponent<ColonieSystem>().m_Colonie.m_IsOrange== true && m_Ship.m_IsGreen == false))
            {
                m_Ship.m_NearFromColonie = true;
                m_Colonie = other.gameObject.GetComponent<ColonieSystem>().m_Colonie;
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Colonie")
        {
                m_Ship.m_NearFromColonie = false;
                m_Colonie = null;
        }
    }
    #endregion

    #region Tresors    
    /// <summary>
    /// Adds the tresor from chest.
    /// </summary>
    void AddTresorFromChest()
    {
        if (m_Ship.m_CCapacity < m_Ship.m_CCapacityBase)
        {
            m_Ship.m_CCapacity++;
            UIManager.instance.ActualizeUITresor();
        }
    }
    /// <summary>
    /// Adds the tresor.
    /// </summary>
    public void AddTresor()
    {
        if (m_Ship.m_CCapacity<m_Ship.m_CCapacityBase)
        {
            //If Harbor
            if(m_Ship.m_NearFromHomeHarbor)
            {
                if (m_Harbor.m_HarborTresorsBehavior.CanLooseTresor())
                {
                    m_Ship.m_CCapacity++;

                    UIManager.instance.ActualizeUITresor();
                    if(m_Ship.m_IsGreen)
                    {
                        Game.instance.LooseTresor("Green", 1);
                    }
                    else
                    {
                        Game.instance.LooseTresor("Orange", 1);
                    }

                }
            }
            //If Colonie
            else if (m_Ship.m_NearFromColonie)
            {
                Debug.Log("a");
                if (m_Colonie.CanLooseTresor())
                {
                    m_Ship.m_CCapacity++;

                    UIManager.instance.ActualizeUITresor();

                    if (m_Ship.m_IsGreen)
                    {
                        Game.instance.LooseTresor("Green", 1);
                    }
                    else
                    {
                        Game.instance.LooseTresor("Orange", 1);
                    }

                }
            }
        }
    }
    /// <summary>
    /// Looses the tresor.
    /// </summary>
    public void LooseTresor()
    {
        if (m_Ship.m_CCapacity > 0)
        {
            if(m_Ship.m_NearFromHomeHarbor==true)
            {
                m_Ship.m_CCapacity--;
                m_Harbor.m_HarborTresorsBehavior.AddTresor();

                UIManager.instance.ActualizeUITresor();
                if (m_Ship.m_IsGreen)
                {
                    Game.instance.AddTresor("Green", 1);
                }
                else
                {
                    Game.instance.AddTresor("Orange", 1);
                }
            }
            else if(m_Ship.m_NearFromColonie)
            {
                m_Ship.m_CCapacity--;

                m_Colonie.AddTresor();

                UIManager.instance.ActualizeUITresor();
                if (m_Ship.m_IsGreen)
                {
                    Game.instance.AddTresor("Green", 1);
                }
                else
                {
                    Game.instance.AddTresor("Orange", 1);
                }

            }
            else
            {
                Instantiate(m_TresorPrefab, m_EjectPosition.position, m_TresorPrefab.transform.rotation);
                m_Ship.m_CCapacity--;
                UIManager.instance.ActualizeUITresor();

            }




        }
    }
    /// <summary>
    /// Looses all tresor.
    /// </summary>
    public void LooseAllTresor()
    {
        while(m_Ship.m_CCapacity>0)
        {
            LooseTresor();
        }
    }
    /// <summary>
    /// Delivers the tresor.
    /// </summary>
    public void DeliverTresor()
    {
        UIManager.instance.ActualizeUITresor();
    }
    /// <summary>
    /// cs the droping tresor.
    /// </summary>
    /// <returns></returns>
    IEnumerator CDropingTresor()
    {
        yield return new WaitForSeconds(m_DelayForCharging);
        while (m_DropingTresor && m_Ship.m_CCapacity > 0)
        {
            LooseTresor();
            yield return new WaitForSeconds(m_DelayForDroping);

        }
    }
    /// <summary>
    /// cs the charging tresor.
    /// </summary>
    /// <returns></returns>
    IEnumerator CChargingTresor()
    {
        yield return new WaitForSeconds(m_DelayForCharging);
        while (m_Ship.m_CCapacity < m_Ship.m_CCapacityBase && m_Ship.m_NearFromHomeHarbor && m_ChargingTresor)
        {
            AddTresor();
            yield return new WaitForSeconds(m_DelayForCharging);

        }
    }

    #endregion

    #region HullBreach
    public void HullBreach(float time)
    {
        StartCoroutine(CHullBreach(time));
    }

    IEnumerator CHullBreach(float time)
    {
        m_CooldownHullBreach = time;
        float delay = 0;
        while (m_CooldownHullBreach > 0)
        {
            yield return new WaitForSeconds(m_Timer);
            m_CooldownHullBreach -= m_Timer;
            delay += m_Timer;

            if (delay >= 1)
            {
                delay = 0;

                LooseTresor();
            }

        }
    }

    #endregion

    #region Input
    void Update()
    {
        //DPad Haut
        if (Input.GetAxis("DPad_YAxis_1") < 0 || Input.GetKey(KeyCode.C))
        {
            if (m_Ship.m_NearFromHomeHarbor || m_Ship.m_NearFromColonie)
            {
                if (m_ChargingTresor == false)
                {
                    m_ChargingTresor = true;
                    AddTresor();
                    StartCoroutine(CChargingTresor());
                }
            }
        }
        else
        {
            m_ChargingTresor = false;
        }
        //DPad Bas
        if (Input.GetAxis("DPad_YAxis_1") > 0 || Input.GetKey(KeyCode.V))
        {
           
                if (m_DropingTresor == false)
                {
                    m_DropingTresor = true;
                    LooseTresor();
                    StartCoroutine(CDropingTresor());
                }
        }
        else
        {
            m_DropingTresor = false;
        }

    }

    #endregion

}
