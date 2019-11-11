using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager dataManager;
    public float score;
    public float initialScore;
    private void Awake()
    {
        if (DataManager.dataManager == null)
        {
            DataManager.dataManager = this;
        }
        else
        {
            if (this != DataManager.dataManager)
            {

                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(DataManager.dataManager.gameObject);
    }

    public void ReloadLevel()
    {
        score = initialScore;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);//Indexe göre çalıstırdık
        UIController.uiController.SetScoreText(initialScore.ToString());
    }
    public void LoadNextLevel()
    {
        initialScore = score;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);//Indexe göre çalıstırdık
    }
    //hazırlık
    //load edeceğimiz datanın serilizatonu/diserilazilationu
    //file stream close
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/gameSave.gmsv", FileMode.Create);//hazırlık aşaması

        bf.Serialize(stream, initialScore);
        bf.Serialize(stream, SceneManager.GetActiveScene().buildIndex);

        stream.Close();

    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSave.gmsv"))//Dosya var ise
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/gameSave.gmsv", FileMode.Open);

            initialScore= (float) bf.Deserialize(stream);
            int savedSceneIndex = (int)bf.Deserialize(stream);

            stream.Close();
            SceneManager.LoadScene(savedSceneIndex);
            UIController.uiController.SetScoreText(initialScore.ToString());
            score = initialScore;
          

        }

    }
}
