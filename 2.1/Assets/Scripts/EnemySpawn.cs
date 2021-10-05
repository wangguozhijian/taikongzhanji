using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/EnemySpawn")]
public class EnemySpawn : MonoBehaviour
{
    public Transform m_enemyPrefab;//敌人的prefab
    // Use this for initialization
    void Start () 
    {
        StartCoroutine(SpawnEnemy());//执行协程函数
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "item.png", true);
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));//随机等待5-15秒
            Instantiate(m_enemyPrefab, transform.position, Quaternion.identity);//生成敌人实例
        }

    }
       
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
