using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObject/SavePathSetting")]
public class SavePathSetting : ScriptableObject
{
	public enum PathType{
		StreamingAssets,
		LocalLow
	}
	public PathType pathType;
	public string fileName; //ファイルの名前
	[HideInInspector] public string folderPath; //フォルダまでのパス
	[HideInInspector] public string path; //パス本体

	void OnEnable(){
		switch((int)pathType){
			case 0:
			folderPath=Application.streamingAssetsPath;
			break;
			case 1:
			folderPath=Application.persistentDataPath;
			break;
		}
		path=folderPath+"/"+fileName;
	}
}
