using UnityEngine;
using System.Collections;

public class ShipCanonParticule : MonoBehaviour {

    public GameObject m_CanonEffect;

    public void UseCanon()
    {
        m_CanonEffect.SetActive(true);
    }

}
