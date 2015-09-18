using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Canon : MonoBehaviour {

    public int m_Damages;
    public int m_Cooldown;

    public GameObject m_BulletPrefab;
    GameObject m_Bullet;

    public List<GameObject> m_ListCible = new List<GameObject>();

    bool m_IsShooting;

    public GameObject m_Cible;

    public GameObject m_BulletStartPosition;
    public GameObject m_ParticuleStartPosition;

    public GameObject m_Particule;

    public float m_Puissance;

    // Use this for initialization
    void Start () {

        StartCoroutine(WaitForACible());

	}
	
    public void AddToList(GameObject go)
    {
        m_ListCible.Add(go);
    }

    public void RemoveFromList(GameObject go)
    {
        for(int i=0; i<m_ListCible.Count;i++)
        {
            if(m_ListCible[i] == go)
            {
                m_ListCible.RemoveAt(i);
            }
            if(m_Cible== go)
            {
                m_Cible = null;
            }
        }
    }

    IEnumerator WaitForACible()
    {
        while (this.gameObject)
        {
            while (m_ListCible.Count > 0)
            {
                if(m_IsShooting==false)
                {
                    m_Cible = m_ListCible[0];

                    m_IsShooting = true;
                    StartCoroutine(ShootACible());
                }
                else
                {
                    if (m_Cible != null)
                    {
                        Vector3 targetPostition = new Vector3(m_Cible.transform.position.x, this.transform.position.y, m_Cible.transform.position.z);
                        this.transform.LookAt(targetPostition);
                    }
                }

                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForEndOfFrame();
        }

    }


    IEnumerator ShootACible()
    {
        while (m_Cible != null)
        {
            Shoot();
            yield return new WaitForSeconds(m_Cooldown);
        }

        //For the cooldown effect
        yield return new WaitForSeconds(m_Cooldown);

        m_IsShooting = false;
    }


    void Shoot()
    {
        Instantiate(m_Particule, m_ParticuleStartPosition.transform.position, m_Particule.transform.rotation);
        m_Bullet = Instantiate(m_BulletPrefab, m_BulletStartPosition.transform.position, m_BulletPrefab.transform.rotation) as GameObject;
        m_Bullet.GetComponent<Bullet>().m_Cible = m_Cible.GetComponent<Ship>().m_ShipCenter;
        m_Bullet.GetComponent<Bullet>().m_Damages = m_Damages;
    }

}
