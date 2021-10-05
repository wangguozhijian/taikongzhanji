using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[AddComponentMenu("MyGame/GameManager")]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//静态实例

    public Transform m_canvas_main;
    public Transform m_canvas_gameover;
    public Text m_text_score;//得分UI文字
    public Text m_text_life;//生命UI文字
    public Text m_text_best;//最高分UI文字

    protected int m_score = 0;
    public static int m_hiscore = 0;//最高分数值
    protected Player m_player;

    public AudioClip m_musicClip;//背景音乐
    protected AudioSource m_Audio;//声音源


    // Use this for initialization
    void Start ()
    {
        Instance = this;
        m_Audio = this.gameObject.AddComponent<AudioSource>();//使用代码添加声音源组件
        m_Audio.clip = m_musicClip;
        m_Audio.loop = true;
        m_Audio.Play();//开始播放音乐
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();//查找主角
        m_text_best = m_canvas_main.transform.Find("Text_best").GetComponent<Text>();
        m_text_score = m_canvas_main.transform.Find("Text_score").GetComponent<Text>();
        
        m_text_life = m_canvas_main.transform.Find("Text_life").GetComponent<Text>();
        m_text_score.text = string.Format("分数 {0}", m_score);//初始化UI分数
        m_text_best.text = string.Format("最高分 {0}", m_hiscore);
        m_text_life.text = string.Format("生命 {0}", m_player.m_life);

        //获取重新开始按钮
        var restart_button = m_canvas_gameover.transform.Find("Button").GetComponent<Button>();
        restart_button.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重新开始当前关卡
        });
        m_canvas_gameover.gameObject.SetActive(false);//默认隐藏游戏失败UI


		
	}

    public void AddScore(int point)
    {
        m_score += point;
        if(m_hiscore<=m_score)
        {
            m_hiscore = m_score;
        }
        m_text_score.text = string.Format("分数 {0}", m_score);
        m_text_best.text = string.Format("最高分 {0}", m_hiscore);
    }

    public void ChangeLife(int life)
    {
        m_text_life.text = string.Format("生命 {0}",life);//
        if(life<=0)
        {
            m_canvas_gameover.gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
