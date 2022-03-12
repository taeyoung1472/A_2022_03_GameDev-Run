using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int tempBest;
    public string overString;
    public GameObject congachuRationObject;
    public bool isOver;
    private bool isExit;
    public int score;
    public int bestScore;
    public TextMesh ScoreText;
    public GameObject overPannel;
    public Text text;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private User user;
    [SerializeField] private ComboSystem comboSystem;
    [SerializeField] private AdManager adManager;
    [SerializeField] private PoolingManager poolingManager;
    [SerializeField] private UIManager uiManager;
    public GameObject GameOverPanel { get { return gameOverPanel; } }
    public ComboSystem ComboSystem { get { return comboSystem; } }
    public PoolingManager PoolingManager { get { return poolingManager; } }
    public UIManager UIManager { get { return uiManager; } }
    public static GameManager Instance;
    public User UserInfo
    {
        get
        {
            return user;
        }
    }
    private void Awake()
    {
        Instance = this;
        LoadUser();
        SaveUser();
    }
    private void Start()
    {
        bestScore = user.bestScore;
        tempBest = bestScore;
        adManager.ToggleBannerAd(true);
        uiManager.Set();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }
    public void GoGame()
    {
        SaveUser();
        adManager.ToggleBannerAd(true);
        SceneManager.LoadScene(1);
    }
    public void GoMain()
    {
        SaveUser();
        adManager.ToggleBannerAd(true);
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        if (!isOver)
        {
            text.gameObject.SetActive(true);
            gameOverPanel.SetActive(false);
            overPannel.SetActive(true);
            if (tempBest < bestScore)
            {
                CongachuRation();
            }
            isOver = true;
        }
    }
    public void CongachuRation()
    {
        congachuRationObject.SetActive(true);
    }
    public void AddScroe(int _score)
    {
        score += _score;
        ScoreText.text = string.Format("Score : {0}", score);
        if (bestScore < score)
        {
            user.bestScore = score;
            bestScore = score;
        }
    }
    public void OnApplicationQuit()
    {
        SaveUser();
    }
    public void SetZingle(bool isZingle)
    {
        user.isZingle = isZingle;
        SaveUser();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GameStart()
    {
        uiManager.GameStart();
        if (!PlatForm.isStart)
        {
            PlatForm.isStart = true;
        }
    }
    public void FrontAd()
    {
        int rand = Random.Range(0, 100);
        if (rand <= 25)
        {
            try
            {
                adManager.ShowFrontAd();
            }
            catch
            {
                print("Network Error");
            }
        }
    }
    [ContextMenu("저장하기")]
    public void SaveUser()
    {
        print("저장");
        string jsonData = JsonUtility.ToJson(user, true);
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("불러오기")]
    public void LoadUser()
    {
        print("불러오기");
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        user = JsonUtility.FromJson<User>(jsonData);
    }
}