using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    public static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }

    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    ObjectManager _object = new ObjectManager();
    UIManager _ui = new UIManager();
    GameManager _game = new GameManager();
    public static PoolManager pool { get { return Instance?._pool; } }
    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static ObjectManager Object { get { return Instance?._object; } }
    public static UIManager UI { get { return Instance?._ui; } }
    public static GameManager Game { get {  return Instance?._game; } }
}

