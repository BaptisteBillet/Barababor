using UnityEngine;
using System.Collections;

public class ShipLevelingBehavior : MonoBehaviour {


    public Ship m_Ship;

    public int[] m_ExperienceGap = new int[21];
    const int FACTOREXPERIENCEGAP = 78;


    public int m_ExperienceQuantity;

    //For UI
    public int m_ExperienceForLevel;

    // Use this for initialization
    void Start () {
        m_Ship=GetComponent<Ship>();

        m_ExperienceGap[0] = 0;
        m_ExperienceGap[1] = 0;

        for (int i = 2; i < 21; i++)
        {
            m_ExperienceGap[i] = (i * (i - 1)) * FACTOREXPERIENCEGAP;
        }


        m_ExperienceQuantity = 0;
        m_ExperienceForLevel = m_ExperienceGap[m_Ship.m_ShipLevel + 1];
        //For UI
        UIManager.instance.UIExperienceAndLeveling();
    }


    public void AddExperienceFromTresor()
    {

    }

    public void AddExperienceFromKill()
    {

    }

    public void AddExperienceFromFortification()
    {

    }

    public void AddExperienceFromColonization()
    {

    }

    public void AddExperience(int number)
    {
        if (m_Ship.m_ShipLevel<20)
        {
            
            if (number+m_ExperienceQuantity>= m_ExperienceForLevel)
            {
                Debug.Log("number "+number);
                Debug.Log("m_ExperienceQuantity " + m_ExperienceQuantity);
                Debug.Log("m_ExperienceForLevel " + m_ExperienceForLevel);
                number = (m_ExperienceQuantity + number) - m_ExperienceForLevel;
                Debug.Log("number " + number);
                LevelUp(number);
            }
            else
            {
                m_ExperienceQuantity += number;
            }

            //For UI
            UIManager.instance.UIExperienceAndLeveling();

        }
    }

    public void LevelUp(int number)
    {
        m_Ship.m_ShipLevel++;
        Debug.Log("m_Ship.m_ShipLevel " + m_Ship.m_ShipLevel);
        if (m_Ship.m_ShipLevel < 20)
        {
            m_ExperienceQuantity = 0;
            m_ExperienceForLevel = m_ExperienceGap[m_Ship.m_ShipLevel + 1];
            Debug.Log("number " + number);
            AddExperience(number);
        }
        else
        {
            //For UI
            UIManager.instance.UIExperienceAndLevelingEnd();
        }


        //For UI
        UIManager.instance.UIExperienceAndLeveling();
    }

}
