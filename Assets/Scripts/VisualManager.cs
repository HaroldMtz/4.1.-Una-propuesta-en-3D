using UnityEngine;

public class VisualManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Light mainLight;
    [SerializeField] private Renderer playerRenderer;

    [Header("Colores de Fondo")]
    [SerializeField] private Color[] backgroundColors;

    [Header("Colores del Personaje")]
    [SerializeField] private Color[] playerColors;

    [Header("Iluminación")]
    [SerializeField] private float lightIntensity = 1.2f;

    private void Awake()
    {
        if (!mainCamera)
            mainCamera = Camera.main;
    }

    private void Start()
    {
        ApplyRandomTheme();
    }

    public void ApplyRandomTheme()
    {
        if (backgroundColors == null || backgroundColors.Length == 0)
            return;

        int index = Random.Range(0, backgroundColors.Length);

        if (mainCamera)
            mainCamera.backgroundColor = backgroundColors[index];

        if (playerRenderer && playerColors != null && playerColors.Length > 0)
        {
            int indexPlayer = index % playerColors.Length;
            playerRenderer.material.color = playerColors[indexPlayer];
        }

        if (mainLight)
        {
            mainLight.intensity = lightIntensity;   
            mainLight.color = backgroundColors[index];
        }

    }
}
