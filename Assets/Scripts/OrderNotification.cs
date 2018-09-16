using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderNotification : MonoBehaviour
{
    //public event Action NewOrderPoppedUp = delegate { };

    public OrderHandler OH;

    [SerializeField]
    private TextMesh UserAndLabel;

    [SerializeField]
    private TextMesh Description;

    void Awake()
    {
        //NewOrderPoppedUp += SetOrderNotification;
    }

    void Update()
    {

    }

    public void SetOrderNotification()
    {
        UserAndLabel.text = "User: " + OH.final.user + "\nLabel: " + OH.final.label;
        Description.text = "Desription: " + OH.final.description;
    }
}
