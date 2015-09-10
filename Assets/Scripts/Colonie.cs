using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Colonie : MonoBehaviour {

    public ColonieFortification m_ColonieFortification;
    public ColonieSystem m_ColonieSystem;

    //State of the colonie
    public bool m_IsGreen;
    public bool m_IsOrange;
    public bool m_IsNeutre;

    //Level of the colonie
    public int m_ColonieLevel;

    //Life of the fortification
    public int m_ColonieMaxLife;
    public int m_ColonieLife;

    //Tresor inside
    public int m_ColonieTresors;

    //For UI
    #region UI
    public Color m_ColorGreen;

    public Color m_ColorOrange;

    public Renderer m_Renderer;

    public Canvas m_CanvasUI;
    public Canvas m_CanvasAllies;
    public Canvas m_CanvasEnemies;

    public Image m_LifeBar;
    public Image m_UpgradeBar;

    public Image m_PresenceOfGoldEnemy;

    public GameObject m_PanelPresenceOfGoldAllies;
    public Text m_NumberOfTresors;

    float m_BarZeroValue = -10.3501f;
    float m_BarMaxValue = 0;
    float m_BarPourcent = 4.604f;

    #endregion

    // Use this for initialization
    void Start () {

        m_ColonieLevel = 0;
        m_ColonieLife = 0;
        m_ColonieMaxLife = 10;

        m_IsGreen = false ;
        m_IsOrange = false;
        m_IsNeutre = true;

        //For UI

        m_BarMaxValue = m_LifeBar.transform.position.x;
        m_BarPourcent = (Mathf.Abs(m_BarMaxValue - m_BarZeroValue)) / 100;

        ActualizeUIColonisation();
    }

    #region Tresors
    public void AddTresor()
    {
        m_ColonieTresors++;
        ActualizeUIColonisation();
    }

    public bool CanLooseTresor()
    {
        if(m_ColonieTresors>0)
        {
            LooseTresor();
            return true;
        }
        return false;
    }

    void LooseTresor()
    {
        m_ColonieTresors--;
        ActualizeUIColonisation();
    }
    #endregion


    public void ActualizeUIColonisation()
    {
        //color of colonie
        if (m_IsNeutre)
        {
            m_CanvasUI.enabled = false;
        }
        else
        {
            m_CanvasUI.enabled = true;
        }
        if (m_IsGreen)
        {
            m_Renderer.material.color = m_ColorGreen; //19
            m_CanvasAllies.gameObject.layer = 19;
            m_CanvasEnemies.gameObject.layer = 20;
        }
        if (m_IsOrange)
        {
            m_Renderer.material.color = m_ColorOrange; //20
            m_CanvasAllies.gameObject.layer = 20;
            m_CanvasEnemies.gameObject.layer = 19;

        }
       


        //Presence of tresors
        if(m_ColonieTresors>0)
        {
            m_CanvasEnemies.enabled = true;
            m_CanvasAllies.enabled = true;

            m_NumberOfTresors.text = m_ColonieTresors.ToString();

        }
        else
        {
            m_CanvasEnemies.enabled = false;
            m_CanvasAllies.enabled=false;
        }
        
        //Life Bar
        if(m_ColonieLife==m_ColonieMaxLife)
        {
            m_LifeBar.enabled = false;
        }
        else
        {
            m_LifeBar.enabled = true;


            float barLevel = 0;
            if (m_ColonieLife > 0)
            {
                barLevel = (m_ColonieLife * 100) / m_ColonieMaxLife;
                m_LifeBar.transform.position = new Vector3((barLevel * m_BarPourcent) + m_BarZeroValue, m_LifeBar.transform.position.y, m_LifeBar.transform.position.z);
            }
            else
            {
                m_LifeBar.transform.position = new Vector3(m_BarZeroValue, m_LifeBar.transform.position.y, m_LifeBar.transform.position.z);
            }

        }
        


        //Upgrade Bar
        if (m_ColonieFortification.m_IsInConstruction==false)
        {
            m_UpgradeBar.enabled = false;
        }
        else
        {
            m_UpgradeBar.enabled = true;

            float barLevel = 0;
            if (m_ColonieFortification.m_timer > 0)
            {
                barLevel = (m_ColonieFortification.m_timer * 100) / m_ColonieFortification.m_timerBase;
                m_UpgradeBar.transform.position = new Vector3((barLevel * m_BarPourcent) + m_BarZeroValue, m_UpgradeBar.transform.position.y, m_UpgradeBar.transform.position.z);
            }
            else
            {
                m_UpgradeBar.transform.position = new Vector3(m_BarZeroValue, m_UpgradeBar.transform.position.y, m_UpgradeBar.transform.position.z);
            }

        }







    }

}
