using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    //PLAYER SPACE
    //LifeBar
    public Image m_LifeBarFull;
    public Text m_LifeText;
    //ExperienceBar
    public Image m_ExperienceBarFull;
    public Text m_ExperienceText;
    //States
    public Image[] m_StateImage = new Image[14];
    //Captain
    public RawImage m_CaptainFace;
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
    public Image m_PurpleBar;
    public Image m_BlueBar;

    public Text m_PurpleColonies;
    public Text m_PurpleShipwreck;

    public Text m_BlueColonies;
    public Text m_BlueShipwreck;


    void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        m_BlueColonies.text = Game.instance.m_BlueColonies.ToString();
        m_PurpleColonies.text = Game.instance.m_PurpleColonies.ToString();

        m_BlueShipwreck.text = Game.instance.m_DestroyCounterGameBlue.ToString();
        m_ExperienceText.text = "0";

    }

    public void UIClock()
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

    public void UIStatGeneral()
    {
        m_PurpleShipwreck.text = Game.instance.m_DestroyCounterGamePurple.ToString();
        m_BlueShipwreck.text = Game.instance.m_DestroyCounterGameBlue.ToString();

        m_PurpleColonies.text = Game.instance.m_PurpleColonies.ToString();
        m_BlueColonies.text = Game.instance.m_BlueColonies.ToString();

        m_Stats.text = m_Ship.m_DestroyCounter.ToString() + m_Ship.m_AssistCounter.ToString() + m_Ship.m_DeathCounter.ToString();

    }
}

