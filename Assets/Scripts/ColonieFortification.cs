using UnityEngine;
using System.Collections;

public class ColonieFortification : MonoBehaviour {

    Colonie m_Colonie;

    public GameObject m_CabanePrefab;

    public GameObject m_Fortification1Prefab;
    public GameObject m_Fortification2Prefab;
    public GameObject m_Fortification3Prefab;
    public GameObject m_Fortification4Prefab;
    public GameObject m_Fortification5Prefab;

    public bool m_IsInConstruction;

    public int m_CabaneLife;
    public int m_FortificationLife;

    public float m_timer;
    public float m_timerBase;

    // Use this for initialization
    void Start ()
    {
        m_Colonie = transform.parent.GetComponent<Colonie>();
    }

    public void StartConstruction()
    {
        if(m_IsInConstruction==false)
        {
            m_IsInConstruction = true;
            StartCoroutine(CConstructionTimer());
        }
    }

    IEnumerator CConstructionTimer()
    {

        m_timerBase = m_Colonie.m_ColonieLevel*3+5;
        m_timer = m_timerBase;
        m_Colonie.ActualizeUIColonisation();
        while (m_timer>0)
        {
            yield return new WaitForSeconds(0.1f);
            m_timer -= 0.1f;
            m_Colonie.ActualizeUIColonisation();
        }

        m_timer = 0;

        m_Colonie.m_ColonieLevel++;

        m_Colonie.m_ColonieMaxLife = m_CabaneLife + m_Colonie.m_ColonieLevel * m_FortificationLife;
        m_Colonie.m_ColonieLife = m_Colonie.m_ColonieMaxLife;
        m_Colonie.ActualizeUIColonisation();
        ConstructionFortificationGraphismes();

    }


    public void ConstructionFortificationGraphismes()
    {
        ResetFortificationGraphismes();
        switch (m_Colonie.m_ColonieLevel)
        {
            case 0:
                m_CabanePrefab.SetActive(true);
                break;

            case 1:
                m_Fortification1Prefab.SetActive(true);
                break;

            case 2:
                m_Fortification2Prefab.SetActive(true);
                break;

            case 3:
                m_Fortification3Prefab.SetActive(true);
                break;

            case 4:
                m_Fortification4Prefab.SetActive(true);
                break;

            case 5:
                m_Fortification5Prefab.SetActive(true);
                break;

        }

        m_IsInConstruction = false;
        m_Colonie.ActualizeUIColonisation();
    }

    public void ResetFortificationGraphismes()
    {
        StopAllCoroutines();
        m_timer = 0;
        m_CabanePrefab.SetActive(false);

        m_Fortification1Prefab.SetActive(false);
        m_Fortification2Prefab.SetActive(false);
        m_Fortification3Prefab.SetActive(false);
        m_Fortification4Prefab.SetActive(false);
        m_Fortification5Prefab.SetActive(false);
        m_IsInConstruction = false;
    }

    public void DestructionFortification()
    {
        StopAllCoroutines();

        m_CabanePrefab.SetActive(false);

        m_Fortification1Prefab.SetActive(false);
        m_Fortification2Prefab.SetActive(false);
        m_Fortification3Prefab.SetActive(false);
        m_Fortification4Prefab.SetActive(false);
        m_Fortification5Prefab.SetActive(false);
        m_IsInConstruction = false;

        m_Colonie.m_ColonieLevel = 0;
        m_Colonie.m_IsGreen = false;
        m_Colonie.m_IsOrange = false;
        m_Colonie.m_IsNeutre = true;

        m_Colonie.ActualizeUIColonisation();
    }


}
