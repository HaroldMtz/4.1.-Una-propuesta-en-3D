using UnityEngine;
using UnityEngine.UI;

public class SuperSpeedManager : MonoBehaviour
{
    [Header("Referencias")]
    public PlayerMotor motor;
    public Slider speedSlider;
    public ParticleSystem speedLines;
    public Transform playerModel;

    [Header("Configuración")]
    public float boostDuration = 3f;
    public float speedMultiplier = 2.5f;
    public Color boostColor = Color.yellow;

    private float timer;
    private bool active = false;
    private Color originalColor;
    private MeshRenderer mr;

    void Start()
    {
        if (!motor) motor = GetComponent<PlayerMotor>();
        mr = playerModel.GetComponent<MeshRenderer>();

        originalColor = mr.material.color;

        if (speedSlider)
        {
            speedSlider.maxValue = boostDuration;
            speedSlider.value = 0;
            speedSlider.gameObject.SetActive(false);
        }

        if (speedLines)
        {
            speedLines.Stop();
            speedLines.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!active) return;

        timer -= Time.deltaTime;
        if (speedSlider) speedSlider.value = timer;

        if (timer <= 0)
            EndBoost();
    }

    public void ActivateBoost()
    {
        if (active) return;

        active = true;
        timer = boostDuration;

        motor.isBoostActive = true;                
        motor.moveSpeed *= speedMultiplier;         

        mr.material.color = boostColor;

        if (speedSlider)
        {
            speedSlider.value = boostDuration;
            speedSlider.gameObject.SetActive(true);
        }

        if (speedLines)
        {
            speedLines.gameObject.SetActive(true);
            speedLines.Play();
        }
    }

    void EndBoost()
    {
        active = false;

        motor.moveSpeed /= speedMultiplier;        
        motor.isBoostActive = false;               

        mr.material.color = originalColor;

        if (speedSlider)
            speedSlider.gameObject.SetActive(false);

        if (speedLines)
        {
            speedLines.Stop();
            speedLines.gameObject.SetActive(false);
        }
    }
}
