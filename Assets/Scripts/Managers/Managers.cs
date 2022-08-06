using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance = null;
    public static Managers Instance 
    { 
        get 
        {
            if (s_instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject("@Managers");
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();
            }

            return s_instance;
        } 
    }

    InputManager _input = InputManager.Instance;
    KeyManager _key = KeyManager.Instance;
    ResourceManager _resource = ResourceManager.Instance;
    SceneManagerEx _scene = SceneManagerEx.Instance;
    UIManager _ui = UIManager.Instance;
    public static InputManager Input { get {return Instance._input; } }
    public static KeyManager Key { get {return Instance._key; } }
    public static ResourceManager Resource { get {return Instance._resource; } }
    public static SceneManagerEx Scene { get {return Instance._scene; } }
    public static UIManager UI { get {return Instance._ui; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        Input.OnUpdate();
    }

    static void Init()
    {
    }
}
