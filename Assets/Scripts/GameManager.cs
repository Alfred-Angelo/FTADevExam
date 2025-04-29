using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        SingletonManager.Register(this);
    }

    public void CheckPlayerHealth(float value)
    {
        
    }
}