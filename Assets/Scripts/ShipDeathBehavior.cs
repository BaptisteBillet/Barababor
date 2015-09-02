using UnityEngine;
using System.Collections;

public class ShipDeathBehavior : MonoBehaviour {

    Vector3 m_StartPosition;
    Quaternion m_StartRotation;

    [Space(10)]
    public float m_RespawnTimeMinutes;
    public float m_RespawnTimeSecondes;

    //References
    Ship m_Ship;

    // Use this for initialization
    void Start()
    {

        m_Ship = GetComponent<Ship>();
        m_RespawnTimeMinutes=0;
        m_RespawnTimeSecondes=0;
        m_StartPosition = this.transform.position;
        m_StartRotation = this.transform.rotation;

    }

    public void Die()
    {
        m_Ship.m_IsDead = true;
        m_Ship.m_CanMove = false;
        m_Ship.m_IsDamageable = false;
        m_Ship.m_IsStateChangeable = false;
        m_Ship.m_CanAttack = false;

        m_Ship.m_CHealthPoint = 0;
        UIManager.instance.UILife();

        Game.instance.AddStat(m_Ship.m_Team, "Death");

        float bonusTime = 0;
        //Calcul of the respawn time
        if (Game.instance.m_TimeOfPlay.minutes > m_Ship.FACTORTIMEEXPEND)
        {
            bonusTime = (Game.instance.m_TimeOfPlay.minutes - m_Ship.FACTORTIMEEXPEND) * m_Ship.FACTORTIMESUPP;
        }

        m_RespawnTimeSecondes = m_Ship.FACTORRESPAWNTIME + m_Ship.m_ShipLevel + bonusTime;


        while(m_RespawnTimeSecondes>60)
        {
            m_RespawnTimeMinutes++;
            m_RespawnTimeSecondes -= 60;
        }


        StartCoroutine(Respawn());
        //Feedback die
    }

    IEnumerator Respawn()
    {
        UIManager.instance.UIRespawnTimer();
        while (m_RespawnTimeSecondes > 0 || m_RespawnTimeMinutes > 0)
        {
            yield return new WaitForSeconds(1f);
            m_RespawnTimeSecondes--;
            
            if(m_RespawnTimeSecondes <= 0)
            {
                if(m_RespawnTimeMinutes > 0)
                {
                    m_RespawnTimeSecondes = 60;
                    m_RespawnTimeMinutes--;
                }
            }

            UIManager.instance.UIRespawnTimer();
        }

        m_Ship.ForceRefurbisment();

        //Spawn
        this.transform.position = m_StartPosition;
        this.transform.rotation = m_StartRotation;


    }
}
