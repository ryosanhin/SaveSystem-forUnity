using System;

[Serializable]
public class SaveData
{
	public string s;
	
	public SaveData(string _s){
		this.s=_s;
	}
	
	public SaveData(SaveData data){
		this.s=data.s;
	}
}