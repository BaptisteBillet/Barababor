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
        HARBORREPAIR,
        NULL
    }

    [Space(10)]
    [Header("States")]
    public List<GameObject> m_ListState = new List<GameObject>();
    //

    Ship m_Ship;

    public GameObject m_GOState;
    State m_State;

    [HideInInspector]
    public float m_TimeRegeneration=1;

    void Start()
    {
        m_Ship = GetComponent<Ship>();
        m_State = m_GOState.GetComponent<State>();
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

        UIManager.instance.ActualizeUIState();

        //Feedback reinitialization
    }


    //Commons Methods
    public void AddState(EState type,int value, float time)
    {
        m_State.m_State = type;
        m_State.m_Value = value;
        m_State.m_Time = time;

        //in case of Insentient
        if (m_Ship.m_IsStateChangeable==false)
        {
            if(m_State.m_State==EState.SLOWED || m_State.m_State == EState.WEAKENED || m_State.m_State == EState.CLUTTERED || m_State.m_State == EState.DAZZLED
                || m_State.m_State == EState.STRIKE || m_State.m_State == EState.PACIFIST || m_State.m_State == EState.CEASEFIRE || m_State.m_State == EState.ONFIRE
                || m_State.m_State == EState.HULLBREACH || m_State.m_State == EState.LOCKED || m_State.m_State == EState.DAMN || m_State.m_State == EState.TERMITE)
            {
                return;
            }
        }

        //in case of Dazzled or clairvoyance
        if (m_State.m_State == EState.CLAIRVOYANT && m_Ship.m_ShipCameraBehavior.IsDazzled)
        {
            for (int i = 0; i < m_ListState.Count; i++)
            {
                State m_listState = m_ListState[i].GetComponent<State>();
                if((m_listState.m_State == EState.DAZZLED))
                {
                    DeleteState(m_ListState[i]);
                    m_Ship.m_ShipCameraBehavior.MoveCamera("dazzled");
                    break;
                }
            }
            return;
        }
        if (m_State.m_State == EState.DAZZLED && m_Ship.m_ShipCameraBehavior.IsClairvoyant)
        {
            for (int i = 0; i < m_ListState.Count; i++)
            {
                State m_listState = m_ListState[i].GetComponent<State>();
                if ((m_listState.m_State == EState.CLAIRVOYANT))
                {
                    DeleteState(m_ListState[i]);
                    m_Ship.m_ShipCameraBehavior.MoveCamera("clairvoyant");
                    break;
                }
            }
            return;
        }

        bool IsOk = false;
        for (int i = 0; i < m_ListState.Count; i++)
        {
            State m_listState = m_ListState[i].GetComponent<State>();
            //If the search match
            if (m_State.m_State == m_listState.m_State)
            {
                //In case of the same value is found
                if (m_State.m_Value == m_listState.m_Value)
                {
                    //If the time need to be reinitialize
                    if (m_listState.m_Time >= m_State.m_Time)
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
                        m_listState.m_Cooldown = m_State.m_Time;
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
            m_State.m_Ship = m_Ship;
            m_ListState.Add(Instantiate(m_GOState));

            //Feedback new state
        }

        UIManager.instance.ActualizeUIState();
    }



    public bool DeleteState(GameObject stateToErase)
    {
        for (int i = 0; i < m_ListState.Count; i++)
        {

            if (m_ListState[i] == stateToErase)
            {
                m_ListState.RemoveAt(i);
                UIManager.instance.ActualizeUIState();
                return true;
            }
        }
        UIManager.instance.ActualizeUIState();
        return false;
    }
    /*
    public bool DeleteState(EState stateToErase)
    {
        for (int i = 0; i < m_ListState.Count; i++)
        {
            State stateScript = m_ListState[i].GetComponent<State>();
            if (stateScript.m_State == stateToErase)
            {
                m_ListState.RemoveAt(i);
                UIManager.instance.ActualizeUIState();
                return true;
            }
        }
        UIManager.instance.ActualizeUIState();
        return false;
    }*/


    public void TakeDamage(int damage)
    {
        if (m_Ship.m_IsDamageable)
        {
            //Feedback touched!
            //Calcul of the shield
            //if the damage are bigger than the shield
            if (damage >= m_Ship.m_Shield)
            {
                //The damage are reduces
                damage -= m_Ship.m_Shield;

                //The shield is destroy
                m_Ship.m_Shield = 0;
                //Feedback shield destroy

                
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

            UIManager.instance.ActualizeUILife();
        }
    }


    //Regeneration
    IEnumerator AutoRegeneration()
    {
        
        while (this != null)
        {
            while (m_Ship.m_IsDead == false)
            {
                yield return new WaitForSeconds(m_TimeRegeneration);
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
                    UIManager.instance.ActualizeUILife();
                }
                
            }
            yield return new WaitForSeconds(0.1f);
        }

    }





}
