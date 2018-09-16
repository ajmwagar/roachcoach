using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System.Text.RegularExpressions;
using System.Text;

[RequireComponent(typeof(TwitchIRC))]
public class TwitchChatExample : MonoBehaviour
{
    public int maxMessages = 100; //we start deleting UI elements when the count is larger than this var.
    public OrderHandler orderHandler; 
    private LinkedList<GameObject> messages =
        new LinkedList<GameObject>();
    private TwitchIRC IRC;
  private float lastPingTime;
  private string helpMessage = "Welcome! Build your own sandwich or select one from the menu.  To order a sandwich just say somethng like \"Hey Roach, can i have the HLT with no tomatos?\" or \"Can i have a sandwich with tomatos, lettuce, and extra cheese on wheatbread? To see the menu, say something like \"Hey Roach, what's on the menu?\" to see the menu. To see all available ingredients say something like \"Hey Roach, what toppings do you have?\".";
    //when message is recieved from IRC-server or our own message.
    void OnChatMsgRecieved(string msg)
    {
        //parse from buffer.
        int msgIndex = msg.IndexOf("PRIVMSG #");
        string msgString = msg.Substring(msgIndex + IRC.channelName.Length + 11);
        string user = msg.Substring(1, msg.IndexOf('!') - 1);


    if (msgString.StartsWith("Hey Roach,", System.StringComparison.CurrentCultureIgnoreCase))
    {
      Regex whatsOnMenuRegex = new Regex("hey roach,.*menu.*", RegexOptions.IgnoreCase);

      Regex whatAreIngredientsRegex = new Regex("hey roach,(.*ingredient.*|.*topping.*)", RegexOptions.IgnoreCase);
      //Whats on the menu
      if (whatsOnMenuRegex.IsMatch(msgString))
      {
        string menu = OrderHandler.whatsOnTheMenu();
        foreach (string menuItem in menu.Split('|'))
        {
          IRC.SendMsg(menuItem);
        }
      }else if (whatAreIngredientsRegex.IsMatch(msgString))
      {
        StringBuilder sb = new StringBuilder();
        sb.Append("All available ingredients:");
        foreach (string ingredient in System.Enum.GetValues(typeof (Ingredient.ITypes)))
        {
          sb.Append(' ');
          sb.Append(ingredient);
          sb.Append(',');
        }
        sb.Remove(sb.Length - 1, 1);
      }

      //Assume its an order
      else
      {
        orderHandler.handleStreamText(msgString, user);
      }

    }


    //remove old messages for performance reasons.
    if (messages.Count > maxMessages)
        {
            Destroy(messages.First.Value);
            messages.RemoveFirst();
        }

    }
 

    // Use this for initialization
    void Start()
    {
        IRC = this.GetComponent<TwitchIRC>();
        IRC.messageRecievedEvent.AddListener(OnChatMsgRecieved);
        lastPingTime = Time.time;
    }

  private void Update()
  {
    if(Time.time - lastPingTime > 120)
    {
      IRC.SendMsg(helpMessage);
      lastPingTime = Time.time;
    }
  }
}
