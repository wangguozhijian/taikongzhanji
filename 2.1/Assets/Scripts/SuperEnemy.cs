using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : Enemy {

    public Transform m_rocket;//子弹Prefab
    protected float m_fireTimer = 2;//射击计时器
    protected Transform m_player;

	// Use this for initialization
	//void Start () {
		
	
	
	// Update is called once per frame
	//void Update () {
		
	

    protected override void UpdateMove()
    {
        m_fireTimer -= Time.deltaTime;
        if(m_fireTimer<=0)
        {
            m_fireTimer = 2;
            if(m_player!=null)
            {
                Vector3 relativePos = m_player.position - transform.position;
                Instantiate(m_rocket, transform.position, Quaternion.LookRotation(relativePos));
            }
            else
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Player");//查找主角
                if(obj!=null)
                {
                    m_player = obj.transform;
                }
            }

            
        }
        //前进（负z方向）
        transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));

    }

}
