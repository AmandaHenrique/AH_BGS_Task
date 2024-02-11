using UnityEngine;

public class SingletonDontDestroy<T> : MonoBehaviour where T : Component
{
    protected static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            var objs = FindObjectsOfType(typeof(T)) as T[];
            if (objs.Length > 0)
                _instance = objs[0];
            if (objs.Length > 1)
            {
                for (int i = 1; i < objs.Length; i++)
                {
                    Destroy(objs[i].gameObject);
                }
            }
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}