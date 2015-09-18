using UnityEngine;
using System.Collections;

public enum AimsMode
{
    Cone,
    StraightShoot,
    Aura,
    ThroughtShoot,
    Targeting,
    DistantArea,
    Spur,
    Other,
    Specialist

}

public class ShipViewPoint : MonoBehaviour {

    public GameObject m_StraightAims;
    Vector3 m_StraightAimsBase;


    Ship m_Ship;

	// Use this for initialization
	void Start () {

        m_Ship = GetComponent<Ship>();

        m_StraightAimsBase = m_StraightAims.transform.localScale;
    }


    public void StartToAims(AimsMode aimsMode, float range, float width)
    {
        //Begin by reset all aims
        ResetAllAims();

        m_Ship.m_ShipEquipementBehavior.m_ShipAims.SetActive(false);

        switch(aimsMode)
        {
            case AimsMode.StraightShoot:
                m_StraightAims.transform.localScale = new Vector3(0.79f+(0.245f* range), m_StraightAims.transform.localScale.y,width);
                //m_StraightAims.SetActive(true);
                break;
        }

        
    }

    public void ResetAllAims()
    {
        m_StraightAims.transform.localScale = m_StraightAimsBase;
        m_Ship.m_ShipEquipementBehavior.m_ShipAims.SetActive(true);
        //m_StraightAims.SetActive(false);
    }

}
