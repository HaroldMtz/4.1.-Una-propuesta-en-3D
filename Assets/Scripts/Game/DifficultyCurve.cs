using UnityEngine;

public class DifficultyCurve : MonoBehaviour
{
    [Header("Referencias")]
    public PlayerMotor player; 
    public ScoreSystem scoreSystem;

    [Header("Curva de dificultad")]
    public float minMultiplier = 1f;
    public float maxMultiplier = 2.5f;
    public float tiempoParaMax = 120f; 

    private float tiempoTranscurrido;

    void Update()
    {
        if (!player) return;

        tiempoTranscurrido += Time.deltaTime;
        float progreso = Mathf.Clamp01(tiempoTranscurrido / tiempoParaMax);
        float dificultad = Mathf.Lerp(minMultiplier, maxMultiplier, progreso);

        player.moveSpeed = dificultad * 6f; 
    }
}
