using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using UnityEngine.UI;

public class update : MonoBehaviour
{
    string ver, latestver;
    public Text start;
    public Sprite logo;
    Image logoImage;
    public Button button;
    public String downloadLink;
    public String currentVersionLink;
    public String notesLink;
    public String gameName;
    bool complete, varsDone;
    void OnEnable()
    {
        if(gameName == ""){
            Debug.Log("please set your game's name in the EventSystem object to prevent it from deleting random files!!");
            Debug.Break();
        }else{
            logoImage = GameObject.Find("logo").GetComponent<Image>();
            logoImage.sprite = logo;
            checkversion();
        }
    }
    public void download()
    {
        button.enabled = false;
        WebClient webClient = new WebClient();
        if(ver != latestver){
            Stream stream = webClient.OpenRead(downloadLink);
            StreamReader sRead = new StreamReader(stream);
            string newver = sRead.ReadToEnd();
            Uri uri = new Uri(newver);
            string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" + gameName;
            if(Directory.Exists(dir)){
                Directory.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" + gameName, true);
            }
            webClient.DownloadFileAsync(uri, System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\newver.zip");
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, data) => {
                if(data.ProgressPercentage == 100){
                    if(!complete){
                        complete = true;
                        Debug.Log(newver);
                        start.text = "updating..." + " (" + data.ProgressPercentage + "%)";
                        System.IO.Compression.ZipFile.ExtractToDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\newver.zip", System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" + gameName);
                        button.enabled = true;
                        start.text = "start game";
                    }
                }else{
                    start.text = "updating..." + " (" + data.ProgressPercentage + "%)";
                }
            });
        }else{
            enablePlay();
        }
    }
    void checkversion(){
        start.text = "checking for updates...";
        WebClient webClient = new WebClient();
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" + gameName + "\\" + gameName + "_data" + "\\" + "ver.txt";
        if(Directory.Exists(path.Replace("ver.txt", ""))){
            StreamReader reader = new StreamReader(path);
            ver = reader.ReadToEnd().ToString();
            reader.Close();
        }else{
            ver = "0";
        }
        Stream stream = webClient.OpenRead(currentVersionLink);
        StreamReader reader2 = new StreamReader(stream);
        latestver = reader2.ReadToEnd().ToString();
        reader2.Close();
        download();
    }
    void enablePlay(){
        button.enabled = true;
        start.text = "start game";
    }
}