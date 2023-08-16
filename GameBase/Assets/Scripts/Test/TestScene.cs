using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class TestScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
            {
            Debug.Log("key :" + key + "Count : " + count + "TotalCount : " + totalCount);
                if(count == totalCount)
                {
                    Managers.Game.Init();
                }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F3))
        {
            Managers.Object.Spawn<MonsterController>(new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
        }
        if (Input.GetKeyUp(KeyCode.F1))
        {
            Managers.UI.ShowToast("123124");
        }
        if(Input.GetKeyUp(KeyCode.F5))
        {
            Managers.Game.Gold += 1;
        }
        if(Input.GetKeyUp(KeyCode.F6))
        {
            Managers.Game.AddEquipment("1");
        }
        if(Input.GetKeyUp(KeyCode.F7))
        {
            Managers.Game.AddMaterialItem(ID_BRONZE_KEY, 1);
            Managers.Game.AddMaterialItem(ID_SILVER_KEY, 1);
            Managers.Game.AddMaterialItem(ID_GOLD_KEY, 1);

        }
    }
}
