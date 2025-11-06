using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [Header("Referencias")]
    public PlayerMotor player; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("Configuración")]
    [Tooltip("Cuántos puntos se ganan por cada metro recorrido")]
    public float puntosPorMetro = 1000f;

    private int scoreActual;
    private int highScore;
    private Vector3 ultimaPosicion;

    void Start()
    {
        if (player != null)
            ultimaPosicion = player.transform.position;

        highScore = SaveService.LoadHighScore();
        if (highScoreText)
            highScoreText.text = $"HighScore: {highScore:N0}";

        if (scoreText)
            scoreText.text = $"Score: 0";
    }

    void Update()
    {
        if (!player) return;

        float distancia = Vector3.Distance(
            new Vector3(player.transform.position.x, 0, player.transform.position.z),
            new Vector3(ultimaPosicion.x, 0, ultimaPosicion.z)
        );

        if (distancia > 0f)
        {
            scoreActual += Mathf.RoundToInt(distancia * puntosPorMetro);
            ultimaPosicion = player.transform.position;

            if (scoreText)
                scoreText.text = $"Score: {scoreActual:N0}";

            if (scoreActual > highScore)
            {
                highScore = scoreActual;
                SaveService.SaveHighScore(highScore);

                if (highScoreText)
                    highScoreText.text = $"HighScore: {highScore:N0}";
            }
        }
    }

    public void GuardarHighScore()
    {
        SaveService.SaveHighScore(scoreActual);
    }

    public int GetScore()
    {
        return scoreActual;
    }
}
