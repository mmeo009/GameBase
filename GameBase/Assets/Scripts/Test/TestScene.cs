using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
            {
            Debug.Log("key :" + key + "Count : " + count + "TotalCount : " + totalCount);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F3))
        {
            Managers.Object.Spawn<MonsterController>(new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
        }
    }
}
