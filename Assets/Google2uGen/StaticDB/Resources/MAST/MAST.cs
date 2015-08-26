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
	public class MASTRow : IGoogle2uRow
	{
		public string _Name;
		public int _HealthPoint;
		public int _Capacity;
		public int _Speed;
		public int _Damage;
		public int _Vision;
		public int _Regeneration;
		public int _HealthPointUpgrade;
		public int _CapacityUpgrade;
		public int _SpeedUpgrade;
		public int _DamageUpgrade;
		public int _VisionUpgrade;
		public int _RegenerationUpgrade;
		public int _Cost;
		public string _Grade;
		public string _Rank;
		public MASTRow(string __ID, string __Name, string __HealthPoint, string __Capacity, string __Speed, string __Damage, string __Vision, string __Regeneration, string __HealthPointUpgrade, string __CapacityUpgrade, string __SpeedUpgrade, string __DamageUpgrade, string __VisionUpgrade, string __RegenerationUpgrade, string __Cost, string __Grade, string __Rank) 
		{
			_Name = __Name.Trim();
			{
			int res;
				if(int.TryParse(__HealthPoint, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_HealthPoint = res;
				else
					Debug.LogError("Failed To Convert _HealthPoint string: "+ __HealthPoint +" to int");
			}
			{
			int res;
				if(int.TryParse(__Capacity, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Capacity = res;
				else
					Debug.LogError("Failed To Convert _Capacity string: "+ __Capacity +" to int");
			}
			{
			int res;
				if(int.TryParse(__Speed, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Speed = res;
				else
					Debug.LogError("Failed To Convert _Speed string: "+ __Speed +" to int");
			}
			{
			int res;
				if(int.TryParse(__Damage, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Damage = res;
				else
					Debug.LogError("Failed To Convert _Damage string: "+ __Damage +" to int");
			}
			{
			int res;
				if(int.TryParse(__Vision, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Vision = res;
				else
					Debug.LogError("Failed To Convert _Vision string: "+ __Vision +" to int");
			}
			{
			int res;
				if(int.TryParse(__Regeneration, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Regeneration = res;
				else
					Debug.LogError("Failed To Convert _Regeneration string: "+ __Regeneration +" to int");
			}
			{
			int res;
				if(int.TryParse(__HealthPointUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_HealthPointUpgrade = res;
				else
					Debug.LogError("Failed To Convert _HealthPointUpgrade string: "+ __HealthPointUpgrade +" to int");
			}
			{
			int res;
				if(int.TryParse(__CapacityUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CapacityUpgrade = res;
				else
					Debug.LogError("Failed To Convert _CapacityUpgrade string: "+ __CapacityUpgrade +" to int");
			}
			{
			int res;
				if(int.TryParse(__SpeedUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_SpeedUpgrade = res;
				else
					Debug.LogError("Failed To Convert _SpeedUpgrade string: "+ __SpeedUpgrade +" to int");
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
				if(int.TryParse(__VisionUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_VisionUpgrade = res;
				else
					Debug.LogError("Failed To Convert _VisionUpgrade string: "+ __VisionUpgrade +" to int");
			}
			{
			int res;
				if(int.TryParse(__RegenerationUpgrade, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_RegenerationUpgrade = res;
				else
					Debug.LogError("Failed To Convert _RegenerationUpgrade string: "+ __RegenerationUpgrade +" to int");
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
		}

		public int Length { get { return 16; } }

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
					ret = _Name.ToString();
					break;
				case 1:
					ret = _HealthPoint.ToString();
					break;
				case 2:
					ret = _Capacity.ToString();
					break;
				case 3:
					ret = _Speed.ToString();
					break;
				case 4:
					ret = _Damage.ToString();
					break;
				case 5:
					ret = _Vision.ToString();
					break;
				case 6:
					ret = _Regeneration.ToString();
					break;
				case 7:
					ret = _HealthPointUpgrade.ToString();
					break;
				case 8:
					ret = _CapacityUpgrade.ToString();
					break;
				case 9:
					ret = _SpeedUpgrade.ToString();
					break;
				case 10:
					ret = _DamageUpgrade.ToString();
					break;
				case 11:
					ret = _VisionUpgrade.ToString();
					break;
				case 12:
					ret = _RegenerationUpgrade.ToString();
					break;
				case 13:
					ret = _Cost.ToString();
					break;
				case 14:
					ret = _Grade.ToString();
					break;
				case 15:
					ret = _Rank.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Name":
					ret = _Name.ToString();
					break;
				case "HealthPoint":
					ret = _HealthPoint.ToString();
					break;
				case "Capacity":
					ret = _Capacity.ToString();
					break;
				case "Speed":
					ret = _Speed.ToString();
					break;
				case "Damage":
					ret = _Damage.ToString();
					break;
				case "Vision":
					ret = _Vision.ToString();
					break;
				case "Regeneration":
					ret = _Regeneration.ToString();
					break;
				case "HealthPointUpgrade":
					ret = _HealthPointUpgrade.ToString();
					break;
				case "CapacityUpgrade":
					ret = _CapacityUpgrade.ToString();
					break;
				case "SpeedUpgrade":
					ret = _SpeedUpgrade.ToString();
					break;
				case "DamageUpgrade":
					ret = _DamageUpgrade.ToString();
					break;
				case "VisionUpgrade":
					ret = _VisionUpgrade.ToString();
					break;
				case "RegenerationUpgrade":
					ret = _RegenerationUpgrade.ToString();
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
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "HealthPoint" + " : " + _HealthPoint.ToString() + "} ";
			ret += "{" + "Capacity" + " : " + _Capacity.ToString() + "} ";
			ret += "{" + "Speed" + " : " + _Speed.ToString() + "} ";
			ret += "{" + "Damage" + " : " + _Damage.ToString() + "} ";
			ret += "{" + "Vision" + " : " + _Vision.ToString() + "} ";
			ret += "{" + "Regeneration" + " : " + _Regeneration.ToString() + "} ";
			ret += "{" + "HealthPointUpgrade" + " : " + _HealthPointUpgrade.ToString() + "} ";
			ret += "{" + "CapacityUpgrade" + " : " + _CapacityUpgrade.ToString() + "} ";
			ret += "{" + "SpeedUpgrade" + " : " + _SpeedUpgrade.ToString() + "} ";
			ret += "{" + "DamageUpgrade" + " : " + _DamageUpgrade.ToString() + "} ";
			ret += "{" + "VisionUpgrade" + " : " + _VisionUpgrade.ToString() + "} ";
			ret += "{" + "RegenerationUpgrade" + " : " + _RegenerationUpgrade.ToString() + "} ";
			ret += "{" + "Cost" + " : " + _Cost.ToString() + "} ";
			ret += "{" + "Grade" + " : " + _Grade.ToString() + "} ";
			ret += "{" + "Rank" + " : " + _Rank.ToString() + "} ";
			return ret;
		}
	}
	public sealed class MAST : IGoogle2uDB
	{
		public enum rowIds {
			Voile
		};
		public string [] rowNames = {
			"Voile"
		};
		public System.Collections.Generic.List<MASTRow> Rows = new System.Collections.Generic.List<MASTRow>();

		public static MAST Instance
		{
			get { return NestedMAST.instance; }
		}

		private class NestedMAST
		{
			static NestedMAST() { }
			internal static readonly MAST instance = new MAST();
		}

		private MAST()
		{
			Rows.Add( new MASTRow("Voile", "Voile", "1", "2", "3", "4", "5", "6", "0", "0", "0", "0", "0", "0", "0", "", ""));
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
		public MASTRow GetRow(rowIds in_RowID)
		{
			MASTRow ret = null;
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
		public MASTRow GetRow(string in_RowString)
		{
			MASTRow ret = null;
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
