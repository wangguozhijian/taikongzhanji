using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float m_speed = 10;
    private Transform m_transform;
    public Transform m_rocket;
    private float m_rocketTimer;
    public int m_life = 3;
    public AudioClip m_shootClip;//声音文件
    protected AudioSource m_audio;//声音源
    public Transform m_explosionFX;//爆炸特效
    protected Vector3 m_targetPos;//目标位置
    public LayerMask m_inputMask;


    // Use this for initialization(初始化）
    void Start()
    {
        m_transform = this.transform;
        m_audio = this.GetComponent<AudioSource>();
        m_targetPos = this.m_transform.position;

    }



    // Update is called once per frame（每帧执行）
    void Update()
    {
        //纵向移动距离
        float movev = 0;
        //水平移动距离
        float moveh = 0;


        //按上z方向递增
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movev += m_speed * Time.deltaTime;
        }
        //按下z方向递减
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movev -= m_speed * Time.deltaTime;
        }
        //按左x方向递减
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveh -= m_speed * Time.deltaTime;
        }
        //按右键X方向递增
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveh += m_speed * Time.deltaTime;
        }
        //移动
        this.m_transform.Translate(new Vector3(moveh, 0, movev));




        m_rocketTimer -= Time.deltaTime;
        if (m_rocketTimer <= 0)
        {
            m_rocketTimer = 0.1f;
            //按下空格或左键发射子弹
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                //Instantiate(m_rocket, m_transform.position, m_transform.rotation);
                var p = PathologicalGames.PoolManager.Pools["mypool"];
                p.Spawn("Rocket", m_transform.position, m_transform.rotation, null);

                m_audio.PlayOneShot(m_shootClip);
            }
        }

        //MoveTo();





    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerRocket")
        {
            m_life -= 1;//减少生命
            GameManager.Instance.ChangeLife(m_life);
            if (m_life <= 0)
            {
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);//自我销毁
            }
        }
    }

    void MoveTo()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 ms = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(ms);//将屏幕位置转为射线
            RaycastHit hitinfo;
            bool iscast = Physics.Raycast(ray, out hitinfo, 1000, m_inputMask);
            if (iscast)
            {
                m_targetPos = hitinfo.point;
            }
        }

        Vector3 pos = Vector3.MoveTowards(m_transform.position, m_targetPos, m_speed * Time.deltaTime);
        this.m_transform.position = pos;
    }


}
