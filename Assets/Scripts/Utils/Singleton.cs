using UnityEngine;
public class Singleton<T> where T : Singleton<T>, new()
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

    protected void Init()
    {
    }

    public static bool HasInstance()
    {
        return _instance != null ? true : false;
    }

    public static void DestroyInstance()
    {
        if (Instance == null)
        {
            return;
        }
    }

    public virtual void OnDestroy()
    {
        DestroyInstance();
        _instance = null;
    }
}
