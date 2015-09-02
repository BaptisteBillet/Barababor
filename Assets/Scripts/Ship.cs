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


    #region Constantes
    [HideInInspector]
    public int FACTORHEALTHPOINT = 100;
    [HideInInspector]
    public int FACTORSPEED = 100;
    [HideInInspector]
    public float FACTORDAMAGE = 6;
    [HideInInspector]
    public int FACTORCAPACITY = 4;
    [HideInInspector]
    public int FACTORVISION = 100;
    [HideInInspector]
    public float FACTORREGENERATION = 2;
    [HideInInspector]
    public float FACTORCOOLDOWN = 100;
    [HideInInspector]
    public float FACTORRESISTANCE = 100;
    [HideInInspector]
    public float FACTORRESPAWNTIME = 10;
    [HideInInspector]
    public float FACTORTIMEEXPEND  = 19;
    [HideInInspector]
    public float FACTORTIMESUPP = 5;
    #endregion


    #region Caracteristiques
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
    public bool m_IsBlue;
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
    public int m_DeathCounter;
    public int m_DestroyCounter;
    public int m_AssistCounter;
    #endregion

    //Components
    [HideInInspector]
    public ShipMoveBehavior m_ShipMoveBehavior;
    [HideInInspector]
    public ShipCameraBehavior m_ShipCameraBehavior;
    [HideInInspector]
    public ShipStateAndDamageBehavior m_ShipStateAndDamageBehavior;
    [HideInInspector]
    public ShipDeathBehavior m_ShipDeathBehavior;
    [HideInInspector]
    public ShipKillBehavior m_ShipKillBehavior;
    [HideInInspector]
    public ShipLevelingBehavior m_ShipLevelingBehavior;
    [HideInInspector]
    public ShipTresorBehavior m_ShipTresorBehavior;

    //For others ship
    public int m_ExperienceWin;

    //For multiples script
    public bool m_NearFromHomeHarbor;


    public void Awake()
    {
        //Component Initialisation
        m_ShipMoveBehavior = GetComponent<ShipMoveBehavior>();
        m_ShipCameraBehavior = GetComponent<ShipCameraBehavior>();
        m_ShipStateAndDamageBehavior = GetComponent<ShipStateAndDamageBehavior>();
        m_ShipDeathBehavior = GetComponent<ShipDeathBehavior>();
        m_ShipKillBehavior = GetComponent<ShipKillBehavior>();
        m_ShipLevelingBehavior = GetComponent<ShipLevelingBehavior>();
        m_ShipTresorBehavior = GetComponent<ShipTresorBehavior>();
        m_ShipLevel = 1;
    }

    

    // Use this for initialization
    public void Start ()
    {

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
        
    }

    public void ForceRefurbisment()
    {
        m_CHealthPoint   = m_CHealthPointBase;
        m_CSpeed         = m_CSpeedBase;
        m_CDamage        = m_CDamageBase;
        m_CCapacity      = 0;
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
        UIManager.instance.ActualizeUILife();
        UIManager.instance.ActualizeUITresor();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Harbor")
        {
            if (other.gameObject.GetComponent<Harbor>().m_IsHarborBlue == m_IsBlue)
            {
                m_NearFromHomeHarbor = true;
                m_ShipStateAndDamageBehavior.AddState(ShipStateAndDamageBehavior.EState.HARBORREPAIR, 0, 0);
                m_ShipTresorBehavior.m_Harbor = other.gameObject.GetComponent<Harbor>();
            }
        }

    }
   void OnTriggerExit(Collider other)
   {
        if (other.tag == "Harbor")
        {
            if (other.gameObject.GetComponent<Harbor>().m_IsHarborBlue == m_IsBlue)
            {
                m_NearFromHomeHarbor = false;
            }
        }

  }

}
