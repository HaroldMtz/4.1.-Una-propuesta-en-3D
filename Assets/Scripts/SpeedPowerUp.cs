using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SuperSpeedManager s = other.GetComponent<SuperSpeedManager>();
            if (s != null)
            {
                s.ActivateBoost();
            }

            Destroy(gameObject); // eliminar power-up
        }
    }
}
