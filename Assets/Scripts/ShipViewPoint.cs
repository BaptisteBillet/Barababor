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

/// <summary>
/// This class manage the differents aims of the 
/// </summary>
public class ShipViewPoint : MonoBehaviour {

    //All the Aims
    public GameObject m_StraightAims;
    Vector3 m_StraightAimsBase;

    //Others are coming

    //

    //The reference to the ship
    Ship m_Ship;

	// Use this for initialization
	void Start () {

        m_Ship = GetComponent<Ship>();

        m_StraightAimsBase = m_StraightAims.transform.localScale;
    }

    /// <summary>
    /// Starts to aims.
    /// </summary>
    /// <param name="aimsMode">The aims mode.</param>
    /// <param name="range">The range.</param>
    /// <param name="width">The width.</param>
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

    /// <summary>
    /// Resets all aims.
    /// </summary>
    public void ResetAllAims()
    {
        m_StraightAims.transform.localScale = m_StraightAimsBase;
        m_Ship.m_ShipEquipementBehavior.m_ShipAims.SetActive(true);
        //m_StraightAims.SetActive(false);
    }

}
