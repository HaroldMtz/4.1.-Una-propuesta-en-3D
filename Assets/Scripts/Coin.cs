using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreSystem score = FindObjectOfType<ScoreSystem>();
            if (score != null)
                score.AddPoints(valor);

            Destroy(gameObject);
        }
    }
}
