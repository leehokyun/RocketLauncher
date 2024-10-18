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
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
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
        // ERROR: gameManager�ν����ͻ󿡼� CurrentScore.txt noneó����. ������ �̰� �����̾���;;
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

