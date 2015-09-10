using UnityEngine;
using System.Collections;

public class EquipmentShip : MonoBehaviour {

    public int m_Level;
    public int m_LevelUp;
    public string m_Name;
    public int m_Damage;
    public int m_DamageUpgrade;
    public int m_Range;
    public int m_RangeUpgrade;
    public int m_Cooldown;
    public int m_CooldownUpgrade;
    public int m_ShootType;
    public int m_ShootTypeUpgrade;
    public int m_Cost;
    public string m_Grade;
    public string m_Rank;
    public string m_State1;
    public string m_State2;

    public float m_ActualCooldown;
    public bool m_CanBeUsed;
    public bool m_IsSelected;

    public ShipEquipementBehavior m_ShipEquipmentBehavior;

    void Start()
    {
        m_CanBeUsed = true;
        m_IsSelected = false;
    }

    public void EquipmentManager()
    {
        //If the Equipment is Available
        if (m_CanBeUsed)
        {
            //If the Equipment is already selected
            if (m_IsSelected == false)
            {
                //If not, show to the player the Aim
                m_IsSelected = true;
                AimTheEquipment();
            }
            else
            {
                //If yes, use the equipment
                m_IsSelected = false;
                UseTheEquipment();
            }
        }
    }

    public void StopUsing()
    {
        m_IsSelected = false;
    }

    void AimTheEquipment()
    {

    }

    void UseTheEquipment()
    {
        m_CanBeUsed = false;
        m_ShipEquipmentBehavior.StopUsingAnyAction();
        StartCoroutine(CCooldown());

    }

    public void LevelUp()
    {

    }

    IEnumerator CCooldown()
    {
        m_ActualCooldown = m_Cooldown;
        while (m_ActualCooldown > 0)
        {
            yield return new WaitForSeconds(0.1f);
            m_ActualCooldown -= 0.1f;
        }
        m_CanBeUsed = true;
    }

}
