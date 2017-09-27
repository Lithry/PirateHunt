using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {
    public GameObject prefab;
    public int count = 10;

    private List<PoolObject> objects = new List<PoolObject>();
	// Use this for initialization
	void Awake () {
        for (int i = 0; i < count; i++)
        {
            PoolObject po = Create();
            po.gameObject.SetActive(false);
            objects.Add(po);
        }
	}
	
	// Update is called once per frame
	public PoolObject Create () {
        GameObject go = Instantiate(prefab);
        PoolObject po = go.AddComponent<PoolObject>();
        po.SetPool(this);
        return po;
    }

    public PoolObject Spawn()
    {
        PoolObject po = null;

        if (objects.Count > 0)
        {
            po = objects[0];
            po.gameObject.SetActive(true);
            objects.RemoveAt(0);
        }
        else
            po = Create();

        return po;
    }

    public void Recycl(PoolObject po)
    {
        po.gameObject.SetActive(false);
        objects.Add(po);
    }
}
