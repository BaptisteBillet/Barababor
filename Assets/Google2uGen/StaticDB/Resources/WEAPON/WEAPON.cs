//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class WEAPONRow : IGoogle2uRow
	{
		public int _Level;
		public int _LevelUp;
		public string _Name;
		public int _Damage;
		public int _DamageUpgrade;
		public int _Range;
		public int _RangeUpgrade;
		public float _Cooldown;
		public float _CooldownUpgrade;
		public int _ShootType;
		public int _ShootTypeUpgrade;
		public int _Cost;
		public string _Grade;
		public string _Rank;
		public string _State1;
		public string _State2;
		public string _Description;
		public WEAPONRow(string __ID, string __Level, string __LevelUp, string __Name, string __Damage, string __DamageUpgrade, string __Range, string __RangeUpgrade, string __Cooldown, string __CooldownUpgrade, string __ShootType, string __ShootTypeUpgrade, string __Cost, string __Grade, string __Rank, string __State1, string __State2, string __Description) 
		{
			{
			int res;
				if(int.TryParse(__Level, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Level = res;
				else
					Debug.LogError("Failed To Convert _Level string: "+ __Level +" to int");
			}
			{
			int res;
				if(int.TryParse(__LevelUp, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_LevelUp = res;
				else
					Debug.LogError("Failed To Convert _LevelUp string: "+ __LevelUp +" to int");
			}
			_Name = __Name.Trim();
			{
			int res;
				if(int.TryParse(__Damage, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Damage = res;
				else
					Debug.LogError("Failed To Convert _Damage string: "+ __Damage +" to int");
			}
			{
			int res;
				if(int.TryParse(__DamageUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_DamageUpgrade = res;
				else
					Debug.LogError("Failed To Convert _DamageUpgrade string: "+ __DamageUpgrade +" to int");
			}
			{
			int res;
				if(int.TryParse(__Range, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Range = res;
				else
					Debug.LogError("Failed To Convert _Range string: "+ __Range +" to int");
			}
			{
			int res;
				if(int.TryParse(__RangeUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_RangeUpgrade = res;
				else
					Debug.LogError("Failed To Convert _RangeUpgrade string: "+ __RangeUpgrade +" to int");
			}
			{
			float res;
				if(float.TryParse(__Cooldown, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Cooldown = res;
				else
					Debug.LogError("Failed To Convert _Cooldown string: "+ __Cooldown +" to float");
			}
			{
			float res;
				if(float.TryParse(__CooldownUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CooldownUpgrade = res;
				else
					Debug.LogError("Failed To Convert _CooldownUpgrade string: "+ __CooldownUpgrade +" to float");
			}
			{
			int res;
				if(int.TryParse(__ShootType, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_ShootType = res;
				else
					Debug.LogError("Failed To Convert _ShootType string: "+ __ShootType +" to int");
			}
			{
			int res;
				if(int.TryParse(__ShootTypeUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_ShootTypeUpgrade = res;
				else
					Debug.LogError("Failed To Convert _ShootTypeUpgrade string: "+ __ShootTypeUpgrade +" to int");
			}
			{
			int res;
				if(int.TryParse(__Cost, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Cost = res;
				else
					Debug.LogError("Failed To Convert _Cost string: "+ __Cost +" to int");
			}
			_Grade = __Grade.Trim();
			_Rank = __Rank.Trim();
			_State1 = __State1.Trim();
			_State2 = __State2.Trim();
			_Description = __Description.Trim();
		}

		public int Length { get { return 17; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Level.ToString();
					break;
				case 1:
					ret = _LevelUp.ToString();
					break;
				case 2:
					ret = _Name.ToString();
					break;
				case 3:
					ret = _Damage.ToString();
					break;
				case 4:
					ret = _DamageUpgrade.ToString();
					break;
				case 5:
					ret = _Range.ToString();
					break;
				case 6:
					ret = _RangeUpgrade.ToString();
					break;
				case 7:
					ret = _Cooldown.ToString();
					break;
				case 8:
					ret = _CooldownUpgrade.ToString();
					break;
				case 9:
					ret = _ShootType.ToString();
					break;
				case 10:
					ret = _ShootTypeUpgrade.ToString();
					break;
				case 11:
					ret = _Cost.ToString();
					break;
				case 12:
					ret = _Grade.ToString();
					break;
				case 13:
					ret = _Rank.ToString();
					break;
				case 14:
					ret = _State1.ToString();
					break;
				case 15:
					ret = _State2.ToString();
					break;
				case 16:
					ret = _Description.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Level":
					ret = _Level.ToString();
					break;
				case "LevelUp":
					ret = _LevelUp.ToString();
					break;
				case "Name":
					ret = _Name.ToString();
					break;
				case "Damage":
					ret = _Damage.ToString();
					break;
				case "DamageUpgrade":
					ret = _DamageUpgrade.ToString();
					break;
				case "Range":
					ret = _Range.ToString();
					break;
				case "RangeUpgrade":
					ret = _RangeUpgrade.ToString();
					break;
				case "Cooldown":
					ret = _Cooldown.ToString();
					break;
				case "CooldownUpgrade":
					ret = _CooldownUpgrade.ToString();
					break;
				case "ShootType":
					ret = _ShootType.ToString();
					break;
				case "ShootTypeUpgrade":
					ret = _ShootTypeUpgrade.ToString();
					break;
				case "Cost":
					ret = _Cost.ToString();
					break;
				case "Grade":
					ret = _Grade.ToString();
					break;
				case "Rank":
					ret = _Rank.ToString();
					break;
				case "State1":
					ret = _State1.ToString();
					break;
				case "State2":
					ret = _State2.ToString();
					break;
				case "Description":
					ret = _Description.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Level" + " : " + _Level.ToString() + "} ";
			ret += "{" + "LevelUp" + " : " + _LevelUp.ToString() + "} ";
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Damage" + " : " + _Damage.ToString() + "} ";
			ret += "{" + "DamageUpgrade" + " : " + _DamageUpgrade.ToString() + "} ";
			ret += "{" + "Range" + " : " + _Range.ToString() + "} ";
			ret += "{" + "RangeUpgrade" + " : " + _RangeUpgrade.ToString() + "} ";
			ret += "{" + "Cooldown" + " : " + _Cooldown.ToString() + "} ";
			ret += "{" + "CooldownUpgrade" + " : " + _CooldownUpgrade.ToString() + "} ";
			ret += "{" + "ShootType" + " : " + _ShootType.ToString() + "} ";
			ret += "{" + "ShootTypeUpgrade" + " : " + _ShootTypeUpgrade.ToString() + "} ";
			ret += "{" + "Cost" + " : " + _Cost.ToString() + "} ";
			ret += "{" + "Grade" + " : " + _Grade.ToString() + "} ";
			ret += "{" + "Rank" + " : " + _Rank.ToString() + "} ";
			ret += "{" + "State1" + " : " + _State1.ToString() + "} ";
			ret += "{" + "State2" + " : " + _State2.ToString() + "} ";
			ret += "{" + "Description" + " : " + _Description.ToString() + "} ";
			return ret;
		}
	}
	public sealed class WEAPON : IGoogle2uDB
	{
		public enum rowIds {
			Weapon1
		};
		public string [] rowNames = {
			"Weapon1"
		};
		public System.Collections.Generic.List<WEAPONRow> Rows = new System.Collections.Generic.List<WEAPONRow>();

		public static WEAPON Instance
		{
			get { return NestedWEAPON.instance; }
		}

		private class NestedWEAPON
		{
			static NestedWEAPON() { }
			internal static readonly WEAPON instance = new WEAPON();
		}

		private WEAPON()
		{
			Rows.Add( new WEAPONRow("Weapon1", "1", "1", "Weapon1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "", "", "", "", ""));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public WEAPONRow GetRow(rowIds in_RowID)
		{
			WEAPONRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public WEAPONRow GetRow(string in_RowString)
		{
			WEAPONRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
