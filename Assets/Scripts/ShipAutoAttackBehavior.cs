using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipAutoAttackBehavior : MonoBehaviour {


    Ship m_Ship;

    //Detection
    Vector3 m_RayCastDirection;

    public GameObject m_Direction;

    public List<GameObject> m_ListObjectsDetected = new List<GameObject>();

    [HideInInspector]
    public GameObject m_Cible;

    //Shooting
    bool m_IsCurrentlyAttacking;

    public GameObject m_BulletPrefab;
    GameObject m_Bullet;
    Vector3 m_BulletStartPosition;


    // Use this for initialization
    void Start ()
    {
        m_Ship=GetComponent<Ship>();
        m_IsCurrentlyAttacking = false;
    }
	
   

    // Update is called once per frame
    void Update () {

        if(m_ListObjectsDetected.Count>0)
        {
            #region Ray
            RaycastHit hit;

            m_RayCastDirection = m_Direction.transform.TransformDirection(Vector3.forward);

            Ray myRay = new Ray(m_Direction.transform.position, m_RayCastDirection);

            Debug.DrawRay(m_Direction.transform.position, m_RayCastDirection * 100, Color.red);

            if (Physics.Raycast(myRay, out hit))
            {
                if (hit.transform.tag == "Ship" || hit.transform.tag == "Epave" || hit.transform.tag == "Colonie" || hit.transform.tag == "Mousse" || hit.transform.tag == "Harbor")
                {
                    for (int i = 0; i < m_ListObjectsDetected.Count; i++)
                    {
                        if (hit.transform.gameObject == m_ListObjectsDetected[i])
                        {
                            m_Cible = m_ListObjectsDetected[i];
                            break;
                        }
                    }
                }
            }
            else
            {
                m_Cible = null;
                CheckEmpty();
            }
            #endregion

            if(m_Cible!=null)
            {
                if(m_IsCurrentlyAttacking==false)
                {
                    m_IsCurrentlyAttacking = true;
                    StartToAttack();
                }
            }
            else
            {
                CheckEmpty();
                m_IsCurrentlyAttacking = false;
                StopAllCoroutines();
            }
        }

    }

    void CheckEmpty()
    {
        for (int i = 0; i < m_ListObjectsDetected.Count; i++)
        {
            if (m_ListObjectsDetected[i]==null)
            {
                m_ListObjectsDetected.RemoveAt(i);
            }
        }
    }

    void StartToAttack()
    {
        //Start the attack
        StartCoroutine(CAttack());
    }

    IEnumerator CAttack()
    {
        while(m_Cible!=null)
        {
            Shoot();
            yield return new WaitForSeconds(m_Ship.m_CCooldown/100);
        }
        CheckEmpty();


    }

    void Shoot()
    {
        //Canon Effect
        m_Ship.m_ShipEffectsBehavior.ShootWhithCanon(m_Ship.m_ShipEquipementBehavior.GetAngleOfAims(), false);

        //Canon
        m_BulletStartPosition = m_Ship.m_ShipCenter.transform.position;

        m_Bullet = Instantiate(m_BulletPrefab, m_BulletStartPosition, m_BulletPrefab.transform.rotation) as GameObject;
        m_Bullet.GetComponent<Bullet>().m_Cible = m_Cible;
        m_Bullet.GetComponent<Bullet>().m_Damages = (int)m_Ship.m_CDamage;
    }

}

      