using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Net;

public class startgame : MonoBehaviour
{
    public GameObject directory, information, start, back, directoryTitle, update, notes, notesButton;
    string notesLink;
    string gameName;
    void Start(){
        gameName = update.GetComponent<update>().gameName;
        notesLink = update.GetComponent<update>().notesLink;
    }
    public void startGame()
    {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" + gameName + "\\" + gameName + ".exe";
        if(!File.Exists(path)){
            update.GetComponent<update>().download();
        }else{
            System.Diagnostics.Process.Start(path);
            Application.Quit();
        }
    }
    public void info(){
        directory.SetActive(true);
        start.SetActive(false);
        information.SetActive(false);
        notesButton.SetActive(false);
        back.SetActive(true);
        directory.GetComponent<Text>().text = (System.Environment.SpecialFolder.MyDocuments) + "\\" + gameName;
    }
    public void backPressed(){
        directory.SetActive(false);
        start.SetActive(true);
        information.SetActive(true);
        notesButton.SetActive(true);
        back.SetActive(false);
        notes.SetActive(false);
    }
    public void updateNotes(){
        Debug.Log("notes");
        start.SetActive(false);
        information.SetActive(false);
        notesButton.SetActive(false);
        back.SetActive(true);
        notes.SetActive(true);
        WebClient webClient = new WebClient();
        Stream stream = webClient.OpenRead(notesLink);
        StreamReader sRead = new StreamReader(stream);
        string newver = sRead.ReadToEnd();
        notes.GetComponent<Text>().text = newver;
    }
}
