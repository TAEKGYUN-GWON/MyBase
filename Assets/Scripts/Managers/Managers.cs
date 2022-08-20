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
                Init();
            }

            return s_instance;
        } 
    }

    #region Contents
    GameManagerEX _game = GameManagerEX.Instance;
    public static GameManagerEX Game { get { return Instance._game; } }
    #endregion

    #region Core
    DataManager _data = DataManager.Instance;
    InputManager _input = InputManager.Instance;
    KeyManager _key = KeyManager.Instance;
    PoolManager _pool = PoolManager.Instance;
    ResourceManager _resource = ResourceManager.Instance;
    SceneManagerEx _scene = SceneManagerEx.Instance;
    SoundManager _sound = SoundManager.Instance;
    UIManager _ui = UIManager.Instance;
    public static DataManager Data { get {return Instance._data; } }
    public static InputManager Input { get {return Instance._input; } }
    public static KeyManager Key { get {return Instance._key; } }
    public static PoolManager Pool { get {return Instance._pool; } }
    public static ResourceManager Resource { get {return Instance._resource; } }
    public static SceneManagerEx Scene { get {return Instance._scene; } }
    public static SoundManager Sound { get {return Instance._sound; } }
    public static UIManager UI { get {return Instance._ui; } }

    #endregion

    void Start()
    {
    }

    void Update()
    {
        Input.OnUpdate();
    }

    static void Init()
    {
        s_instance._data.Init();
        s_instance._sound.Init();
        s_instance._pool.Init();
    }

    public static void Clear()
    {
        Sound.Clear();
        Input.Clear();
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
    }
}
