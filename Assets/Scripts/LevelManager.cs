using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("Configuración de tramos")]
    public GameObject[] plataformas;      // prefabs de plataformas posibles
    public float longitudPlataforma = 30f; // largo de cada tramo
    public int tramosIniciales = 5;
    public Transform player;

    [Header("Dificultad progresiva")]
    public float distanciaPorNivel = 100f;  // cada 100 unidades aumenta velocidad
    public float incrementoVelocidad = 0.5f;

    private float zSpawn = 0f;
    private List<GameObject> plataformasActivas = new List<GameObject>();
    private PlayerMotor motor;
    private int nivelActual = 1;

    void Start()
    {
        motor = player.GetComponent<PlayerMotor>();
        for (int i = 0; i < tramosIniciales; i++)
            GenerarPlataforma();
    }

    void Update()
    {
        // Cuando el jugador pasa cierto tramo, genera una nueva plataforma
        if (player.position.z - 20f > (zSpawn - tramosIniciales * longitudPlataforma))
            GenerarPlataforma();

        // Aumentar dificultad con la distancia
        if (player.position.z >= nivelActual * distanciaPorNivel)
        {
            motor.moveSpeed += incrementoVelocidad;
            nivelActual++;
        }

        // Reiniciar si cae del mapa
        if (player.position.y < -5f)
            Reiniciar();
    }

    void GenerarPlataforma()
    {
        GameObject prefab = plataformas[Random.Range(0, plataformas.Length)];
        GameObject nueva = Instantiate(prefab, new Vector3(0, 0, zSpawn), Quaternion.identity);
        plataformasActivas.Add(nueva);
        zSpawn += longitudPlataforma;

        // Limitar número de tramos activos
        if (plataformasActivas.Count > tramosIniciales)
        {
            Destroy(plataformasActivas[0]);
            plataformasActivas.RemoveAt(0);
        }
    }

    void Reiniciar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
