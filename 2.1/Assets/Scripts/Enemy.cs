using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Enemy")]

public class Enemy : MonoBehaviour {

    public float m_speed = 1;//速度
    public float m_life = 10;//生命
    public float m_rotSpeed = 30;//旋转速度
    private Transform m_transform;
    //public float m_life = 10;
    internal Renderer m_renderer;//模型渲染组件
    internal bool m_isActiv = false;//是否激活
    public int m_point = 10;
    public AudioClip m_shootClip;
    protected AudioSource m_audio;//声音源
    public Transform m_explosionFx;//爆炸特效


	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        m_renderer = this.GetComponent<Renderer>();
        m_audio = this.GetComponent<AudioSource>();
		
	}

    private void OnBecameVisible()
    {
        m_isActiv = true;
    }

    // Update is called once per frame
    void Update () {
        UpdateMove();


        if(m_isActiv&&!this.m_renderer.isVisible)//如果移动到屏幕外
        {
            Destroy(this.gameObject);//自我销毁
        }


	}


    protected virtual void UpdateMove()
    {
        //左右移动
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        //前进
        m_transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="PlayerRocket")
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if(rocket!=null)
            {
                m_life -= rocket.m_power;//减少生命
                if(m_life<=0)
                {
                    GameManager.Instance.AddScore(m_point);//代码更新UI分数
                    Instantiate(m_explosionFx, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);//自我销毁
                }
            }
        }
        else if(other.tag=="Player")//如果撞到主角
        {
            m_life = 0;
            Destroy(this.gameObject);//自我销毁
        }
        //List<int> a=new List<int>()


        
        
    }

}
