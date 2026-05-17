using UnityEngine;
using UnityEngine.InputSystem;

public class NewEmptyCSharpScript : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Getroffen: " + hit.collider.gameObject.name);
                
                TargetHit target = hit.collider.GetComponent<TargetHit>();

                if (target != null)
                {
                    target.Hit();
                }
            }
        }
    }
}
