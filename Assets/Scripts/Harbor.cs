using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Harbor : MonoBehaviour {


    public HarborTresorsBehavior m_HarborTresorsBehavior;

    public HarborLifeBehavior m_HarborLifeBehavior;

    //Members
    public bool m_IsGreen;

    public Vector3[] m_SpawnList = new Vector3[5];

    public const int m_ValueOfHeal=5;
    public const float m_TimeOfHeal = 0.20f;

    public int m_TresorsHarbor;

    public int m_HarborLife;
    public int m_HarborLifeMax;

    public Canon m_Canon;

    //For UI
    public Renderer m_IslandMaterial;
    public Color m_Green;
    public Color m_Orange;

    public Canvas m_CanvasAllies;
    public Canvas m_CanvasEnemies;

    public Image m_LifeBar;
    public Text m_TresorNumber;

    float m_BarZeroValue = -10.3501f;
    float m_BarMaxValue = 0;
    float m_BarPourcent = 4.604f;

    // Use this for initialization
    void Start () {

        m_HarborLifeMax = 100;
        m_HarborLife = m_HarborLifeMax;


        ActualizeUIHarbor();
    }
    
    //UI
    public void ActualizeUIHarbor()
    {
        //Color of the Harbor
        if (m_IsGreen)
        {
            m_IslandMaterial.material.color = m_Green; //19
            m_CanvasAllies.gameObject.layer = 19;
            m_CanvasEnemies.gameObject.layer = 20;
        }
        else
        {
            m_IslandMaterial.material.color = m_Orange; //20
            m_CanvasAllies.gameObject.layer = 20;
            m_CanvasEnemies.gameObject.layer = 19;
        }

        //Presence of tresors
        if (m_TresorsHarbor > 0)
        {
            m_CanvasEnemies.enabled = true;
            m_CanvasAllies.enabled = true;

            m_TresorNumber.text = m_TresorsHarbor.ToString();

        }
        else
        {
            m_CanvasEnemies.enabled = false;
            m_CanvasAllies.enabled = false;
        }

        //Life Bar
        if (m_HarborLife == m_HarborLifeMax)
        {
            m_LifeBar.enabled = false;
        }
        else
        {
            m_LifeBar.enabled = true;


            float barLevel = 0;
            if (m_HarborLife > 0)
            {
                barLevel = (m_HarborLife * 100) / m_HarborLifeMax;
                m_LifeBar.transform.position = new Vector3((barLevel * m_BarPourcent) + m_BarZeroValue, m_LifeBar.transform.position.y, m_LifeBar.transform.position.z);
            }
            else
            {
                m_LifeBar.transform.position = new Vector3(m_BarZeroValue, m_LifeBar.transform.position.y, m_LifeBar.transform.position.z);
            }

        }



    }

}
