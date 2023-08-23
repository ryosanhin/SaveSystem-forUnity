using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObject/CryptographySetting")]
public class CryptographySetting : ScriptableObject
{
	[Header("キー")]
	public string key; //キー
	[Header("初期化ベクトル")]
	public string iv; //初期化ベクトル
	[Header("ソルト 最低でも8バイト必要")]
	public string salt; //ソルト
}
