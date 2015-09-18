using UnityEngine;
using System.Collections;

public class BulletTourelle : Bullet {


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Ship>().m_IsGreen!= m_IsGreen)
            {
                other.gameObject.GetComponent<Ship>().m_ShipStateAndDamageBehavior.TakeDamage(m_Damages);
                DestroyMe();
            }
        }
    }
}
