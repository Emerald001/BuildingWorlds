using UnityEngine.UI;
using UnityEngine;

public class GrowShrink : MonoBehaviour
{
    public Slider slider;
    public Animator Left;
    public Animator Right;
    public Camera Cam;
    private CreateObject create;
    private PickUpObject pickUp;

    void Update()
    {
        create = transform.GetComponent<CreateObject>();
        pickUp = transform.GetComponent<PickUpObject>();

        if (!pickUp.carrying)
        {
            if (Input.GetButtonDown("Fire1")) GrowShoot();
            if (Input.GetButtonDown("Fire2")) ShrinkShoot();
        }
    }

    void GrowShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit))
        {
            IsTarget target = hit.transform.GetComponent<IsTarget>();
            if (target != null && create.CurrentValue > 10) target.Grow();
            if (target != null && create.CurrentValue > 10) Left.SetTrigger("Grow");
            if (target != null && create.CurrentValue > 10) create.LowerBy += 10;

            SchaapTarget Schaap = hit.transform.GetComponent<SchaapTarget>();
            if (Schaap != null)
            {
                Schaap.Grow();
                Left.SetTrigger("Grow");
            }
        }
    }
    void ShrinkShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit))
        {
            IsTarget target = hit.transform.GetComponent<IsTarget>();
            if (target != null) target.Shrink();
            if (target != null) Right.SetTrigger("Shrink");
            if (target != null) create.LowerBy -= 10;

            SchaapTarget Schaap = hit.transform.GetComponent<SchaapTarget>();
            if (Schaap != null)
            {
                Schaap.Shrink();
                Right.SetTrigger("Shrink");
            }
        }
    }
}
