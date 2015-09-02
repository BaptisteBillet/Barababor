using UnityEngine;
using System.Collections;

[SerializeField]
public class State : MonoBehaviour {

    public ShipStateAndDamageBehavior.EState m_State;
    public int m_Value;
    public float m_Time;
    public float m_Cooldown;

    public Ship m_Ship;

    public int m_InFireValue;
    public int m_HullBreachValue;

    float m_Timer;
    float m_Delay;

    void OnEnable()
    {
        m_Timer = 0.1f;
        m_Delay = 1;
       
        StartCoroutine(CStat());
    }

  
    IEnumerator CStat()
    {

        ChangeShip(true);

        m_Cooldown = m_Time;

        while (m_Cooldown > 0)
        {
            yield return new WaitForSeconds(m_Timer);
            m_Cooldown -= m_Timer;

            if (m_State == ShipStateAndDamageBehavior.EState.ONFIRE || m_State == ShipStateAndDamageBehavior.EState.HULLBREACH)
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
        if (m_Ship.m_ShipStateAndDamageBehavior.DeleteState(this.gameObject))
        {
            ChangeShip(false);
        }
        
    }

    void ChangeShip(bool IsAdd)
    {
        float addingValue;
        
        switch (m_State.ToString())
        {
            case"BOOSTED":
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CSpeedBase * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CSpeed += (int)addingValue; }
                else { m_Ship.m_CSpeed -= (int)addingValue; }
         
                break;
               
            case "SLOWED" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CSpeedBase * m_Value) / 100;

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
                addingValue = (m_Ship.m_Resistance * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_Resistance += addingValue; }
                else { m_Ship.m_Resistance -= addingValue; }

                break;

            case "SHIELD" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_Shield * m_Value) / 100;

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
                addingValue = (m_Ship.m_Resistance * m_Value) / 100;

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
                addingValue = (m_Ship.m_CCapacityBase * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CCapacity += (int)addingValue; }
                else { m_Ship.m_CCapacity -= (int)addingValue; }

                break;

            case "CLUTTERED" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CCapacityBase * m_Value) / 100;

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
                addingValue = (m_Ship.m_CVisionBase * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CVision += (int)addingValue; }
                else { m_Ship.m_CVision -= (int)addingValue; }

                break;

            case "DAZZLED" :
               
                break;

            case "INSENTIENT" :
                if (IsAdd)
                { m_Ship.m_IsStateChangeable = false; }
                else { m_Ship.m_IsStateChangeable = true; }

                break;

            case "REFURBISHMENT" :
                if (IsAdd)
                { m_Ship.m_ShipStateAndDamageBehavior.Refurbishment(this.gameObject);}
                break;

            case "STRIKE" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CCooldownBase * m_Value) / 100;

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
                addingValue = (m_Ship.m_CCooldownBase * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CCooldown += (int)addingValue; }
                else { m_Ship.m_CCooldown -= (int)addingValue; }

                break;

            case "WARHUNGRY" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CDamageBase * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CDamage += (int)addingValue; }
                else { m_Ship.m_CDamage -= (int)addingValue; }
                break;

            case "PACIFIST" :
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CDamageBase * m_Value) / 100;

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

            case "ONFIRE" :

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
                addingValue = (m_Ship.m_CRegenerationBase * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CRegeneration += (int)addingValue; }
                else { m_Ship.m_CRegeneration -= (int)addingValue; }
                break;

            case "TERMITE":
                //Calcul of the adding value;
                addingValue = (m_Ship.m_CRegenerationBase * m_Value) / 100;

                if (IsAdd)
                { m_Ship.m_CRegeneration -= (int)addingValue; }
                else { m_Ship.m_CRegeneration += (int)addingValue; }

                if(m_Ship.m_CRegeneration<=0)
                {
                    m_Ship.m_CRegeneration = 0;
                }
                break;
        }


        if (IsAdd == false)
        {
            Destroy(this.gameObject);
        }
        UIManager.instance.UIState();
    }



}
