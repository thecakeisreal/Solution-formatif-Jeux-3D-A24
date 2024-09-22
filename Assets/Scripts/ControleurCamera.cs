using UnityEngine;
using UnityEngine.InputSystem;

public class ControleurCamera : MonoBehaviour
{
    [SerializeField]
    private float vitesseDeplacement;

    [SerializeField]
    private float vitesseZoom;

    [SerializeField]
    private float vitesseInclinaison;

    private Vector2 deplacement;
    private float zoom;
    private float inclinaison;

    public void Deplacer(InputAction.CallbackContext contexte)
    {
        // Même effet que contexte.action.ReadValue
        deplacement = contexte.ReadValue<Vector2>().normalized * vitesseDeplacement;
    }

    public void Zoomer(InputAction.CallbackContext contexte)
    {
        zoom = contexte.ReadValue<float>() * vitesseZoom;
    }

    public void Incliner(InputAction.CallbackContext contexte)
    {
        inclinaison = contexte.ReadValue<float>() * vitesseInclinaison;
    }

    private void FixedUpdate()
    {
        transform.transform.position += new Vector3(deplacement.x, 0.0f, deplacement.y) * Time.deltaTime;
        transform.transform.position += transform.transform.forward * zoom * Time.deltaTime;
        transform.transform.Rotate(Vector3.right, inclinaison * Time.deltaTime);
    }

}
