using UnityEngine;
using System.Collections;

public class AutoAttack : MonoBehaviour {

    public ShipAutoAttackBehavior m_ShipAutoAttackBehavior;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ship" || other.tag == "Epave" || other.tag == "Colonie" || other.tag == "Mousse" || other.tag == "Harbor")
        {
            m_ShipAutoAttackBehavior.m_ListObjectsDetected.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ship" || other.tag == "Epave" || other.tag == "Colonie" || other.tag == "Mousse" || other.tag == "Harbor")
        {
            for (int i = 0; i < m_ShipAutoAttackBehavior.m_ListObjectsDetected.Count; i++)
            {
                if (other.gameObject == m_ShipAutoAttackBehavior.m_ListObjectsDetected[i])
                {
                    m_ShipAutoAttackBehavior.m_ListObjectsDetected.RemoveAt(i);

                    if (m_ShipAutoAttackBehavior.m_Cible == other.gameObject)
                    {
                        m_ShipAutoAttackBehavior.m_Cible = null;
                    }
                    break;
                }
            }
        }
    }

}
