using UnityEngine;

public abstract class Singleton : MonoBehaviour
{
    public static Singleton instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

}