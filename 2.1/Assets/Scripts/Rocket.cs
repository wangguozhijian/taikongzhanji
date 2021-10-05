using PathologicalGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Rocket")]
public class Rocket : MonoBehaviour
{

    public float m_speed = 10;//子弹飞行速度
    public float m_power = 1.0f;//威力
    public Transform m_transform;
    //public SpawnPool s;

    void OnBecameInvisible()
    {
        if (this.enabled)//判断是否激活
        {
            //Destroy(this.gameObject);//离开屏幕后销毁
           Despawn();
        }
    }

    void Despawn()
    {
        if(!gameObject.activeSelf)
        {
            return;
        }
        var p = PoolManager.Pools["mypool"];

        if (p.IsSpawned(m_transform))
            p.Despawn(m_transform);
        else
            Destroy(gameObject);
    }


    // Use this for initialization
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //向Z方向移动
        m_transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
            return;
        Destroy(this.gameObject);
    }
}
