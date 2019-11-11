using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIController : MonoBehaviour
{
    public static UIController uiController;
    public Text scoreText;

    public Button saveButton, loadButton;
    // Start is called before the first frame update
   
    void Start()
    {
        scoreText.text = "Score: " + DataManager.dataManager.score;
        saveButton.onClick.AddListener(SaveGame);
        loadButton.onClick.AddListener(LoadGame);
    }
    private void Awake()
    {
        if (UIController.uiController == null)
        {
            UIController.uiController = this;
        }
        else
        {
            if (this != UIController.uiController)
            {

                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(UIController.uiController.gameObject);
    }
    // Update is called once per frame
    //update'yi sildik çünkü kasmalar olmasını işstemedik.
    //update(){scoreText.text = "Score: " + player.GetComponent<PlayerMoment>().score;}


    public void SetScoreText(string aScoreString)//isimlerndirme olarak a-verildi
    {
        scoreText.text = "Score: " + aScoreString;
    }

    private void SaveGame()
    {
        DataManager.dataManager.Save();
    }

    private void LoadGame()
    {
        DataManager.dataManager.Load();
    }
}
