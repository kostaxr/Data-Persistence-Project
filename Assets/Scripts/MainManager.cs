using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class MainManager : MonoBehaviour
{
    private int m_Points;

    private bool m_GameOver = false;

    public String highName;
    public String selName;

    public int highScore;

    public static MainManager Instance;

    // Start is called before the first frame update


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    private void Update()
    {
        if (m_GameOver)
        {
            if (m_Points > highScore)
            {
                highScore = m_Points;
                highName = selName;
                SaveHighScore();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
                m_Points = 0;
                m_GameOver = false;
            }
        }
    }
    public void GameOver(int points)
    {
        m_GameOver = true;
        m_Points = points;
    }
    [System.Serializable]
    class SaveData
    {
        public String highName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highName = highName;
        data.highScore = m_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highName = data.highName;
            highScore = data.highScore;
        }
    }

}
