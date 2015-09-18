using UnityEngine;
using System.Collections;

public class Epave : MonoBehaviour {

    int m_Life;
    int m_NumberOfTresors;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spur")
        {
            Die();
        }
        if (other.gameObject.tag == "Bullet")
        {
            Die(other.gameObject);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
    void Die(GameObject bullet)
    {
        Destroy(bullet);
        Destroy(this.gameObject);
    }

}
