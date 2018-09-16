using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderNotification : MonoBehaviour
{
    //public event Action NewOrderPoppedUp = delegate { };
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

    public void SetOrderNotification(Order order)
    {
        UserAndLabel.text = "User: " + order.user + "\nLabel: " + order.label;
        Description.text = "Desription: " + order.description;
    }
}
