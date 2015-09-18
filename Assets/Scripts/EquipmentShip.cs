using UnityEngine;
using System.Collections;

public class EquipmentShip : MonoBehaviour {

    public int m_Level;
    public int m_LevelUp;
    public string m_Login;
    public int m_Damage;
    public int m_DamageUpgrade;
    public float m_Range;
    public float m_RangeUpgrade;
    public float m_Width;
    public float m_WidthUpgrade;
    public int m_Cooldown;
    public int m_CooldownUpgrade;
    public int m_ShootType;
    public int m_ShootTypeUpgrade;
    public int m_Cost;
    public string m_Grade;
    public string m_Rank;
    public string m_State1;
    public string m_State2;
    public string m_Description;
    public string m_Type;
    public string m_ShownName;

    public WeaponList m_Weapon;

    public float m_ActualCooldown;
    public bool m_CanBeUsed;
    public bool m_IsSelected;
    public int m_ActionNumber;

    public bool m_Aiming;
    public AimsMode m_AimsMode;

    [HideInInspector]
    public ShipEquipementBehavior m_ShipEquipmentBehavior;



    void Start()
    {
        m_CanBeUsed = true;
        m_IsSelected = false;

        string name = "";

        switch (m_Weapon)
        {
            case WeaponList.LeBonVieuxCanonDesFamilles:
                name = "LeBonVieuxCanonDesFamilles";
                break;
            case WeaponList.SalveDePetitPlomb:
                name = "SalveDePetitPlomb";
                break;
            case WeaponList.LourdParpaingDeDureRealite:
                name = "LourdParpaingDeDureRealite";
                break;
        }

        if (name != "")
        {
            FillEquipment(name);
        }

    }

    void FillEquipment(string name)
    {
        m_Level = TriDataBase.instance.m_WeaponDico[name].m_Level;
        m_LevelUp = TriDataBase.instance.m_WeaponDico[name].m_LevelUp;
        m_Login = TriDataBase.instance.m_WeaponDico[name].m_Name;
        m_Damage = TriDataBase.instance.m_WeaponDico[name].m_Damage;
        m_DamageUpgrade = TriDataBase.instance.m_WeaponDico[name].m_DamageUpgrade;
        m_Range = TriDataBase.instance.m_WeaponDico[name].m_Range;
        m_RangeUpgrade = TriDataBase.instance.m_WeaponDico[name].m_RangeUpgrade;
        m_Width = TriDataBase.instance.m_WeaponDico[name].m_Width;
        m_WidthUpgrade = TriDataBase.instance.m_WeaponDico[name].m_WidthUpgrade;
        m_Cooldown = TriDataBase.instance.m_WeaponDico[name].m_Cooldown;
        m_CooldownUpgrade = TriDataBase.instance.m_WeaponDico[name].m_CooldownUpgrade;
        m_ShootType = TriDataBase.instance.m_WeaponDico[name].m_ShootType;
        m_ShootTypeUpgrade = TriDataBase.instance.m_WeaponDico[name].m_ShootTypeUpgrade;
        m_Cost = TriDataBase.instance.m_WeaponDico[name].m_Cost;
        m_Grade = TriDataBase.instance.m_WeaponDico[name].m_Grade;
        m_Rank = TriDataBase.instance.m_WeaponDico[name].m_Rank;
        m_State1 = TriDataBase.instance.m_WeaponDico[name].m_State1;
        m_State2 = TriDataBase.instance.m_WeaponDico[name].m_State2;
        m_Description = TriDataBase.instance.m_WeaponDico[name].m_Description;
        m_Type = TriDataBase.instance.m_WeaponDico[name].m_Type;
        m_ShownName = TriDataBase.instance.m_WeaponDico[name].m_ShownName;

        UIManager.instance.InitializeActionBar(m_ActionNumber, m_Weapon);
        UIManager.instance.ActualizeAction(m_ActionNumber, 0,0);



        switch(m_ShootType)
        {
            case 1:
                m_AimsMode = AimsMode.Cone;
                break;

            case 2:
                m_AimsMode = AimsMode.StraightShoot;
                break;

            case 3:
                m_AimsMode = AimsMode.Aura;
                break;

            case 4:
                m_AimsMode = AimsMode.ThroughtShoot;
                break;

            case 5:
                m_AimsMode = AimsMode.Targeting;
                break;

            case 6:
                m_AimsMode = AimsMode.DistantArea;
                break;

            case 7:
                m_AimsMode = AimsMode.Spur;
                break;

            case 8:
                m_AimsMode = AimsMode.Specialist;
                break;

            case 9:
                m_AimsMode = AimsMode.Cone;
                break;
        }

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
        m_ShipEquipmentBehavior.m_ShipViewPoint.ResetAllAims();

        m_Aiming = false;
        m_IsSelected = false;
    }

    void AimTheEquipment()
    {
        m_ShipEquipmentBehavior.m_ShipViewPoint.StartToAims(m_AimsMode, m_Range, m_Width);

        m_Aiming = true;
    }

    public void LevelUp()
    {

    }

    IEnumerator CCooldown()
    {
        m_ActualCooldown = m_Cooldown;
        float pourcent = m_Cooldown / 100;
        UIManager.instance.ActualizeAction(m_ActionNumber, 1, (int)m_ActualCooldown);
        while (m_ActualCooldown > 0)
        {
            yield return new WaitForSeconds(0.1f);

            m_ActualCooldown -= 0.1f;
            pourcent = m_ActualCooldown / m_Cooldown;
            UIManager.instance.ActualizeAction(m_ActionNumber, pourcent, (int)m_ActualCooldown);
        }

        UIManager.instance.ActualizeAction(m_ActionNumber, 0, 0);
        UIManager.instance.ButtonActionAnimator(m_ActionNumber, "Ready");
        m_CanBeUsed = true;
    }

    private GameObject DefineBullet()
    {
        GameObject bullet=null;

        switch (m_Weapon)
        {
            case WeaponList.LeBonVieuxCanonDesFamilles:
                bullet = m_ShipEquipmentBehavior.m_BulletPlayer;
                bullet.GetComponent<Bullet>().m_SelfDirected = false;
                bullet.GetComponent<Bullet>().m_MoveSpeed = 10;
                bullet.GetComponent<Bullet>().m_AsAState = false;
                bullet.transform.position = m_ShipEquipmentBehavior.m_DirectionScript.gameObject.transform.position;
                bullet.transform.rotation = m_ShipEquipmentBehavior.m_DirectionScript.gameObject.transform.rotation;
                break;
            case WeaponList.SalveDePetitPlomb:

                break;
            case WeaponList.LourdParpaingDeDureRealite:

                break;
        }

        //Common
        bullet.GetComponent<Bullet>().m_Damages = m_Damage;
        bullet.GetComponent<Bullet>().m_IsGreen = m_ShipEquipmentBehavior.m_Ship.m_IsGreen;
        bullet.GetComponent<Bullet>().m_IsNeutral = false;

        //return
        return bullet;
    }


    void UseTheEquipment()
    {
        GameObject bullet=null;
        GameObject bulletInstance=null;
        GameObject lanceur= m_ShipEquipmentBehavior.m_Ship.m_ShipCenter;
       

        switch (m_AimsMode)
        {
            case AimsMode.Cone:

                break;

            case AimsMode.StraightShoot:
                //Effect
                m_ShipEquipmentBehavior.m_Ship.m_ShipEffectsBehavior.ShootWhithCanon((float)m_ShipEquipmentBehavior.GetAngleOfAims(),true);

                bullet = DefineBullet();

                lanceur = m_ShipEquipmentBehavior.m_DirectionScript.gameObject;
                for (int i=0;i< m_Width+1;i++)
                {
                    if(i==0)
                    {
                        bulletInstance = Instantiate(bullet, new Vector3(lanceur.transform.position.x + i, lanceur.transform.position.y+1, lanceur.transform.position.z), bullet.transform.rotation) as GameObject;
                    }
                    else
                    {
                        bulletInstance = Instantiate(bullet, new Vector3(lanceur.transform.position.x + i, lanceur.transform.position.y+1, lanceur.transform.position.z), bullet.transform.rotation) as GameObject;
                        bulletInstance = Instantiate(bullet, new Vector3(lanceur.transform.position.x - i, lanceur.transform.position.y+1, lanceur.transform.position.z), bullet.transform.rotation) as GameObject;
                    }
                }


                break;

            case AimsMode.Aura:

                break;

            case AimsMode.ThroughtShoot:

                break;

            case AimsMode.Targeting:

                break;

            case AimsMode.DistantArea:

                break;

            case AimsMode.Spur:

                break;

            case AimsMode.Specialist:

                break;

        }

        //Reset
        m_ShipEquipmentBehavior.m_ShipViewPoint.ResetAllAims();

        m_CanBeUsed = false;
        m_ShipEquipmentBehavior.StopUsingAnyAction();
        StartCoroutine(CCooldown());
    }

  


}
