using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private Transform ShootController;
    [SerializeField] private GameObject shot;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Instantiate(shot, ShootController.position, ShootController.rotation);
    }
}
