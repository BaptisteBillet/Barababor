﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {



    #region Singleton
    static private UIManager s_Instance;
    static public UIManager instance
    {
        get
        {
            return s_Instance;
        }
    }

    void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        //DontDestroyOnLoad(this);
    }
    #endregion


    public Ship m_Ship;

    #region Members declaration


    //PLAYER SPACE
    //LifeBar
    public Image m_LifeBarFull;
    public Text m_LifeText;
    //ExperienceBar
    public Image m_ExperienceBarFull;
    public Text m_ExperienceText;
    public Text m_ExperienceMax;
    public Text m_ExperienceSlash;
    //States
    public Image[] m_StateImage = new Image[14];
    public Sprite[] m_StateImageData = new Sprite[25];
    public Sprite m_Transparent;
    private Dictionary<string, Sprite> StateLibrary = new Dictionary<string, Sprite>();
    //Captain
    public RawImage m_CaptainFace;
    public Text m_CaptainRespawnTimer;
    //Icone
    public Image m_Icone;
    //PlayerLevel
    public Text m_PlayerLevelText;
    //TresorBar
    public Image m_TresorBarFull;
    public Text m_TresorText;
    //ActionBar
    public Image[] m_ActionImage = new Image[4];
    
    //ConsomableBar
    public Image[] m_ConsomableBar = new Image[2];

    //CHAT 

    //MiniMap

    //OtherInterface
    public Text m_OtherLevel1;
    public Image m_OtherArchetype1;
    public Image m_OtherLifeBar1;
    public Image m_OtherTresorBar1;

    public Text m_OtherLevel2;
    public Image m_OtherArchetype2;
    public Image m_OtherLifeBar2;
    public Image m_OtherTresorBar2;

    public Text m_OtherLevel3;
    public Image m_OtherArchetype3;
    public Image m_OtherLifeBar3;
    public Image m_OtherTresorBar3;

    public Text m_OtherLevel4;
    public Image m_OtherArchetype4;
    public Image m_OtherLifeBar4;
    public Image m_OtherTresorBar4;

    //Stats
    public Text m_Stats;

    //Flotte
    public Text m_Timer;
    public Image m_OrangeBar;
    public Image m_GreenBar;

    public Text m_OrangeColonies;
    public Text m_OrangeShipwreck;

    public Text m_GreenColonies;
    public Text m_GreenShipwreck;

    //
    float m_ExperienceZeroValue = -42f;
    float m_ExperienceMaxValue = 41.8f;
    float m_ExperiencePourcent=0.838f;

    float m_BarZeroValue = 430.079f;
    float m_BarMaxValue = 890.8f;
    float m_BarPourcent = 4.604f;

    float m_BarGreenZeroValue = 453.0658f;
    float m_BarGreenMaxValue = 890.8f;
    float m_BarGreenPourcent = 4.604f;

    float m_BarOrangeZeroValue = 453.0658f;
    float m_BarOrangeMaxValue = 890.8f;
    float m_BarOrangePourcent = 4.604f;

    public GameObject m_DazzledMask;

    public Color m_Green;

    public Color m_Orange;
    #endregion

    void Start()
    {
        m_CaptainRespawnTimer.enabled = false;

        //Debug.Log(m_TresorBarFull.transform.position.x);

        m_BarMaxValue = m_LifeBarFull.transform.position.x;
        m_BarPourcent = (Mathf.Abs(m_BarMaxValue - m_BarZeroValue) )/ 100;

        #region BarGreenOrange        
        m_GreenBar.transform.position = new Vector3(-178f, m_GreenBar.transform.position.y, m_GreenBar.transform.position.z);
        
        m_BarGreenZeroValue = -178f;
        m_BarGreenMaxValue =833f;
        m_BarGreenPourcent= (m_BarGreenMaxValue - m_BarGreenZeroValue) / 100;

        
        m_OrangeBar.transform.position= new Vector3(1844, m_OrangeBar.transform.position.y, m_OrangeBar.transform.position.z);

        m_BarOrangeZeroValue = m_OrangeBar.transform.position.x;
        m_BarOrangeMaxValue = 833f;
        m_BarOrangePourcent =-( (m_BarOrangeZeroValue - m_BarOrangeMaxValue) / 100);
        #endregion

        foreach (Sprite sprite in m_StateImageData)
        {
            StateLibrary.Add(sprite.name, sprite);
            
        }



        Initialization();
    }


    public void Initialization()
    {
        m_GreenColonies.text = Game.instance.m_GreenColonies.ToString();
        m_OrangeColonies.text = Game.instance.m_OrangeColonies.ToString();
        
    }

    public void ActualizeTeam(bool IsGreen)
    {
        if(IsGreen)
        {
            m_ExperienceBarFull.color = m_Green;
        }
        else
        {
            m_ExperienceBarFull.color = m_Orange;
        }
    }

    public void ActualizeUIClock()
    {
        if (Game.instance.m_TimeOfPlay.minutes < 10)
        {
            if (Game.instance.m_TimeOfPlay.seconds < 10)
            {
                m_Timer.text = "0" + Game.instance.m_TimeOfPlay.minutes + ":" + "0" + Game.instance.m_TimeOfPlay.seconds;
            }
            else
            {
                m_Timer.text = "0" + Game.instance.m_TimeOfPlay.minutes + ":" + Game.instance.m_TimeOfPlay.seconds;
            }
        }
        else
        {
            if (Game.instance.m_TimeOfPlay.seconds < 10)
            {
                m_Timer.text = Game.instance.m_TimeOfPlay.minutes + ":" + "0" + Game.instance.m_TimeOfPlay.seconds;
            }
            else
            {
                m_Timer.text = Game.instance.m_TimeOfPlay.minutes + ":" + Game.instance.m_TimeOfPlay.seconds;
            }
        }



    }

    public void ActualizeUIStatGeneral()
    {
        m_OrangeShipwreck.text = Game.instance.m_DestroyCounterGameOrange.ToString();
        m_GreenShipwreck.text = Game.instance.m_DestroyCounterGameGreen.ToString();

        m_OrangeColonies.text = Game.instance.m_OrangeColonies.ToString();
        m_GreenColonies.text = Game.instance.m_GreenColonies.ToString();

        m_Stats.text = m_Ship.m_DestroyCounter.ToString()+"/"+ m_Ship.m_AssistCounter.ToString()+"/"+ m_Ship.m_DeathCounter.ToString();

    }


    public void ActualizeUIExperienceAndLeveling()
    {   
        if(m_Ship.m_ShipLevel<20)
        {
            m_PlayerLevelText.text = m_Ship.m_ShipLevel.ToString();
            m_ExperienceText.text = m_Ship.m_ShipLevelingBehavior.m_ExperienceQuantity.ToString();
            m_ExperienceMax.text = m_Ship.m_ShipLevelingBehavior.m_ExperienceForLevel.ToString();

            float experienceLevel=0;

            if (m_Ship.m_ShipLevelingBehavior.m_ExperienceQuantity>0)
            {
                experienceLevel = (m_Ship.m_ShipLevelingBehavior.m_ExperienceQuantity * 100) / m_Ship.m_ShipLevelingBehavior.m_ExperienceForLevel;
            }
            
            m_ExperienceBarFull.transform.position = new Vector3(m_ExperienceBarFull.transform.position.x, (experienceLevel* m_ExperiencePourcent)+ m_ExperienceZeroValue, m_ExperienceBarFull.transform.position.z);

        }
        else
        {
            ActualizeUIExperienceAndLevelingEnd();
        }

       

    }

    public void ActualizeUIExperienceAndLevelingEnd()
    {
        m_PlayerLevelText.text = m_Ship.m_ShipLevel.ToString();
        m_ExperienceText.text = "";
        m_ExperienceBarFull.transform.position = new Vector3(m_ExperienceBarFull.transform.position.x, m_ExperienceMaxValue, m_ExperienceBarFull.transform.position.z);

    }

    public void ActualizeUILife()
    {
        m_LifeText.text = m_Ship.m_CHealthPoint.ToString() + " / " + m_Ship.m_CHealthPointBase.ToString();

        float barLevel = 0;
        if (m_Ship.m_CHealthPoint>0)
        {
            barLevel = (m_Ship.m_CHealthPoint * 100) / m_Ship.m_CHealthPointBase;
            m_LifeBarFull.transform.position = new Vector3((barLevel* m_BarPourcent) + m_BarZeroValue, m_LifeBarFull.transform.position.y, m_LifeBarFull.transform.position.z);
        }
        else
        {
            m_LifeBarFull.transform.position = new Vector3(m_BarZeroValue, m_LifeBarFull.transform.position.y, m_LifeBarFull.transform.position.z);
        }

    }
    public void ActualizeUITresor()
    {
        m_TresorText.text = m_Ship.m_CCapacity.ToString() + " / " + m_Ship.m_CCapacityBase.ToString();

        
        float barLevel = 0;
        if (m_Ship.m_CCapacity > 0)
        {
            barLevel = (m_Ship.m_CCapacity * 100) / m_Ship.m_CCapacityBase;
            m_TresorBarFull.transform.position = new Vector3((barLevel * m_BarPourcent) + m_BarZeroValue, m_TresorBarFull.transform.position.y, m_TresorBarFull.transform.position.z);
        }
        else
        {
            m_TresorBarFull.transform.position = new Vector3(m_BarZeroValue, m_TresorBarFull.transform.position.y, m_TresorBarFull.transform.position.z);
        }
        
    }

    public void ActualizeUIRespawnTimer()
    {
        if(m_CaptainRespawnTimer.enabled == false)
        {
            m_CaptainRespawnTimer.enabled = true;
        }
        
        if (m_Ship.m_ShipDeathBehavior.m_RespawnTimeMinutes< 10)
        {
            if (m_Ship.m_ShipDeathBehavior.m_RespawnTimeSecondes < 10)
            {
                m_CaptainRespawnTimer.text = "0" + m_Ship.m_ShipDeathBehavior.m_RespawnTimeMinutes + ":" + "0" + m_Ship.m_ShipDeathBehavior.m_RespawnTimeSecondes;
            }
            else
            {
                m_CaptainRespawnTimer.text = "0" + m_Ship.m_ShipDeathBehavior.m_RespawnTimeMinutes + ":" + m_Ship.m_ShipDeathBehavior.m_RespawnTimeSecondes;
            }
        }
        else
        {
            if (Game.instance.m_TimeOfPlay.seconds < 10)
            {
                m_CaptainRespawnTimer.text = m_Ship.m_ShipDeathBehavior.m_RespawnTimeMinutes + ":" + "0" + m_Ship.m_ShipDeathBehavior.m_RespawnTimeSecondes;
            }
            else
            {
                m_CaptainRespawnTimer.text = m_Ship.m_ShipDeathBehavior.m_RespawnTimeMinutes + ":" + m_Ship.m_ShipDeathBehavior.m_RespawnTimeSecondes;
            }
        }

        if(m_Ship.m_ShipDeathBehavior.m_RespawnTimeMinutes==0 && m_Ship.m_ShipDeathBehavior.m_RespawnTimeSecondes==0)
        {
            m_CaptainRespawnTimer.enabled = false;
        }

    }

    public void ActualizeUIState()
    {

        //for all the object in the shipstate list
        for (int i = 0; i < m_StateImage.Length; i++)
        {
            m_StateImage[i].sprite = m_Transparent;
        }

        for (int i=0; i<m_Ship.m_ShipStateAndDamageBehavior.m_ListState.Count;i++)
        {
            if (i < 14)
            {
                m_StateImage[i].sprite = StateLibrary[m_Ship.m_ShipStateAndDamageBehavior.m_ListState[i].GetComponent<State>().m_State.ToString()];
            }
        }

    }

    public void ActualizeDazzled(bool IsDazzled)
    {
        if(IsDazzled==true)
        {
            m_DazzledMask.SetActive(true);
        }
        else
        {
            m_DazzledMask.SetActive(false);
        }
    }

    public void ShowExperience(bool show)
    {
       m_ExperienceText.enabled = show;
       m_ExperienceMax.enabled = show;
        m_ExperienceSlash.enabled = show;

    }

    public void ActualiseGlobalTresors()
    {

        float barLevel = 0;
        if (Game.instance.m_GreenTresors>0)
        {
            barLevel = (Game.instance.m_GreenTresors * 100) / Game.instance.m_TresorsTotal;
            Debug.Log(barLevel+" "+ m_BarGreenPourcent+" "+ m_BarGreenZeroValue);
            m_GreenBar.transform.position = new Vector3((barLevel* m_BarGreenPourcent)+m_BarGreenZeroValue, m_GreenBar.transform.position.y, m_GreenBar.transform.position.z);
        }
        else
        {
            m_GreenBar.transform.position = new Vector3(m_BarGreenZeroValue, m_GreenBar.transform.position.y, m_GreenBar.transform.position.z);
        }

        barLevel = 0;
        if (Game.instance.m_OrangeTresors > 0)
        {
            barLevel = (Game.instance.m_OrangeTresors * 100) / Game.instance.m_TresorsTotal;
            m_OrangeBar.transform.position = new Vector3((barLevel * m_BarOrangePourcent) + m_BarOrangeZeroValue, m_OrangeBar.transform.position.y, m_OrangeBar.transform.position.z);
        }
        else
        {
            m_OrangeBar.transform.position = new Vector3(m_BarOrangeZeroValue, m_OrangeBar.transform.position.y, m_OrangeBar.transform.position.z);
        }

    }

    void Update()
    {
        ActualiseGlobalTresors();
    }

}

