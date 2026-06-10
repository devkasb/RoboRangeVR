using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class moreMotion : MonoBehaviour
{
    public float speed = 2f;
    public float height = 4f;
    public float sideways = 3f;

    private Vector3 startp;
    private Vector3 rightp;
    private Vector3 upp;
    private int phase = 0;

    void Start()
    {
        startp = transform.position;

        rightp = startp + new Vector3 (sideways, 0f, 0f);
        upp = rightp + new Vector3 (0f, height, 0f);
    }

    void Update()
    {
        if (phase == 0)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                rightp,
                speed * Time.deltaTime
            );

            if(Vector3.Distance(transform.position, rightp) < 0.01f)
            {
                phase = 1;
            }
        }

        else if (phase == 1)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    upp,
                    speed * Time.deltaTime
                );

                if (Vector3.Distance(transform.position, upp) < 0.01f)
                {
                    phase = 2;
                }
            }
        
        else if (phase == 2)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    startp,
                    speed * Time.deltaTime
                );

                if (Vector3.Distance(transform.position, startp) < 0.01f)
                {
                    phase = 0;
                }
            }
    }
}
