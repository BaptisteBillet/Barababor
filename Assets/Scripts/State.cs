using UnityEngine;
using System.Collections;

/// <summary>
/// The State class manage all the state
/// A new State GameObject is create for every state the ship has. 
/// This class manage itself, and then destoy itself;
/// However, the state can be destroy by the ship.
/// </summary>
public class State : MonoBehaviour {

    #region Members declaration
    //The kind of state
    public ShipStateAndDamageBehavior.EState m_State;
    //THe value of state modificator
    public int m_Value;
    //The Time during wich the state will be effective
    public float m_Time;
    //The actuak 
    public float m_Cooldown;

    //The access to the ship
    public Ship m_Ship;

    //Only for some specifics states
    const int m_ONFIREDAMAGE=6;
    const int m_HULLBREACHVALUE=1;

    int m_OnFireValue = 0;
    int m_HullBreachValue = 0;

    float m_Timer;
    float m_Delay;
    //
    #endregion

    void OnEnable()
    {
        m_Timer = 0.1f;
        m_Delay = 1;

        StartCoroutine(CStat());
    }
  
    IEnumerator CStat()
    {
        //Make the changes
        ChangeShip(true);
        //Reset the cooldown
        m_Cooldown = m_Time;

        //Start the cooldown
        while (m_Cooldown > 0)
        {
            //Decrement the cooldown
            yield return new WaitForSeconds(m_Timer);
            m_Cooldown -= m_Timer;

            //Only for case like OnFire or HullBreach
            if (m_State == ShipStateAndDamageBehavior.EState.ONFIRE || m_State == ShipStateAndDamageBehavior.EState.HULLBREACH)
            {
                m_Delay -= m_Timer;

                if(m_Delay<=0)
                {
                    m_Delay = 1;
                    //On fire damages
                    if(m_OnFireValue>0)
                    {
                        m_Ship.m_ShipStateAndDamageBehavior.TakeDamage(m_OnFireValue);
                    }
                    //For HullBreach
                    if (m_HullBreachValue > 0)
                    {
                        m_Ship.m_ShipTresorBehavior.LooseTresor();
                    }
                }

            }
        }

        //Only for HarborRepair
        if (m_State == ShipStateAndDamageBehavior.EState.HARBORREPAIR)
        {
            while (m_Ship.m_NearFromHomeHarbor)
            {
                //Decrement the cooldown
                yield return new WaitForSeconds(m_Timer);
            }
        }
        
        
        //CooldownOver
        if (m_Ship.m_ShipStateAndDamageBehavior.DeleteState(this.gameObject))
        {
            ChangeShip(false);
        }
        UIManager.instance.ActualizeUIState();
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
                { m_Ship.m_Resistance -= addingValue; }
                else { m_Ship.m_Resistance += addingValue; }

                break;

            case "SHIELD" :
                //Calcul of the adding value;
                addingValue = m_Value;

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
                { m_Ship.m_Resistance += addingValue; }
                else { m_Ship.m_Resistance -= addingValue; }

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
                m_Ship.m_ShipCameraBehavior.MoveCamera("clairvoyant");
                break;

            case "DAZZLED" :
                m_Ship.m_ShipCameraBehavior.MoveCamera("dazzled");
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
                m_OnFireValue = m_ONFIREDAMAGE;
                break;

            case "HULLBREACH" :
                m_HullBreachValue = m_HULLBREACHVALUE;
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

            case "HARBORREPAIR":
                //Calcul of the adding value;
                addingValue = (2.5f*100) / m_Ship.m_CHealthPointBase;

                if (IsAdd)
                { m_Ship.m_CRegeneration += (int)addingValue; m_Ship.m_ShipStateAndDamageBehavior.m_TimeRegeneration = 0.5f; }
                else
                {
                  m_Ship.m_CRegeneration -= (int)addingValue;
                  m_Ship.m_ShipStateAndDamageBehavior.m_TimeRegeneration = 1f;
                }

                break;
        }


        if (IsAdd == false)
        {
            Destroy(this.gameObject);
        }
        UIManager.instance.ActualizeUIState();
    }
}
