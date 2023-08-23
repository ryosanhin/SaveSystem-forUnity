using System;
using System.Text;

public class Base64Manager
{	
	public static string BytesToBase64(byte[] bytes){
		return Convert.ToBase64String(bytes);
	}
	
	public static byte[] Base64ToBytes(string characters){
		return Convert.FromBase64String(characters);
	}
	
	/*
	base64URLの場合はこうなる
	
	'+'->'-'
	'/'->'_'
	'='->消去
	*/
	
	public static string BytesToBase64Url(byte[] bytes){
		StringBuilder sb=new StringBuilder(Convert.ToBase64String(bytes));
		
		sb.Replace('+','-');
		sb.Replace('/','_');
		sb.Replace("=","");
		
		return sb.ToString();
	}
	
	public static byte[] Base64UrlToBytes(string characters){
		StringBuilder sb=new StringBuilder(characters);
		
		sb.Replace('-','+');
		sb.Replace('_','/');
		
		for(int i=characters.Length%4;i<4;i++){
			if(i==0){
				break;
			}
			
			sb.Append("=");
		}
		
		return Convert.FromBase64String(sb.ToString());
	}
	
}