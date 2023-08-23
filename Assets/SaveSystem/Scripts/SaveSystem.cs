using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
	public static void Save(SaveData newData,SavePathSetting sps,CryptographySetting cs){
		string jsonData=JsonUtility.ToJson(newData);
		CryptographyScript aes=new CryptographyScript(cs.key,cs.iv,cs.salt);
		FileManager fm=new FileManager(sps.folderPath,sps.fileName);
		fm.WriteData(Base64Manager.BytesToBase64Url(aes.Encode(jsonData)));
	}
	
	public static SaveData Load(SavePathSetting sps,CryptographySetting cs){	
		FileManager fm=new FileManager(sps.folderPath,sps.fileName);
		CryptographyScript aes=new CryptographyScript(cs.key,cs.iv,cs.salt);
		string jsonData=aes.Decode(Base64Manager.Base64UrlToBytes(fm.ReadData()));
		if(jsonData!="Error"){
			SaveData data=JsonUtility.FromJson<SaveData>(jsonData);
			return data;
		}
		return null;
	}
}
