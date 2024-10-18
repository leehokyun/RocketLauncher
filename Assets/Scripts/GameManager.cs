using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Sockets;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
    public TextMeshProUGUI CurrentScoreTxt; 
    public TextMeshProUGUI HighScoreTxt; 

    public Transform rocket;

    int currentScore = 0;
    int highScore = 0;

    float rocketHeight;



    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        SetScore();
    }

    void Start()
    {
        //CurrentScoreTxt = new TextMeshProUGUI(); 
        //HighScoreTxt = new TextMeshProUGUI();
        // ERROR: gameManager인스펙터상에서 CurrentScore.txt none처리됨. 원인은 이것 때문이었어;;
    }

    void SetScore()
    {
        rocketHeight = rocket.position.y;
        Debug.Log(rocketHeight);

        currentScore = Mathf.FloorToInt(rocketHeight) * 100 + 300;
        Debug.Log(currentScore);

        CurrentScoreTxt.text = currentScore.ToString();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            HighScoreTxt.text = highScore.ToString();
        }        
    }
}

