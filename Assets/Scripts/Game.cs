using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {


    public GameObject[] m_TeamListGreen = new GameObject[5];

    public GameObject[] m_TeamListOrange = new GameObject[5];

    [Space(10)]
    public int m_DeathCounterGameGreen;
    public int m_DestroyCounterGameGreen;
    public int m_AssistCounterGameGreen;
    [Space(10)]
    public int m_DeathCounterGameOrange;
    public int m_DestroyCounterGameOrange;
    public int m_AssistCounterGameOrange;
    [Space(10)]
    public int m_GreenColonies;
    public int m_OrangeColonies;

    [Space(10)]
    public int m_GreenTresors;
    public int m_OrangeTresors;

    [HideInInspector]
    public int m_TresorsTotal=100;

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


        m_DeathCounterGameGreen = 0;
        m_DestroyCounterGameGreen = 0;
        m_AssistCounterGameGreen = 0;

        m_DeathCounterGameOrange = 0;
        m_DestroyCounterGameOrange = 0;
        m_AssistCounterGameOrange = 0;

        m_GreenColonies=0;
        m_OrangeColonies=0;




}
    #endregion

    // Use this for initialization
    void Start ()
    {
        UIManager.instance.ActualizeUIStatGeneral();
        UIManager.instance.ActualiseGlobalTresors();
    }
    
    public void AddStat(string camp, string stat)
    {
        if(camp=="Green")
        {
            switch(stat)
            {
                case "Destroy":
                    m_DestroyCounterGameGreen++;
                    break;
                case "Death":
                    m_DeathCounterGameGreen++;
                    break;
                case "Assist":
                    m_AssistCounterGameGreen++;
                    break;
            }
        }
        else
        {
            switch (stat)
            {
                case "Destroy":
                    m_DestroyCounterGameOrange++;
                    break;
                case "Death":
                    m_DeathCounterGameOrange++;
                    break;
                case "Assist":
                    m_AssistCounterGameOrange++;
                    break;
            }
        }

        UIManager.instance.ActualizeUIStatGeneral();

    }

    public void AddTresor(string camp, int quantity)
    {
        if(camp=="Green")
        {
            m_GreenTresors += quantity;
        }
        else
        {
            m_OrangeTresors += quantity;
        }
        UIManager.instance.ActualiseGlobalTresors();
    }

    public void LooseTresor(string camp, int quantity)
    {
        Debug.Log("loose");
        if (camp == "Green")
        {
            m_GreenTresors -= quantity;
        }
        else
        {
            m_OrangeTresors -= quantity;
        }
        UIManager.instance.ActualiseGlobalTresors();
    }
}
