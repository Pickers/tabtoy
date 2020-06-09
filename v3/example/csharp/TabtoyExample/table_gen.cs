// Generated by github.com/davyxu/tabtoy
// DO NOT EDIT!!
// Version: 3.0.0
using System;
using System.Collections.Generic;

namespace main
{ 	
	public enum ActorType
	{ 
		None = 0, //  
		Pharah = 1, // 法鸡 
		Junkrat = 2, // 狂鼠 
		Genji = 3, // 源氏 
		Mercy = 4, // 天使 
	}
		
	public partial class ExampleData : tabtoy.ITableSerializable
	{ 
		public Int32 ID = 0; 
		public string Name = string.Empty; 
		public float Rate = 0; 
		public ActorType Type = ActorType.None; 
		public List<Int32> Skill = new List<Int32>(); 
		public List<Int32> Multi = new List<Int32>(); 

		#region Deserialize Code
		public void Deserialize( tabtoy.TableReader reader )
		{
			UInt32 tag = 0;
            while ( reader.ReadTag(ref tag) )
            {
 				switch (tag)
                { 
                	case 0x20000:
                	{
						reader.ReadInt32( ref ID );
                	}
                	break;
                	case 0x80001:
                	{
						reader.ReadString( ref Name );
                	}
                	break;
                	case 0x70002:
                	{
						reader.ReadFloat( ref Rate );
                	}
                	break;
                	case 0xa0003:
                	{
						reader.ReadEnum( ref Type );
                	}
                	break;
                	case 0x660004:
                	{
						reader.ReadInt32( ref Skill );
                	}
                	break;
                	case 0x660005:
                	{
						reader.ReadInt32( ref Multi );
                	}
                	break;
                    default:
                    {
                        reader.SkipFiled(tag);                            
                    }
                    break;
				}
			}
		}
		#endregion 
	}
	
	public partial class ExampleKV : tabtoy.ITableSerializable
	{ 
		public string ServerIP = string.Empty; 
		public UInt16 ServerPort = 0; 
		public List<Int32> GroupID = new List<Int32>(); 

		#region Deserialize Code
		public void Deserialize( tabtoy.TableReader reader )
		{
			UInt32 tag = 0;
            while ( reader.ReadTag(ref tag) )
            {
 				switch (tag)
                { 
                	case 0x80000:
                	{
						reader.ReadString( ref ServerIP );
                	}
                	break;
                	case 0x40001:
                	{
						reader.ReadUInt16( ref ServerPort );
                	}
                	break;
                	case 0x660002:
                	{
						reader.ReadInt32( ref GroupID );
                	}
                	break;
                    default:
                    {
                        reader.SkipFiled(tag);                            
                    }
                    break;
				}
			}
		}
		#endregion 
	}
	

	// Combine struct
	public partial class Table
	{ 
		// table: ExampleData
		public List<ExampleData> ExampleData = new List<ExampleData>(); 
		// table: ExampleKV
		public List<ExampleKV> ExampleKV = new List<ExampleKV>(); 

		// Indices 
		public Dictionary<Int32,ExampleData> ExampleDataByID = new Dictionary<Int32,ExampleData>(); 

		
		// table: ExampleKV
		public ExampleKV GetKeyValue_ExampleKV()
		{
			return ExampleKV[0];
		}

		public void ResetData( )
		{   
			ExampleData.Clear(); 
			ExampleKV.Clear();  
			ExampleDataByID.Clear(); 	
		}
		
		public void Deserialize( tabtoy.TableReader reader )
		{	
			reader.ReadHeader();

			UInt32 tag = 0;
            while ( reader.ReadTag(ref tag) )
            {
				if (tag == 0x6f0000)
				{
                    var tabName = string.Empty;
                    reader.ReadString(ref tabName);
					switch (tabName)
					{ 
						case "ExampleData":
						{
							reader.ReadStruct(ref ExampleData);	
						}
						break;
						case "ExampleKV":
						{
							reader.ReadStruct(ref ExampleKV);	
						}
						break;
						default:
						{
							reader.SkipFiled(tag);                            
						}
						break;
					}
				}
			}
				
			foreach( var kv in ExampleData )
			{
				ExampleDataByID[kv.ID] = kv;
			}
			
		}
	}
}
