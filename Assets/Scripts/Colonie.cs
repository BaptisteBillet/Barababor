using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Colonie : MonoBehaviour {

    public ColonieFortification m_ColonieFortification;
    public ColonieSystem m_ColonieSystem;

    //State of the colonie
    public bool m_IsGreen;
    public bool m_IsOrange;
    public bool m_Neutre;

    //Level of the colonie
    public int m_ColonieLevel;

    //Life of the fortification
    public int m_ColonieLife;

    //Tresor inside
    public int m_ColonieTresors;

    //For UI
    public Color m_ColorGreen;

    public Color m_ColorOrange;

    public Renderer m_Renderer;

    // Use this for initialization
    void Start () {

        m_ColonieLevel = 0;
        m_ColonieLife = 0;

        m_IsGreen = false ;
        m_IsOrange = false;
        m_Neutre = true;

        //For UI



        ActualizeUIColonisation();
    }

    public void ActualizeUIColonisation()
    {
        if(m_IsGreen)
        {
            m_Renderer.material.color = m_ColorGreen;
        }
        if (m_IsOrange)
        {
            m_Renderer.material.color = m_ColorOrange;
        }

    }

}
