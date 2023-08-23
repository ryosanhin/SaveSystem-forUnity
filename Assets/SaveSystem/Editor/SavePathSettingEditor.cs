#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SavePathSetting))]
public class SavePathSettingEditor : Editor
{
	/*
	public enum PathType{
		Unselected,
		StreamingAssets,
		LocalLow,
		Custom
	}
	
	PathType pathType;
	*/
	
	public override void OnInspectorGUI()
    {
		 base.OnInspectorGUI();
		//serializedObject.Update();
		SavePathSetting sps=target as SavePathSetting;
		switch((int)sps.pathType){
			case 0:
			EditorGUILayout.LabelField("SaveFilePath->\n"+Application.streamingAssetsPath+"/"+sps.fileName,EditorStyles.wordWrappedLabel);
			break;
			case 1:
			EditorGUILayout.LabelField("SaveFilePath->\n"+Application.persistentDataPath+"/"+sps.fileName,EditorStyles.wordWrappedLabel);
			break;
		}
		
		/*
		sps.fileName=EditorGUILayout.DelayedTextField("FileName",sps.fileName);
		
		pathType=(PathType)EditorGUILayout.EnumPopup("PathType",pathType);
		
		switch((int)pathType){
			case 0:
			sps.folderPath="";
			break;
			case 1:
			sps.folderPath=Application.streamingAssetsPath;
			break;
			case 2:
			sps.folderPath=Application.persistentDataPath;
			break;
			case 3:
			sps.manualPath=EditorGUILayout.DelayedTextField("PathForSaveFolder",sps.manualPath);
			sps.folderPath=sps.manualPath;	
			break;
		}
		if((int)pathType>0){
			sps.path=sps.folderPath+"/"+sps.fileName;
			EditorGUILayout.LabelField("SaveFilePath->\n"+sps.path,EditorStyles.wordWrappedLabel);
		}
		*/
		//serializedObject.ApplyModifiedProperties();
    }
}
#endif