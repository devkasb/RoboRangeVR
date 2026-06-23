using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public Renderer[] buttonRenderers;

    public float offIntensity = 0.2f;
    public float onIntensity = 8f;

    private bool play = false;
    private Color[] baseEmissionColors;

    void Start()
    {
        baseEmissionColors = new Color[buttonRenderers.Length];

        for (int i = 0; i < buttonRenderers.Length; i++)
        {
            baseEmissionColors[i] = buttonRenderers[i].material.GetColor("_EmissionColor");
        }
    }

    public void Hit()
    {
        play = !play;

        if (musicSource != null)
        {
            if (play)
            {
                musicSource.Play();
            }
            else
            {
                musicSource.Stop();
            }
        }

        for (int i = 0; i < buttonRenderers.Length; i++)
        {
            Material mat = buttonRenderers[i].material;

            float intensity = play ? onIntensity : offIntensity;

            mat.SetColor("_EmissionColor", baseEmissionColors[i] * intensity);
        }
    }
}