using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("Configuración de tramos")]
    public GameObject[] plataformas;
    public float longitudPlataforma = 30f;
    public int tramosIniciales = 5;
    public Transform player;

    [Header("Dificultad progresiva")]
    public float distanciaPorNivel = 100f;
    public float incrementoVelocidad = 0.5f;

    private ScoreSystem scoreSystem;
    private float zSpawn = 0f;
    private List<GameObject> plataformasActivas = new List<GameObject>();
    private PlayerMotor motor;
    private int nivelActual = 1;

    void Start()
    {
        scoreSystem = FindAnyObjectByType<ScoreSystem>();
        motor = player.GetComponent<PlayerMotor>();

        for (int i = 0; i < tramosIniciales; i++)
            GenerarPlataforma();
    }

    void Update()
    {
        if (player.position.z - 20f > (zSpawn - tramosIniciales * longitudPlataforma))
            GenerarPlataforma();

        if (player.position.z >= nivelActual * distanciaPorNivel)
        {
            motor.moveSpeed += incrementoVelocidad;
            nivelActual++;
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (player.position.z >= 200f)
            {
                SceneManager.LoadScene("Level2");
                return;
            }
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (scoreSystem != null && scoreSystem.GetScore() >= 50)
            {
                SceneManager.LoadScene("MainMenu");
                return;
            }
        }

        if (player.position.y < -5f)
            Reiniciar();
    }

    void GenerarPlataforma()
    {
        GameObject prefab = plataformas[Random.Range(0, plataformas.Length)];
        GameObject nueva = Instantiate(prefab, new Vector3(0, 0, zSpawn), Quaternion.identity);
        plataformasActivas.Add(nueva);
        zSpawn += longitudPlataforma;

        if (plataformasActivas.Count > tramosIniciales)
        {
            Destroy(plataformasActivas[0]);
            plataformasActivas.RemoveAt(0);
        }
    }

    void Reiniciar()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}
