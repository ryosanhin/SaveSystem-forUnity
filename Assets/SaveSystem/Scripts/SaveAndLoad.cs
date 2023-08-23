using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
	#region singleton
	   private static SaveAndLoad _instance;

	   public static SaveAndLoad instance{
			get{return _instance;}
		}
		
	   private void Awake()
	   {
		   if (_instance!=null && _instance!=this){
			   Destroy(this.gameObject);
		   }else{
			   _instance=this;
				DontDestroyOnLoad(gameObject);
		   }
	   }
	#endregion
	
	[SerializeField] SavePathSetting savePathSetting;
	[SerializeField] CryptographySetting cryptographySetting;
	
	public void Save(SaveData data){
		SaveSystem.Save(data,savePathSetting,cryptographySetting);
	}
	
	public SaveData Load(){
		return SaveSystem.Load(savePathSetting,cryptographySetting);
	}
}
