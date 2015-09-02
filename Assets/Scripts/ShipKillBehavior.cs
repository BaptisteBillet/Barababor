using UnityEngine;
using System.Collections;

public class ShipKillBehavior : MonoBehaviour {

    Ship m_Ship;

	// Use this for initialization
	void Start () {

        m_Ship = GetComponent<Ship>();
	}

    public enum EEnemy
    {
        SHIP,
        MOSS,
        CAMP
    }

    public void KillSomething(EEnemy type, GameObject theDead)
    {
        switch (type.ToString())
        {
            case "SHIP":
                m_Ship.m_ShipExperience += theDead.GetComponent<Ship>().m_ExperienceWin;
                break;

            case "MOSS":

                break;

            case "CAMP":

                break;

        }




    }
}
