public class PlayerHealth : Health
{
    private void Start()
    {
        OnTakeDamage += SingletonManager.Get<GameManager>().CheckPlayerHealth;
    }
}