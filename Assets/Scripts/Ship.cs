using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum EState
{
    BOOSTED,
    SLOWED,
    UNSINKABLE,
    CONSOLIDATED,
    SHIELD,
    WEAKENED,
    ORGANIZED,
    CROWDED,
    CLAIRVOYANT,
    DAZZLED,
    INSENSIBLE,
    REFURBISHMENT,
    STRIKE,
    ZEAL,
    MANGY,
    PACIFIST,
    CEASEFIRE,
    INFIRE,
    HULLBREACH,
    LOCKED,
    DAMN,
    REPAIR,
    TERMITE,
    NULL
}

public enum EArchetype
{
    Assault,
    Warrior,
    Raider,
    Explorer,
    Tank
}

public class Ship : MonoBehaviour {

    #region Constantes
    protected const int FACTORHEALTHPOINT = 100;
    protected const int FACTORSPEED = 100;
    protected const float FACTORDAMAGE = 6;
    protected const int FACTORCAPACITY = 4;
    protected const int FACTORVISION = 1;
    protected const float FACTORREGENERATION = 2;
    public const float FACTORCOOLDOWN = 1;
    public const float FACTORRESISTANCE = 1;
    public const float FACTORRESPAWNTIME = 10;
    public const float FACTORTIMEEXPEND = 19;
    public const float FACTORTIMESUPP = 5;
    #endregion

    #region Caracteristique
    [Header("Caracteristiques")]
    //Caracteristiques
    [Space(10)]
    public int m_ShipLevel;
    [Space(10)]
    public int m_CHealthPoint;
    public int m_CHealthPointBase;
    [Space(10)]
    public int m_CSpeed;
    public int m_CSpeedBase;
    [Space(10)]
    public float m_CDamage;
    public float m_CDamageBase;
    [Space(10)]
    public int m_CCapacity;
    public int m_CCapacityBase;
    [Space(10)]
    public int m_CVision;
    public int m_CVisionBase;
    [Space(10)]
    public float m_CRegeneration;
    public float m_CRegenerationBase;
    [Space(10)]
    public float m_CCooldown;
    public float m_CCooldownBase;
    #endregion

    [Space(10)]
    public List<State> m_ListState = new List<State>();
    //

    //Elements
    [Space(10)]
    public Element[] m_ArrayOfElement = new Element[4];

    //Equipment
    [Space(10)]
    public Equipment[] m_ArrayOfEquipment = new Equipment[4];

    //Others Members
    [Header("Team")]
    [Space(10)]
    public bool m_IsTeamBlue;
    public int m_TeamNumber;
    public EArchetype m_Archetype;

    // If the player can move his ship
    [Header("Capacities")]
    public bool m_IsDead;
    public bool m_CanMove;
    public bool m_IsDamn;
    public bool m_IsDamageable;
    public bool m_IsStateChangeable;
    public bool m_CanAttack;

    //Method Stats
    #region Stats
    [Header("Stats")]
    [Space(10)]
    public float m_Resistance;
    [Space(10)]
    public int m_Shield;
    [Space(10)]
    public float m_RespawnTime;
    [Space(10)]
    public int m_DeathCounter;
    public int m_DestroyCounter;
    public int m_AssistCounter;
    #endregion

    //Components
    PlayerMove m_PlayerMove;
    PlayerCameraBehavior m_PlayerCameraBehavior;

    // Use this for initialization
    virtual public void Start ()
    {
        //Component Initialisation
        m_PlayerMove = GetComponent<PlayerMove>();
        m_PlayerCameraBehavior = GetComponent<PlayerCameraBehavior>();


        //Elements Recuperation
        #region Recuperation
        m_CHealthPointBase  = FACTORHEALTHPOINT;
        m_CSpeedBase        = FACTORSPEED;
        m_CDamageBase       = FACTORDAMAGE;
        m_CCapacityBase     = FACTORCAPACITY;
        m_CVisionBase       = FACTORVISION;
        m_CRegenerationBase = FACTORREGENERATION;
        m_CCooldownBase     = FACTORCOOLDOWN;
        m_Resistance = FACTORRESISTANCE;
        m_ShipLevel = 1;
        m_RespawnTime = 0;
        m_DestroyCounter = 0;
        m_AssistCounter = 0;
        m_DeathCounter = 0;

        //Add the carac of the elements into the elements variables
        foreach (Element element in m_ArrayOfElement)
        {
            m_CHealthPointBase += element.m_HealthPoint;
            m_CSpeedBase += element.m_Speed;
            m_CDamageBase += element.m_Damage;
            m_CCapacityBase += element.m_Capacity;
            m_CVisionBase += element.m_Vision;
            m_CRegenerationBase += element.m_Regeneration;
        }

        #endregion

        //Caracteristiques Initialisation
        Refurbishment();

        //Start of the regeneration
        StartCoroutine(AutoRegeneration());
    }

    public void Refurbishment()
    {
        float addingValue;
        for (int i = 0; i < m_ListState.Count; i++)
        {
            switch ( m_ListState[i].m_State.ToString())
            {
                 case "SLOWED":
                    //Calcul of the adding value;
                    addingValue = (m_CSpeedBase * m_ListState[i].m_Value) / 100;
                    m_CSpeed += (int)addingValue;
                    m_ListState.RemoveAt(i);
                    break;

                case "WEAKENED":
                    //Calcul of the adding value;
                    addingValue = (m_Resistance * m_ListState[i].m_Value) / 100;

                    m_Resistance += addingValue;
                    m_ListState.RemoveAt(i);
                    break;

                case "CROWDED":
                    //Calcul of the adding value;
                    addingValue = (m_CCapacityBase * m_ListState[i].m_Value) / 100;
                    m_CCapacity += (int)addingValue;
                    m_ListState.RemoveAt(i);
                    break;

                case "DAZZLED":
                    m_ListState.RemoveAt(i);
                    break;
                case "STRIKE":
                    //Calcul of the adding value;
                    addingValue = (m_CCooldownBase * m_ListState[i].m_Value) / 100;

                    m_CCooldown += (int)addingValue;
                    m_ListState.RemoveAt(i);
                    break;

                case "PACIFIST":
                    //Calcul of the adding value;
                    addingValue = (m_CDamageBase * m_ListState[i].m_Value) / 100;
                    m_CDamage += (int)addingValue;
                    m_ListState.RemoveAt(i);
                    break;

                case "CEASEFIRE":
                    m_CanAttack = true;
                    m_ListState.RemoveAt(i);
                    break;

                case "INFIRE":
                    m_ListState[i].GetComponent<State>().m_InFireValue = 0;
                    m_ListState.RemoveAt(i);
                    break;

                case "HULLBREACH":
                    m_ListState[i].GetComponent<State>().m_HullBreachValue = 0;
                    m_ListState.RemoveAt(i);
                    break;

                case "LOCKED":
                    m_CanMove = true;
                    m_ListState.RemoveAt(i);
                    break;

                case "DAMN":
                    m_IsDamn = false;
                    m_ListState.RemoveAt(i);
                    break;

                case "TERMITE":
                    //Calcul of the adding value;
                    addingValue = (m_CRegenerationBase * m_ListState[i].m_Value) / 100;
                    m_CRegeneration += (int)addingValue;
                    m_ListState.RemoveAt(i);
                    break;
            }
        }

            //Clear all states
            m_ListState.Clear();

        //Feedback reinitialization
    }


    //Commons Methods
    public void AddState(State newState)
    {
        bool IsOk = false;
        for(int i=0;i<m_ListState.Count;i++)
        {
            //If the search match
            if(m_ListState[i].m_State== newState.m_State)
            {
                //In case of the same value is found
                if(m_ListState[i].m_Value== newState.m_Value)
                {
                    //If the time need to be reinitialize
                    if(m_ListState[i].m_Time>= newState.m_Time)
                    {
                        //Reinitialize with the first Time
                        m_ListState[i].m_Cooldown = m_ListState[i].m_Time;
                        IsOk = true;
                        //Feedback reinitialization
                        break;
                    }
                    else
                    {
                        //Reinitialize with the second Time
                        m_ListState[i].m_Cooldown = newState.m_Time;
                        IsOk = true;
                        //Feedback reinitialization
                        break;
                    }
                }
            }
        }

        if(IsOk==false)
        {
            newState.m_Ship = this;
            m_ListState.Add(newState);
            //Feedback new state
        }

    }

    public bool DeleteState(State stateToErase)
    {
        for (int i = 0; i < m_ListState.Count; i++)
        {
            if (m_ListState[i]==stateToErase)
            {
                m_ListState.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        //Feedback touched!

        //Calcul of the shield
        //if the damage are bigger than the shield
        if (damage >= m_Shield)
        {
            //The shield is destroy
            m_Shield = 0;
            //Feedback shield destroy

            //The damage are reduces
            damage -= m_Shield;
        }
        else
        {
            //The shield is reduce, no damages
            m_Shield -= damage;
            damage = 0;
        }

        //If they are damages
        if (damage > 0)
        {
           damage = (int)(damage * (m_Resistance * 100) / 100);
        }
        
        
        //If they are damages
        if (damage > 0)
        {

            //Feedback damages

            m_CHealthPoint -= damage;

            if (m_CHealthPoint <= 0)
            {
                m_CHealthPoint = 0;
                Die();
            }
        }
        


    }

    public void Die()
    {
        float bonusTime=0;
        //Calcul of the respawn time
        if(TimeOfPlay.instance.minutes> FACTORTIMEEXPEND)
        {
            bonusTime = (TimeOfPlay.instance.minutes - FACTORTIMEEXPEND) * FACTORTIMESUPP;
        }

        m_RespawnTime = FACTORRESPAWNTIME + m_ShipLevel + bonusTime;

        //Feedback die

    }


    //Regeneration
    IEnumerator AutoRegeneration()
    {
        while(m_IsDead==false)
        {
            yield return new WaitForSeconds(1f);
            m_CHealthPoint += (int)m_CRegeneration;
        }

    }

}
