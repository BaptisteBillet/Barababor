using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public enum EArchetype
{
    Assault,
    Warrior,
    Raider,
    Explorer,
    Tank
}

public class Ship : MonoBehaviour {
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


    #region Constantes
    protected const int FACTORHEALTHPOINT = 100;
    protected const int FACTORSPEED = 100;
    protected const float FACTORDAMAGE = 6;
    protected const int FACTORCAPACITY = 4;
    protected const int FACTORVISION = 100;
    protected const float FACTORREGENERATION = 2;
    public const float FACTORCOOLDOWN = 100;
    public const float FACTORRESISTANCE = 100;
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
    public int m_ShipExperience;
    [Space(10)]
    public int m_CHealthPoint;
    [HideInInspector]
    public int m_CHealthPointBase;
    [Space(10)]
    public int m_CSpeed;
    [HideInInspector]
    public int m_CSpeedBase;
    [Space(10)]
    public float m_CDamage;
    [HideInInspector]
    public float m_CDamageBase;
    [Space(10)]
    public int m_CCapacity;
    [HideInInspector]
    public int m_CCapacityBase;
    [Space(10)]
    public int m_CVision;
    [HideInInspector]
    public int m_CVisionBase;
    [Space(10)]
    public float m_CRegeneration;
    [HideInInspector]
    public float m_CRegenerationBase;
    [Space(10)]
    public float m_CCooldown;
    [HideInInspector]
    public float m_CCooldownBase;
    #endregion

    [Space(10)]
    [Header("States")]
    public List<GameObject> m_ListState = new List<GameObject>();
    //

    //Elements
    [Space(10)]
    [Header("Elements")]
    public Element[] m_ArrayOfElement = new Element[4];

    //Equipment
    [Space(10)]
    [Header("Equipements")]
    public Equipment[] m_ArrayOfEquipment = new Equipment[4];

    //Others Members
    [Space(10)]
    [Header("Team")]
    public string m_Team;
    public int m_TeamNumber;
    public EArchetype m_Archetype;

    // If the player can move his ship
    [Space(10)]
    [Header("Capacities")]
    public bool m_IsDead;
    public bool m_CanMove;
    public bool m_IsDamn;
    public bool m_IsDamageable;
    public bool m_IsStateChangeable;
    public bool m_CanAttack;

    //Method Stats
    #region Stats
    [Space(10)]
    [Header("Stats")]
    
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

    public Vector3 m_StartPosition;
    public Quaternion m_StartRotation;

    //For others ship
    public int m_ExperienceWin;
    private int m_ExperienceGap;


    // Use this for initialization
    virtual public void Start ()
    {
        m_StartPosition= this.transform.position;
        m_StartRotation = this.transform.rotation;

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
            if(element!=null)
            {
                m_CHealthPointBase += element.m_HealthPoint;
                m_CSpeedBase += element.m_Speed;
                m_CDamageBase += element.m_Damage;
                m_CCapacityBase += element.m_Capacity;
                m_CVisionBase += element.m_Vision;
                m_CRegenerationBase += element.m_Regeneration;
            }
          
        }

        #endregion

        //Caracteristiques Initialisation
        ForceRefurbisment();
        //Start of the regeneration
        StartCoroutine(AutoRegeneration());
    }

    public void ForceRefurbisment()
    {
        m_CHealthPoint   = m_CHealthPointBase;
        m_CSpeed         = m_CSpeedBase;
        m_CDamage        = m_CDamageBase;
        m_CCapacity      = m_CCapacityBase;
        m_CVision        = m_CVisionBase;
        m_CRegeneration  = m_CRegenerationBase;
        m_CCooldown      = m_CCooldownBase;



        m_IsDead =false;
        m_CanMove=true;
        m_IsDamn=false;
        m_IsDamageable=true;
        m_IsStateChangeable=true;
        m_CanAttack=true;
        m_Resistance=100;
        m_Shield=0;

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
                    addingValue = (m_CSpeedBase * m_State.m_Value) / 100;
                    m_CSpeed += (int)addingValue;
                    
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;
                case "WEAKENED":
                    //Calcul of the adding value;
                    addingValue = (m_Resistance * m_State.m_Value) / 100;

                    m_Resistance += addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "CROWDED":
                    //Calcul of the adding value;
                    addingValue = (m_CCapacityBase * m_State.m_Value) / 100;
                    m_CCapacity += (int)addingValue;
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
                    addingValue = (m_CCooldownBase * m_State.m_Value) / 100;

                    m_CCooldown += (int)addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "PACIFIST":
                    //Calcul of the adding value;
                    addingValue = (m_CDamageBase * m_State.m_Value) / 100;
                    m_CDamage += (int)addingValue;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "CEASEFIRE":
                    m_CanAttack = true;
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
                    m_CanMove = true;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "DAMN":
                    m_IsDamn = false;
                    //Destroy the gameobject
                    if (m_ListState[i].gameObject != null)
                    {
                        Destroy(m_ListState[i].gameObject);
                        m_ListState.RemoveAt(i);
                    }
                    break;

                case "TERMITE":
                    //Calcul of the adding value;
                    addingValue = (m_CRegenerationBase * m_State.m_Value) / 100;
                    m_CRegeneration += (int)addingValue;
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
        for(int i=0;i<m_ListState.Count;i++)
        {
            State m_listState = m_ListState[i].GetComponent<State>();
            //If the search match
            if (m_newState.m_State== m_listState.m_State)
            {
                //In case of the same value is found
                if(m_newState.m_Value == m_listState.m_Value)
                {
                    //If the time need to be reinitialize
                    if(m_listState.m_Time>= m_newState.m_Time)
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

        if(IsOk==false)
        {
            //Change the ship to be this one;
            m_newState.m_Ship = this;
            m_ListState.Add(Instantiate(newState));
            
            //Feedback new state
        }

    }

    public bool DeleteState(GameObject stateToErase)
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
           damage = (int)((damage * (m_Resistance)) / 100);
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

        m_IsDead = true;
        m_CanMove = false;
        m_IsDamageable = false;
        m_IsStateChangeable = false;
        m_CanAttack = false;

        Game.instance.AddStat(m_Team, "Death");

        float bonusTime=0;
        //Calcul of the respawn time
        if(Game.instance.m_TimeOfPlay.minutes> FACTORTIMEEXPEND)
        {
            bonusTime = (Game.instance.m_TimeOfPlay.minutes - FACTORTIMEEXPEND) * FACTORTIMESUPP;
        }

        m_RespawnTime = FACTORRESPAWNTIME + m_ShipLevel + bonusTime;

        StartCoroutine(Respawn());
        //Feedback die
    }
    IEnumerator Respawn()
    {
        int i= (int)m_RespawnTime;
        while(i>0)
        {
            yield return new WaitForSeconds(1f);
            i--;
            Debug.Log(i);
        }
       
        ForceRefurbisment();

        //Spawn
        this.transform.position= m_StartPosition;
        this.transform.rotation= m_StartRotation;

        
    }

        //Regeneration
    IEnumerator AutoRegeneration()
    {
        while(this!=null)
        {
            while (m_IsDead == false)
            {
                yield return new WaitForSeconds(1f);
                if (m_CHealthPoint < m_CHealthPointBase)
                {
                    m_CHealthPoint += (int)m_CRegeneration;
                }

            }
            yield return new WaitForSeconds(0.1f);
        }

    }

    public enum EEnemy
    {
        SHIP,
        MOSS,
        CAMP
    }

    public void KillSomething(EEnemy type, GameObject theDead)
    {
        switch(type.ToString())
        {
            case "SHIP":
                m_ShipExperience+= theDead.GetComponent<Ship>().m_ExperienceWin;
                break;

            case "MOSS":

                break;

            case "CAMP":

                break;

        }




    }


}
