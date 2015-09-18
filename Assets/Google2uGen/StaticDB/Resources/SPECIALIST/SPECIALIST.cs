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
	public class SPECIALISTRow : IGoogle2uRow
	{
		public string _Name;
		public string _Speciality;
		public int _Value;
		public string _Description;
		public int _Cost;
		public string _Type;
		public string _ShownName;
		public SPECIALISTRow(string __ID, string __Name, string __Speciality, string __Value, string __Description, string __Cost, string __Type, string __ShownName) 
		{
			_Name = __Name.Trim();
			_Speciality = __Speciality.Trim();
			{
			int res;
				if(int.TryParse(__Value, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Value = res;
				else
					Debug.LogError("Failed To Convert _Value string: "+ __Value +" to int");
			}
			_Description = __Description.Trim();
			{
			int res;
				if(int.TryParse(__Cost, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Cost = res;
				else
					Debug.LogError("Failed To Convert _Cost string: "+ __Cost +" to int");
			}
			_Type = __Type.Trim();
			_ShownName = __ShownName.Trim();
		}

		public int Length { get { return 7; } }

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
					ret = _Speciality.ToString();
					break;
				case 2:
					ret = _Value.ToString();
					break;
				case 3:
					ret = _Description.ToString();
					break;
				case 4:
					ret = _Cost.ToString();
					break;
				case 5:
					ret = _Type.ToString();
					break;
				case 6:
					ret = _ShownName.ToString();
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
				case "Speciality":
					ret = _Speciality.ToString();
					break;
				case "Value":
					ret = _Value.ToString();
					break;
				case "Description":
					ret = _Description.ToString();
					break;
				case "Cost":
					ret = _Cost.ToString();
					break;
				case "Type":
					ret = _Type.ToString();
					break;
				case "ShownName":
					ret = _ShownName.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Speciality" + " : " + _Speciality.ToString() + "} ";
			ret += "{" + "Value" + " : " + _Value.ToString() + "} ";
			ret += "{" + "Description" + " : " + _Description.ToString() + "} ";
			ret += "{" + "Cost" + " : " + _Cost.ToString() + "} ";
			ret += "{" + "Type" + " : " + _Type.ToString() + "} ";
			ret += "{" + "ShownName" + " : " + _ShownName.ToString() + "} ";
			return ret;
		}
	}
	public sealed class SPECIALIST : IGoogle2uDB
	{
		public enum rowIds {
			Specialist1, Specialist2
		};
		public string [] rowNames = {
			"Specialist1", "Specialist2"
		};
		public System.Collections.Generic.List<SPECIALISTRow> Rows = new System.Collections.Generic.List<SPECIALISTRow>();

		public static SPECIALIST Instance
		{
			get { return NestedSPECIALIST.instance; }
		}

		private class NestedSPECIALIST
		{
			static NestedSPECIALIST() { }
			internal static readonly SPECIALIST instance = new SPECIALIST();
		}

		private SPECIALIST()
		{
			Rows.Add( new SPECIALISTRow("Specialist1", "Specialist1", "Damage", "5", "A specialist", "12", "Specialist", ""));
			Rows.Add( new SPECIALISTRow("Specialist2", "Specialist2", "Damage", "5", "Another Specialist", "12", "Specialist", ""));
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
		public SPECIALISTRow GetRow(rowIds in_RowID)
		{
			SPECIALISTRow ret = null;
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
		public SPECIALISTRow GetRow(string in_RowString)
		{
			SPECIALISTRow ret = null;
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
