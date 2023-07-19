using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : BaseController
{

    public float Timer = 2.0f;
    void Update()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0)
        {
            Timer = 2.0f;
            Managers.Object.Despawn(this);
        }
    }
}
