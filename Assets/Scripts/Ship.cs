using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ship : MonoBehaviour {

    protected const int FACTORHEALTHPOINT  = 100              ;
    protected const int FACTORSPEED        = 100              ;
    protected const float FACTORDAMAGE     = 6                ;
    protected const int FACTORCAPACITY     = 4                ;
    protected const int FACTORVISION       = 1                ;
    protected const int FACTORREGENERATION = 2                ;



    [Header("Caracteristiques")]
    //Caracteristiques
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
    public int m_CRegeneration;
    public int m_CRegenerationBase;
    //

   

    enum Type
    {
        BOW,
        KEEL,
        STERN,
        MAST
    }

    enum Kind
    {
        ACTION1,
        ACTION2,
        ACTION3,
        ACTION4
        
    }

    //Elements
    public Element[] m_Element = new Element[4];

    //Equipment
    public Equipment[] m_Equipment = new Equipment[4];

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
        m_CHealthPointBase  = 0;
        m_CSpeedBase        = 0;
        m_CDamageBase       = 0;
        m_CCapacityBase     = 0;
        m_CVisionBase       = 0;
        m_CRegenerationBase = 0;

        foreach(Element element in m_Element)
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
        m_CHealthPoint = m_CHealthPointBase;
        m_CSpeed=m_CSpeedBase;
        m_CDamage=m_CDamageBase;
        m_CCapacity=m_CCapacityBase;
        m_CVision=m_CVisionBase;
        m_CRegeneration=m_CRegenerationBase;


    }
	
	public void ChangeState()
    {

    }

    public void TakeDamage()
    {

    }

    public void Die()
    {

    }

    public void HarborHeal()
    {

    }



}
