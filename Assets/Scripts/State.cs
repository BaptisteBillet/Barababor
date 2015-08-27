using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

    public EState m_State;
    public int m_Value;
    public float m_Time;
    public float m_Cooldown;

    public Ship m_Ship;

    public int m_InFireValue;
    public int m_HullBreachValue;

    float m_Timer;
    float m_Delay;

    void Start()
    {
        m_Timer = 0.1f;
        m_Delay = 1;

        StartCoroutine(CStat(this));
    }


    IEnumerator CStat(State stat)
    {
        ChangeShip(true, this);

        while (stat.m_Cooldown > 0)
        {
            yield return new WaitForSeconds(m_Timer);
            m_Cooldown -= m_Timer;

            if (m_State == EState.INFIRE || m_State == EState.HULLBREACH)
            {
                m_Delay -= m_Timer;

                if(m_Delay<=0)
                {
                    m_Delay = 1;
                    m_Ship.m_CHealthPoint -= m_InFireValue;
                    m_Ship.m_CCapacity -= m_HullBreachValue;
                }

            }
        }
        //CooldownOver
        if(m_Ship.DeleteState(this))
        {
            ChangeShip(false, this);
        }
    }

    void ChangeShip(bool IsAdd, State state)
    {
        float addingValue;

        switch (state.ToString())
        {
            case"BOOSTED":
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CSpeedBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CSpeed += (int)addingValue; }
                else { m_Ship.m_CSpeed -= (int)addingValue; }
         
                break;
               
            case "SLOWED" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CSpeedBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CSpeed -= (int)addingValue; }
                else { m_Ship.m_CSpeed += (int)addingValue; }

                if (m_Ship.m_CCooldown <= 0.1f)
                {
                    m_Ship.m_CCooldown = 0.1f;
                }

                break;

            case "UNSINKABLE" :
                if (IsAdd)
                { m_Ship.m_IsDamageable = false; }
                else { m_Ship.m_IsDamageable = true; }

                break;

            case "CONSOLIDATED" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_Resistance * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_Resistance += addingValue; }
                else { m_Ship.m_Resistance -= addingValue; }

                break;

            case "SHIELD" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_Shield * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_Shield += (int)addingValue; }
                else { m_Ship.m_Shield -= (int)addingValue; }

                if(m_Ship.m_Shield<0)
                {
                    m_Ship.m_Shield = 0;
                }
                break;

            case "WEAKENED" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_Resistance * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_Resistance -= addingValue; }
                else { m_Ship.m_Resistance += addingValue; }

                if (m_Ship.m_CCooldown <= 0)
                {
                    m_Ship.m_CCooldown = 0;
                }

                break;

            case "ORGANIZED" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CCapacityBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CCapacity += (int)addingValue; }
                else { m_Ship.m_CCapacity -= (int)addingValue; }

                break;

            case "CROWDED" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CCapacityBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CCapacity -= (int)addingValue; }
                else { m_Ship.m_CCapacity += (int)addingValue; }

                if (m_Ship.m_CCooldown <= 0)
                {
                    m_Ship.m_CCooldown = 0;
                }
                break;

            case "CLAIRVOYANT" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CVisionBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CVision += (int)addingValue; }
                else { m_Ship.m_CVision -= (int)addingValue; }

                break;

            case "DAZZLED" :
               
                break;

            case "INSENSIBLE" :
                if (IsAdd)
                { m_Ship.m_IsStateChangeable = false; }
                else { m_Ship.m_IsStateChangeable = true; }

                break;

            case "REFURBISHMENT" :
                m_Ship.Refurbishment();
                break;

            case "STRIKE" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CCooldownBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CCooldown -= (int)addingValue; }
                else { m_Ship.m_CCooldown += (int)addingValue; }

                if (m_Ship.m_CCooldown <= 0)
                {
                    m_Ship.m_CCooldown = 0;
                }

                break;

            case "ZEAL" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CCooldownBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CCooldown += (int)addingValue; }
                else { m_Ship.m_CCooldown -= (int)addingValue; }

                break;

            case "MANGY" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CDamageBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CDamage += (int)addingValue; }
                else { m_Ship.m_CDamage -= (int)addingValue; }
                break;

            case "PACIFIST" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CDamageBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CDamage -= (int)addingValue; }
                else { m_Ship.m_CDamage += (int)addingValue; }

                if (m_Ship.m_CDamage <= 0)
                {
                    m_Ship.m_CDamage = 0;
                }

                break;

            case "CEASEFIRE" :
                if (IsAdd)
                { m_Ship.m_CanAttack = false; }
                else { m_Ship.m_CanAttack = true; }

                break;

            case "INFIRE" :

                break;

            case "HULLBREACH" :

                break;

            case "LOCKED" :
                if (IsAdd)
                { m_Ship.m_CanMove = false; }
                else { m_Ship.m_CanMove = true; }
                break;

            case "DAMN" :
                if (IsAdd)
                { m_Ship.m_IsDamn = true; }
                else { m_Ship.m_IsDamn = false; }
                break;

            case "REPAIR" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CRegenerationBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CRegeneration += (int)addingValue; }
                else { m_Ship.m_CRegeneration -= (int)addingValue; }
                break;

            case "TERMITE":
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CRegenerationBase * state.m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CRegeneration -= (int)addingValue; }
                else { m_Ship.m_CRegeneration += (int)addingValue; }

                if(m_Ship.m_CRegeneration<=0)
                {
                    m_Ship.m_CRegeneration = 0;
                }
                break;
        }

    }



}
