using UnityEngine;
using System.Collections;

public class ShipSpurBehavior : MonoBehaviour {

    Ship m_Ship;

    public GameObject m_Spur;

	// Use this for initialization
	void Start ()
    {
        m_Ship = GetComponent<Ship>();
        m_Spur.SetActive(false);
    }

    public void ActivateSpur(bool activate)
    {
        m_Spur.SetActive(activate);
    }


}
