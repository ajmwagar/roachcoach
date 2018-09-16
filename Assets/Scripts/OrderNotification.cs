using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderNotification : MonoBehaviour
{
    //public event Action NewOrderPoppedUp = delegate { };
    [SerializeField]
    private TMPro.TextMeshProUGUI UserAndLabel;

    [SerializeField]
    private TMPro.TextMeshProUGUI Description;

    void Awake()
    {
        //NewOrderPoppedUp += SetOrderNotification;
    }

    void Update()
    {

    }

    public void SetOrderNotification(Order order)
    {
        UserAndLabel.text = order.user + " : " + order.label;
        Description.text = "Description: " + order.description;
    }
}
