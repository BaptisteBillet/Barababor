using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {


    public GameObject[] m_TeamListBlue = new GameObject[5];

    public GameObject[] m_TeamListPurple = new GameObject[5];

    [Space(10)]
    public int m_DeathCounterGameBlue;
    public int m_DestroyCounterGameBlue;
    public int m_AssistCounterGameBlue;
    [Space(10)]
    public int m_DeathCounterGamePurple;
    public int m_DestroyCounterGamePurple;
    public int m_AssistCounterGamePurple;
    [Space(10)]
    public int m_BlueColonies;
    public int m_PurpleColonies;

    //References
    public UIManager m_UIManager;
    public TimeOfPlay m_TimeOfPlay;
    

    #region Singleton
    static private Game s_Instance;
    static public Game instance
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
        m_TimeOfPlay = GetComponent<TimeOfPlay>();


        m_DeathCounterGameBlue = 0;
        m_DestroyCounterGameBlue = 0;
        m_AssistCounterGameBlue = 0;

        m_DeathCounterGamePurple = 0;
        m_DestroyCounterGamePurple = 0;
        m_AssistCounterGamePurple = 0;

        m_BlueColonies=0;
        m_PurpleColonies=0;




}
    #endregion

   



    

    // Use this for initialization
    void Start ()
    {
        UIManager.instance.UIStatGeneral();
    }
    
    public void AddStat(string camp, string stat)
    {
        if(camp=="blue")
        {
            switch(stat)
            {
                case "Destroy":
                    m_DestroyCounterGameBlue++;
                    break;
                case "Death":
                    m_DeathCounterGameBlue++;
                    break;
                case "Assist":
                    m_AssistCounterGameBlue++;
                    break;
            }
        }
        else
        {
            switch (stat)
            {
                case "Destroy":
                    m_DestroyCounterGamePurple++;
                    break;
                case "Death":
                    m_DeathCounterGamePurple++;
                    break;
                case "Assist":
                    m_AssistCounterGamePurple++;
                    break;
            }
        }

        UIManager.instance.UIStatGeneral();

    }


}
