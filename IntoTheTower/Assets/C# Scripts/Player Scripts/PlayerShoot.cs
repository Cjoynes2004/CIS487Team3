using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform aim;
    public float reticleDistance;

    private Vector2 mousePos;
    private Vector2 playerPos;
    private Vector2 reticlePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AimAdjust();
    }

    private void AimAdjust()
    {
        playerPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - playerPos).normalized;
        reticlePos = playerPos + direction * reticleDistance;
        aim.position = reticlePos;
    }

    // Update is called once per frame
    void Update()
    {
        AimAdjust();
    }
}
