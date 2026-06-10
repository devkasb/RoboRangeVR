using UnityEngine;

public class MoveCube : MonoBehaviour
{
    // Geschwindigkeit der Bewegung
    public float speed = 2f;

    // Wie hoch der Würfel schwebt
    public float height = 1f;

    // Startposition des Cube
    private Vector3 startPosition;

    // Wird einmal beim start aufgerufen
    void Start()
    {
        // Ursprüngliche Position speichern
        startPosition = transform.position;
    }

    // wird jeden Frame ausgeführt
    void Update()
    {
        // berechne eine weiche Auf- und Abbewegung
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * height;

        // neue position setzen
        transform.position = new Vector3(
            startPosition.x,
            newY,
            startPosition.z
        );
    }
}
