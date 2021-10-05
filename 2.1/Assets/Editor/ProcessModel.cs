using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ProcessModel : AssetPostprocessor
{
    public Rocket rocket;
    void OnPostprocessModel(GameObject input)
    {
        //public Rocket rocket;
        if (input.name != "Enemy2b")
            return;
        ModelImporter importer = assetImporter as ModelImporter;

        GameObject tar = AssetDatabase.LoadAssetAtPath<GameObject>(importer.assetPath);
        GameObject prefab = PrefabUtility.CreatePrefab("assets/Prefabs/Enemy2.prefab", tar);
        prefab.tag = "Enemy";

        foreach(Transform obj in prefab.GetComponentsInChildren<Transform>())
        {
            if(obj.name=="col")
            {
                MeshRenderer r = obj.GetComponent<MeshRenderer>();
                r.enabled = false;

                if(obj.gameObject.GetComponent<MeshCollider>()==null)
                {
                    obj.gameObject.AddComponent<MeshCollider>();
                }
                obj.tag = "Enemy";

            }
        }

        Rigidbody rigid = prefab.AddComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;

        prefab.AddComponent<AudioSource>();//添加声音组件

        GameObject fx = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/FX/Explosion.prefab");

        SuperEnemy enemy = prefab.AddComponent<SuperEnemy>();
        enemy.m_life = 50;
        enemy.m_point = 50;
        enemy.m_rocket = rocket.transform;
        enemy.m_explosionFx = fx.transform;


    }
	// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
