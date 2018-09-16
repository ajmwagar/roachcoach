using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System.Text.RegularExpressions;

[RequireComponent(typeof(TwitchIRC))]
public class TwitchChatExample : MonoBehaviour
{
    public int maxMessages = 100; //we start deleting UI elements when the count is larger than this var.
    public OrderHandler orderHandler; 
    private LinkedList<GameObject> messages =
        new LinkedList<GameObject>();
    private TwitchIRC IRC;
    //when message is recieved from IRC-server or our own message.
    void OnChatMsgRecieved(string msg)
    {
        //parse from buffer.
        int msgIndex = msg.IndexOf("PRIVMSG #");
        string msgString = msg.Substring(msgIndex + IRC.channelName.Length + 11);
        string user = msg.Substring(1, msg.IndexOf('!') - 1);


    if (msgString.StartsWith("Hey Roach,", System.StringComparison.CurrentCultureIgnoreCase))
    {
      Regex whatsOnMenuRegex = new Regex("hey roach, what.*menu.*", RegexOptions.IgnoreCase);
      //Whats on the menu
      if (whatsOnMenuRegex.IsMatch(msgString))
      {
        string menu = OrderHandler.whatsOnTheMenu();
       /* foreach (String menuItem in menu.Split('\r\n'))
        {
          IRC.SendMsg(menuItem);
        }*/
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
 
    Color ColorFromUsername(string username)
    {
        Random.seed = username.Length + (int)username[0] + (int)username[username.Length - 1];
        return new Color(Random.Range(0.25f, 0.55f), Random.Range(0.20f, 0.55f), Random.Range(0.25f, 0.55f));
    }
    // Use this for initialization
    void Start()
    {
        IRC = this.GetComponent<TwitchIRC>();
        //IRC.SendCommand("CAP REQ :twitch.tv/tags"); //register for additional data such as emote-ids, name color etc.
        IRC.messageRecievedEvent.AddListener(OnChatMsgRecieved);
    }
}
