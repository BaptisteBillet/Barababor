using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


/// <summary>
/// /This class as for objective to Manage the entire PlayerShip and UI of the main Canvas.
/// /It's use as a singleton in order to provide a easy-to-call procedure.
/// </summary>
public class UIManager : MonoBehaviour {


    /// <summary>
    /// The Singleton
    /// </summary>
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

    //The needed reference to the PlayerShip;
    public Ship m_Ship;

    #region Members declaration


    //PLAYER SPACE
    //LifeBar
    [Header("Life")]
    public Image m_LifeBarFull;
    public Text m_LifeText;
    //ExperienceBar
    [Header("Experience")]
    public Image m_ExperienceBarFull;
    public Text m_ExperienceText;
    public Text m_ExperienceMax;
    public Text m_ExperienceSlash;
    //States
    [Header("States")]
    public Image[] m_StateImage = new Image[14];
    public Image[] m_StateImageCooldown = new Image[9];
    public Sprite[] m_StateImageData = new Sprite[25];
    public Sprite m_Transparent;
    private Dictionary<string, Sprite> StateLibrary = new Dictionary<string, Sprite>();
    //Captain
    [Header("Captain")]
    public RawImage m_CaptainFace;
    public Text m_CaptainRespawnTimer;
    //Icone
    [Header("Icone")]
    public Image m_Icone;
    //PlayerLevel
    [Header("PlayerLevel")]
    public Text m_PlayerLevelText;
    //TresorBar
    [Header("Tresor")]
    public Image m_TresorBarFull;
    public Text m_TresorText;
    //ActionBar
    [Header("Action")]
    public Image[] m_ActionImage = new Image[4];
    public Image[] m_ActionImageCooldown = new Image[4];
    public Text[] m_ActionTextCooldown = new Text[4];
    public Sprite[] m_ActionSprite = new Sprite[3];
    public Animator[] m_ActionAnimator = new Animator[4];

    //ConsomableBar
    [Header("Consomable")]
    public Image[] m_ConsomableBar = new Image[2];

    //CHAT 

    //MiniMap

    //OtherInterface
    [Header("Other")]
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
    [Header("Stats")]
    public Text m_Stats;

    //Flotte
    [Header("Flotte")]
    public Text m_Timer;
    public Image m_OrangeBar;
    public Image m_GreenBar;

    public Text m_OrangeColonies;
    public Text m_OrangeShipwreck;

    public Text m_GreenColonies;
    public Text m_GreenShipwreck;

    public Text m_MaterialNumber;

    //Dash
    [Header("Dash")]
    public Image m_DashFull;

    //Data for the different bar.
    #region Bar Data
    //Experience
    float m_ExperienceZeroValue = -42f;
    float m_ExperienceMaxValue = 41.8f;
    float m_ExperiencePourcent=0.838f;
    //Life
    float m_BarZeroValue = 430.079f;
    float m_BarMaxValue = 890.8f;
    float m_BarPourcent = 4.604f;
    //GreenBar
    float m_BarGreenZeroValue = 453.0658f;
    float m_BarGreenMaxValue = 890.8f;
    float m_BarGreenPourcent = 4.604f;
    //OrangeBar
    float m_BarOrangeZeroValue = 453.0658f;
    float m_BarOrangeMaxValue = 890.8f;
    float m_BarOrangePourcent = 4.604f;
    //DashBar
    float m_DashZeroValue = 533;
    float m_DashMaxValue = 613f;
    float m_DashPourcent = 0f;

    #endregion

    //The DzzledMask use to display the captain face
    public GameObject m_DazzledMask;

    //The two color in reference.
    public Color m_Green;
    public Color m_Orange;

    #endregion

    void Start()
    {
        //At this point, the player is alive, so we can disable the CaptainRespawnTimer
        m_CaptainRespawnTimer.enabled = false;

        #region Data Bar Initialisation
        //LifeBar
        m_BarMaxValue = m_LifeBarFull.transform.position.x;
        m_BarPourcent = (Mathf.Abs(m_BarMaxValue - m_BarZeroValue) )/ 100;

        //Green & Orange Bar
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

        //DashBar
        m_DashMaxValue = m_DashFull.transform.position.x;
        m_DashPourcent= (Mathf.Abs(m_DashMaxValue - m_DashZeroValue)) / 100;
        #endregion

        //Add the states for the StateBar, at this point there is only empty state on the StateBar
        foreach (Sprite sprite in m_StateImageData)
        {
            StateLibrary.Add(sprite.name, sprite);
            
        }

        //Start the initialization of the UI
        Initialization();
    }

    /// <summary>
    /// Initializations of this instance.
    /// </summary>
    public void Initialization()
    {
        m_GreenColonies.text = Game.instance.m_GreenColonies.ToString();
        m_OrangeColonies.text = Game.instance.m_OrangeColonies.ToString();
        m_MaterialNumber.text = "0";

    }

    /// <summary>
    /// Actualizes the team.
    /// </summary>
    /// <param name="IsGreen">if set to <c>true</c> [is green].</param>
    /// <remarks Change the ExperienceBar in order to be with the same color than the player's team.</remarks>
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

    /// <summary>
    /// Actualizes the UI clock.
    /// </summary>
    /// <remarks Change the m_Timer in order to be represent the correct game time .</remarks>
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

    /// <summary>
    /// Actualizes the UI stat general.
    /// </summary>
    /// <remarks Change the Orange and Green compter of Shipwreck and Colonies. Actualize also the player compters (Destroy, Assist and Death) .</remarks>
    public void ActualizeUIStatGeneral()
    {
        m_OrangeShipwreck.text = Game.instance.m_DestroyCounterGameOrange.ToString();
        m_GreenShipwreck.text = Game.instance.m_DestroyCounterGameGreen.ToString();

        m_OrangeColonies.text = Game.instance.m_OrangeColonies.ToString();
        m_GreenColonies.text = Game.instance.m_GreenColonies.ToString();

        m_Stats.text = m_Ship.m_DestroyCounter.ToString()+"/"+ m_Ship.m_AssistCounter.ToString()+"/"+ m_Ship.m_DeathCounter.ToString();

    }

    /// <summary>
    /// Actualizes the UI experience and leveling.
    /// </summary>
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

    /// <summary>
    /// Actualizes the UI experience and leveling end.
    /// </summary>
    public void ActualizeUIExperienceAndLevelingEnd()
    {
        m_PlayerLevelText.text = m_Ship.m_ShipLevel.ToString();
        m_ExperienceText.text = "";
        m_ExperienceBarFull.transform.position = new Vector3(m_ExperienceBarFull.transform.position.x, m_ExperienceMaxValue, m_ExperienceBarFull.transform.position.z);

    }

    /// <summary>
    /// Actualizes the UI life.
    /// </summary>
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

    /// <summary>
    /// Actualizes the UI tresor.
    /// </summary>
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

    /// <summary>
    /// Actualizes the UI respawn timer.
    /// </summary>
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

    /// <summary>
    /// Actualizes the state of the UI.
    /// </summary>
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

    /// <summary>
    /// Show or not the DazzledMask of the Captain face
    /// </summary>
    /// <param name="IsDazzled">if set to <c>true</c> [is dazzled].</param>
    /// <remarks If the ship is shipwreck, the dazzled is not show.</remarks>
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

    /// <summary>
    /// Shows the experience.
    /// </summary>
    /// <param name="show">if set to <c>true</c> [show].</param>
    /// <remarks Disable the experience bar if the player reach the maximum level.</remarks>
    public void ShowExperience(bool show)
    {
       m_ExperienceText.enabled = show;
       m_ExperienceMax.enabled = show;
        m_ExperienceSlash.enabled = show;

    }

    /// <summary>
    /// Actualises the global tresors.
    /// </summary>
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

    /// <summary>
    /// Actualizes the UI material.
    /// </summary>
    public void ActualizeUIMaterial()
    {
        m_MaterialNumber.text = m_Ship.m_MaterialNumber.ToString();
        if (m_Ship.m_MaterialNumber==m_Ship.m_MaterialMaxNumber)
        {
            m_MaterialNumber.color = Color.red;
        }
    }

    /// <summary>
    /// Actualizes the UI dash bar.
    /// </summary>
    public void ActualizeUIDashBar()
    {

        float barLevel = 0;

        if (m_Ship.m_ShipDashBehavior.timer> 0)
        {
            barLevel = (m_Ship.m_ShipDashBehavior.timer * 100) / m_Ship.m_ShipDashBehavior.m_DashCoolDown;
            m_DashFull.transform.position = new Vector3((barLevel * m_DashPourcent) + m_DashZeroValue, m_DashFull.transform.position.y, m_DashFull.transform.position.z);
        }
        else
        {
            m_DashFull.transform.position = new Vector3(m_DashZeroValue, m_DashFull.transform.position.y, m_DashFull.transform.position.z);
        }
    }

    /// <summary>
    /// If the player press a button with the mouse
    /// </summary>
    /// <param name="number">The number.</param>
    public void ButtonAction(int number)
    {
        m_Ship.m_ShipEquipementBehavior.ButtonAction(number);
    }

    /// <summary>
    /// Initializes the action bar.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <param name="weapon">The weapon.</param>
    public void InitializeActionBar(int number, WeaponList weapon)
    {
        int index = -1;

        switch(weapon.ToString())
        {
            case "LeBonVieuxCanonDesFamilles":
                index = 0;
                break;

            case "SalveDePetitPlomb":
                index = 1;
                break;

            case "LourdParpaingDeDureRealite":
                index = 2;
                break;

            default:
                index = -1;
                break;
        }

        if(index>=0)
        {
            m_ActionImage[number].sprite = m_ActionSprite[index];
        }
        

    }

    /// <summary>
    /// Actualizes the cooldown of the bouton.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <param name="pourcent">The pourcent.</param>
    /// <param name="cooldown">The cooldown.</param>
    public void ActualizeAction(int number, float pourcent, int cooldown)
    {
        cooldown += 1;
        m_ActionImageCooldown[number].fillAmount = pourcent;

        if(pourcent <= 0 || pourcent > 0.99f)
        {
            m_ActionTextCooldown[number].enabled = false;
        }
        else
        {
            if (m_ActionTextCooldown[number].enabled == false)
            {
                m_ActionTextCooldown[number].enabled = true;
            }

            m_ActionTextCooldown[number].text = (cooldown).ToString();
        }
    }

    /// <summary>
    /// Anim the Button the player just pressed
    /// </summary>
    /// <param name="number">The number of the button [0->3].</param>
    /// <param name="state">The state of the button for the animation [Use/Ready] .</param>
    public void ButtonActionAnimator(int number, string state)
    {
        if(state=="Use")
        {
            m_ActionAnimator[number].SetTrigger("Use");
        }
        else
        {
            m_ActionAnimator[number].SetTrigger("Ready");
        }
    }
}

