using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRender : MonoBehaviour {

    public Enemy m_enemy;

	// Use this for initialization
	void Start () {
        m_enemy = this.GetComponentInParent<Enemy>();//由父物体获得Enemy脚本
		
	}

    private void OnBecameVisible()
    {
        m_enemy.m_isActiv = true;//更新脚本状态
        m_enemy.m_renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
 //   void Update () {
		
	//}
}
