using UnityEngine;
using System.Collections;

public class BulletPlayer : Bullet
{

    void OnTriggerEnter(Collider other)
    {
        /*
        if (other.tag == "Player")
        {
           if (other.gameObject.GetComponent<Ship>().m_IsGreen != m_IsGreen)
           {
               other.gameObject.GetComponent<Ship>().m_ShipStateAndDamageBehavior.TakeDamage(m_Damages);
               DestroyMe();
           }
        }

        if (other.tag == "Ship")
        {
            if (other.gameObject.GetComponent<Ship>().m_IsGreen != m_IsGreen)
            {
                other.gameObject.GetComponent<Ship>().m_ShipStateAndDamageBehavior.TakeDamage(m_Damages);
                DestroyMe();
            }
        }

        if (other.tag == "Colonie")
        {
            if (other.gameObject.GetComponent<ColonieSystem>().m_Colonie.m_IsGreen != m_IsGreen)
            {
                other.gameObject.GetComponent<ColonieSystem>().TakeDamage(m_Damages);
                DestroyMe();
            }
        }

        if (other.tag == "Harbor")
        {
            if (other.gameObject.GetComponent<HarborLifeBehavior>().m_Harbor.m_IsGreen != m_IsGreen)
            {
                other.gameObject.GetComponent<HarborLifeBehavior>().TakeDamage(m_Damages);
                DestroyMe();
            }
        }
        /*
        if (other.tag == "Sea")
        {
           DestroyMe();
        }*/
    }



}

