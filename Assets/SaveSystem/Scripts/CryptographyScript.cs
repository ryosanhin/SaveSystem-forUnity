using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public class CryptographyScript
{
	RijndaelManaged coding;
	Rfc2898DeriveBytes randomBytes;
	
	string key="keykeykeykeykeykeykeykeykey"; //キー
	string iv="iviviviviviviviviviviviv"; //初期化ベクトル
	string salt="SaltNeedsEightBytesAtLeast"; //ソルト
	
	public CryptographyScript(){
	}
	
	public CryptographyScript(string _key,string _iv,string _salt){
		key=_key;
		iv=_iv;
		salt=_salt;
	}
	
	public byte[] Encode(string characters){
		byte[] byteMozi=Encoding.UTF8.GetBytes(characters);//文をバイト配列化
		byte[] changedBytes; //暗号化したものを格納
		Setting();
		
		using(ICryptoTransform encryptor=coding.CreateEncryptor()){
			changedBytes=encryptor.TransformFinalBlock(byteMozi,0,byteMozi.Length);//暗号化
		}
		
		return changedBytes;
	}
	
	public string Decode(byte[] bytes){
		byte[] changedData;
		string data;
		Setting();
		
		try{	
			using(ICryptoTransform decryptor=coding.CreateDecryptor()){
				changedData=decryptor.TransformFinalBlock(bytes,0,bytes.Length);//復号
			}
			data=Encoding.GetEncoding("UTF-8").GetString(changedData);//バイト配列から文字へ
		}catch(CryptographicException ex){
			return "File cannot decoded:"+ex.Message;
		}
		
		return data;
	}
	
	void Setting(){
		coding=new RijndaelManaged();
		coding.KeySize=128;
		coding.BlockSize=128;
		coding.Mode=CipherMode.CBC;
		coding.Padding=PaddingMode.PKCS7;
		
		randomBytes=new Rfc2898DeriveBytes(key,Encoding.UTF8.GetBytes(salt),1000); //キー、ソルト、反復回数
		coding.Key=randomBytes.GetBytes(coding.KeySize/8);
		
		randomBytes=new Rfc2898DeriveBytes(iv,Encoding.UTF8.GetBytes(salt),1000); //初期化ベクトル、ソルト、反復回数
		coding.IV=randomBytes.GetBytes(coding.BlockSize/8);
	}
}
