using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class FileManager
{
	string path;
	string folderPath;
	string fileName;
	
	public FileManager(string _folderPath,string _fileName){
		fileName=_fileName;
		folderPath=_folderPath;
		path=folderPath+"/"+fileName;
	}
	
	/*バイト配列の書き込み*/
	public void WriteByteData(byte[] data){
		using(FileStream fileStream=new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write)){
			fileStream.Write(data,0,data.Length);//dataをdataの長さだけ書き込み
		}
	}
	
	/*バイト配列の読み込み*/
	public byte[] ReadByteData(){
		try{
			using(FileStream fileStream=new FileStream(path,FileMode.Open,FileAccess.Read)){
				byte[] data=new byte[fileStream.Length];
				fileStream.Read(data,0,data.Length);//fileStreamで開いたファイルの中身を入れる
				return data;
			}
		}catch(FileNotFoundException ex){
			byte[] data=new byte[0];
			return data;
		}
	}
	
	/*普通の文の書き込み*/
	public void WriteData(string characters){
		using(FileStream fileStream=new FileStream(path,FileMode.Create,FileAccess.Write)){
			using(StreamWriter streamWriter=new StreamWriter(fileStream,Encoding.GetEncoding("Shift-JIS"))){
				streamWriter.Write(characters);
			}
		}
	}
	
	/*普通の文の読み込み*/
	public string ReadData(){
		try{
			using(FileStream fileStream=new FileStream(path,FileMode.Open,FileAccess.Read)){
				using(StreamReader streamReader=new StreamReader(fileStream,Encoding.GetEncoding("Shift-JIS"))){
					return streamReader.ReadToEnd();
				}
			}
		}catch(FileNotFoundException ex){
			return "Error";
		}
	}
	
	/*パス変更*/
	public void SetPath(string _path){
		path=_path;
	}
	
	/*対象ファイルを変更*/
	public void SetFileName(string _fileName){
		fileName=_fileName;
		path=folderPath+"/"+fileName;
	}
	
	/*フォルダーまでのパス変更*/
	public void SetFolderPath(string _folderPath){
		folderPath=_folderPath;
		path=folderPath+"/"+fileName;
	}
	
	/*パス確認*/
	public string GetPath(){
		return path;
	}
	
	/*フォルダーまでのパス確認*/
	public string GetFolderPath(){
		return folderPath;
	}
	
	/*対象ファイルの名前*/
	public string GetFileName(){
		return fileName;
	}
	
	/*ファイルの存在確認*/
	public bool IsExist(){
		return File.Exists(path);
	}
}
