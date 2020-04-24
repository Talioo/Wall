using UnityEngine;

public class ScriptableObjectBase<T> : ScriptableObject where T : ScriptableObject
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<T>(Path);
            }
            return instance;
        }
    }
    private static string Path
    {
        get
        {
            return string.Format("ScriptableObjects/{0}", typeof(T).ToString());
        }
    }
}
