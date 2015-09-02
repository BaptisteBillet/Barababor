using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipStateAndDamageBehavior : MonoBehaviour {

    public enum EState
    {
        BOOSTED,
        SLOWED,
        UNSINKABLE,
        CONSOLIDATED,
        SHIELD,
        WEAKENED,
        ORGANIZED,
        CLUTTERED,
        CLAIRVOYANT,
        DAZZLED,
        INSENTIENT,
        REFURBISHMENT,
        STRIKE,
        ZEAL,
        WARHUNGRY,
        PACIFIST,
        CEASEFIRE,
        ONFIRE,
        HULLBREACH,
        LOCKED,
        DAMN,
        REPAIR,
        TERMITE,
        NULL
    }

    [Space(10)]
    [Header("States")]
    public List<GameObject> m_ListState = new List<GameObject>();
    //

    Ship m_Ship;

    void Start()
    {
        m_Ship = GetComponent<Ship>();

        //Start of the regeneration
        StartCoroutine(AutoRegeneration());
    }

    public void Refurbishment(GameObject go)
    {

        float addingValue;
        for (int i = 0; i < m_ListState.Count; i++)
        {
            State m_State = m_ListState[i].GetComponent<State>();

            switch (m_State.m_State.ToString())
            {

                case "SLOWED":
                    //Calcul of the adding value;
                    addingValue = (m_Ship.m_CSpeedBase * m_State.m_Value) / 100;
                    m_Ship.m_CSpeed += (int)addingValue;

                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;
                case "WEAKENED":
                    //Calcul of the adding value;
                    addingValue = (m_Ship.m_Resistance * m_State.m_Value) / 100;

                    m_Ship.m_Resistance += addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "CROWDED":
                    //Calcul of the adding value;
                    addingValue = (m_Ship.m_CCapacityBase * m_State.m_Value) / 100;
                    m_Ship.m_CCapacity += (int)addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "DAZZLED":

                    break;
                case "STRIKE":
                    //Calcul of the adding value;
                    addingValue = (m_Ship.m_CCooldownBase * m_State.m_Value) / 100;

                    m_Ship.m_CCooldown += (int)addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "PACIFIST":
                    //Calcul of the adding value;
                    addingValue = (m_Ship.m_CDamageBase * m_State.m_Value) / 100;
                    m_Ship.m_CDamage += (int)addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "CEASEFIRE":
                    m_Ship.m_CanAttack = true;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "INFIRE":
                    //m_ListState[i].GetComponent<State>().m_InFireValue = 0;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "HULLBREACH":
                    //m_ListState[i].GetComponent<State>().m_HullBreachValue = 0;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "LOCKED":
                    m_Ship.m_CanMove = true;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "DAMN":
                    m_Ship.m_IsDamn = false;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "TERMITE":
                    //Calcul of the adding value;
                    addingValue = (m_Ship.m_CRegenerationBase * m_State.m_Value) / 100;
                    m_Ship.m_CRegeneration += (int)addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "REFURBISHMENT":
                    Debug.Log("a");
                    Destroy(m_ListState[i].gameObject);
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;
            }



        }



        //Feedback reinitialization
    }


    //Commons Methods
    public void AddState(GameObject newState)
    {
        State m_newState = newState.GetComponent<State>();
        bool IsOk = false;
        for (int i = 0; i < m_ListState.Count; i++)
        {
            State m_listState = m_ListState[i].GetComponent<State>();
            //If the search match
            if (m_newState.m_State == m_listState.m_State)
            {
                //In case of the same value is found
                if (m_newState.m_Value == m_listState.m_Value)
                {
                    //If the time need to be reinitialize
                    if (m_listState.m_Time >= m_newState.m_Time)
                    {
                        //Reinitialize with the first Time
                        m_listState.m_Cooldown = m_listState.m_Time;
                        IsOk = true;
                        //Feedback reinitialization
                        break;
                    }
                    else
                    {
                        //Reinitialize with the second Time
                        m_listState.m_Cooldown = m_newState.m_Time;
                        IsOk = true;
                        //Feedback reinitialization
                        break;
                    }
                }
            }
        }

        if (IsOk == false)
        {
            //Change the ship to be this one;
            m_newState.m_Ship = m_Ship;
            m_ListState.Add(Instantiate(newState));

            //Feedback new state
        }

        UIManager.instance.UIState();

    }

    public bool DeleteState(GameObject stateToErase)
    {

        for (int i = 0; i < m_ListState.Count; i++)
        {

            if (m_ListState[i] == stateToErase)
            {
                m_ListState.RemoveAt(i);
                UIManager.instance.UIState();
                return true;
            }
        }
        UIManager.instance.UIState();
        return false;
    }

    public void TakeDamage(int damage)
    {
        //Feedback touched!
        //Calcul of the shield
        //if the damage are bigger than the shield
        if (damage >= m_Ship.m_Shield)
        {
            //The shield is destroy
            m_Ship.m_Shield = 0;
            //Feedback shield destroy

            //The damage are reduces
            damage -= m_Ship.m_Shield;
        }
        else
        {
            //The shield is reduce, no damages
            m_Ship.m_Shield -= damage;
            damage = 0;
        }

        //If they are damages
        if (damage > 0)
        {
            damage = (int)((damage * (m_Ship.m_Resistance)) / 100);
        }

        //If they are damages
        if (damage > 0)
        {
            //Feedback damages
            //CameraEventManager.emit(EventManagerType.FISHEYEBUMP);

            m_Ship.m_CHealthPoint -= damage;

            if (m_Ship.m_CHealthPoint <= 0)
            {
                m_Ship.m_CHealthPoint = 0;

                m_Ship.m_ShipDeathBehavior.Die();
            }
        }

        UIManager.instance.UILife();

    }


    //Regeneration
    IEnumerator AutoRegeneration()
    {
        
        while (this != null)
        {
            while (m_Ship.m_IsDead == false)
            {
                yield return new WaitForSeconds(1f);
                if(m_Ship.m_IsDead == false)
                {
                    if (m_Ship.m_CHealthPoint < m_Ship.m_CHealthPointBase)
                    {
                        m_Ship.m_CHealthPoint += (int)m_Ship.m_CRegeneration;

                    }
                    if (m_Ship.m_CHealthPoint > m_Ship.m_CHealthPointBase)
                    {
                        m_Ship.m_CHealthPoint = m_Ship.m_CHealthPointBase;
                    }
                    UIManager.instance.UILife();
                }
                
            }
            yield return new WaitForSeconds(0.1f);
        }

    }


}
