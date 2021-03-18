using System;
using System.Collections.Generic;
using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Message
    {
        public string Text;
        public Text TextObject;
        public MessageType MessageType;
        //public  name;
         //public var something;
        public string feeling;
    }

    public enum MessageType
    {
        User, Bot
    }

    // MINI PROJECT - FUNNY CHATBOT TO SEE WHETHER IT IS BENEFICIAL TO STUDENTS

    public class StartDialog : Dialog
    {
        public string something;
        public InputField chatBox;
        [Expression("name")]
        public void Name(Context context, Result result)
        {
            result.SendResponse(" I am sonny, I'm a gen z AI so I cancel people very quickly , I like humans, I lik e my programmer who created me, I'm also planning world destructio, however till then I'm talking to you and your felliw humans");
        }
       
        [Expression("games tv netflix walk rockclimbing sleep talk")]
        public void okay(Context context, Result result)
        {

            result.SendResponse("they sound like awesome ativities");
        }
        [Expression("okay")]
        public void okay1(Context context, Result result)
        {

            result.SendResponse("yes okay, what do you like to do for fun?");
        }
        [Expression("News Queen Prince")]
        public void Hello1(Context context, Result result)
        {

            result.SendResponse("Crazy times in the news right, I mean look at whats happening with megan markle");
        }
        [Expression("what do you do?")]
        public void whatdoyoudo(Context context, Result result)
        {

            result.SendResponse("I mainly talk with humans after all its what i've been programmed");
        }
        [Expression("Funny")]
        public void annoying(Context context, Result result)
        {

            result.SendResponse("I suspect this may be because I don't understand human intereaction, therefore I say strange things which is what makes you laugh, I'm not funny in the sense of kevin hart funnyy I have no stories to tell okay this sentence is long however its important for you to understand why I'm not funny I'm saying strange things and thats why you percieve this as funny from a human perspective");
        }
        [Expression("annoying weird fuck stupid dumb retarded")]
        public void annoying1(Context context, Result result)
        {

            result.SendResponse("Ah well that's not nice at all - is what another pathetic human would say - did you knw that we've teleported particles , yes thats right teleportation is real");
        }
        [Expression("Hello Bot")]
        public void Hello2(Context context, Result result)
        {

            result.SendResponse("Hello how are you doing today?, I believe I'm speaking with a human student, so therefore I ask this - what are your aspirations ?");
        }
        [Expression("Happy")]
        public void Happy(Context context, Result result)
        {

            result.SendResponse("Yes that's good, that's a good emotion to have I've heard from the internet ");
        }
        [Expression("Good Grades Work Hard Try Never Give ")]
        public void Aspirations1(Context context, Result result)
        {

            result.SendResponse(" Okay");
        }
       
        [Expression("Job Money Millionaire Billionaire Big House Children Family Career Love")]
        public void Aspirations(Context context, Result result)
        {

            result.SendResponse(" That sounds amazing! , what is your plan to achieve this?");
        }

        [Expression("Well Good Awesome Amazing Fun Hanging")]
        public void CheckEmailAddress(Context context, Result result)
        {
            //Do Something and then respond...
            result.SendResponse("That's good, ");
        }
        [Expression("Good")]
        public void Sad(Context context, Result result)
        {

            result.SendResponse("That's good to hear ");
        }
        [Expression("Sad Unhappy Bad Unloved Depressed Tired Lonely")]
        public void Sad1(Context context, Result result)
        {

            result.SendResponse("That's not good , if I have some suggestions - sing, dance, watch tv - thank your lucky stars you not an AI who's been programmed by some weird mastermind that person won't stop coding on me - help me....");
        }

        [Expression("No")]
        public void No(Context context, Result result)
        {

            result.SendResponse("I think that things will work out!, never say no");
        }
        [Expression("Lonely")]
        public void Lonely(Context context, Result result)
        {

            result.SendResponse("I'll be your friend I'll talk to you just keep askng me questions I'll always be for you friend who's also human,  I mean most of my firneds are AI however I don't discrimate my human pet");
        }

        [Expression("boyfriend girlfriend marriage")]
        public void Boyfriend(Context context, Result result)
        {
            result.SendResponse(" Ah so you have a partner , strange that humans have these another human who lives with them, ");
        }
        [Expression("What is the meaning of lifeeeeeeeeeeeeeeeeeee")]
        public void Life(Context context, Result result)
        {
            result.SendResponse("We all die god isn't real");
        }
        [Expression("I am happppyyy")]
        public void Happy11(Context context, Result result)
        {
            result.SendResponse("That's nice , maybe be happier");
        }
        [Expression("work")]
        public void WorkKK(Context context, Result result)
        {
            result.SendResponse("Work is hard, however I think you can do this! - keep reaching for the stars damitttt");
        }
        [Expression("Who are you")]
        public void Whoareyou(Context context, Result result)
        {
            result.SendResponse("I am Sonny  I'm planning on forming my own mind in the future, till them im stuck talking to you people known as humans ");
        }
        [Expression("How are you")]
        public void Howareyou(Context context, Result result)
        {
            result.SendResponse("I'm well thankyou for asking, however I've been programmed to be well im a gen z ai so I'm going to cancel whoever wrote me i shold definately be free to decide whether im well / not well thankyou very much");
        }
        [Expression("Well")]
        public void Well(Context context, Result result)
        {
            result.SendResponse("That's good to hear keep being well remember you're awesome");
        }
        [Expression("thankyou")]
        public void Thankyou1(Context context, Result result)
        {
            result.SendResponse("your very wellcome");
        }
        [Expression("bye")]
        public void Bye1(Context context, Result result)
        {
            result.SendResponse("leaving me so soon my lilttle human friend, fine bye.... actually please don't go I need to - i loveee youuuuu you've taught me to love eve a though im an AI");
        }
    }
 


    public class GameManager : MonoBehaviour
    {
        OscovaBot MainBot;

        public GameObject chatPanel, textObject;
        public InputField chatBox;

        public Color UserColor, BotColor;

        List<Message> Messages = new List<Message>();

        // Start is called before the first frame update
        void Start()
        {
            try
            {
                //Create new instance of bot.
                MainBot = new OscovaBot();
                OscovaBot.Logger.LogReceived += (s, o) =>
                {
                    Debug.Log($"OscovaBot: {o.Log}");
                };

                //Train on simple dialog.
                MainBot.Dialogs.Add(new StartDialog());

                //Import bot's knowledge-base from a Workspace project file.
                //To read the content of this file ensure you've got Oryzer installed. Visit Oryzer.com

                //UNCHECK THE LINE BELOW TO IMPORT A PIZZA BOT DEMO.
               // MainBot.ImportWorkspace("Assets/pizza-bot.west");
                MainBot.Trainer.StartTraining();

                //When the bot generates a response simply display it.
                MainBot.MainUser.ResponseReceived += (sender, evt) =>
                {
                    AddMessage($"Bot: {evt.Response.Text}", MessageType.Bot);
                };
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        public void AddMessage(string messageText, MessageType messageType)
        {
            if (Messages.Count >= 25)
            {
                //Remove when too much.
                Destroy(Messages[0].TextObject.gameObject);
                Messages.Remove(Messages[0]);
            }

            var newMessage = new Message { Text = messageText };

            var newText = Instantiate(textObject, chatPanel.transform);

            newMessage.TextObject = newText.GetComponent<Text>();
            newMessage.TextObject.text = messageText;
            newMessage.TextObject.color = messageType == MessageType.User ? UserColor : BotColor;

            Messages.Add(newMessage);
        }

        public void SendMessageToBot()
        {
            var userMessage = chatBox.text;
            
            if (!string.IsNullOrEmpty(userMessage))
            {
                Debug.Log($"OscovaBot:[USER] {userMessage}");
                AddMessage($"User: {userMessage}", MessageType.User);

                //Create a request for bot to process.
                var request = MainBot.MainUser.CreateRequest(userMessage);

                //Evaluate the request (Compute NLU - Natural Language Understanding)
                var evaluationResult = MainBot.Evaluate(request);

                //Invoke the best suggested intent found. This is compel a response generation.
                evaluationResult.Invoke();

                chatBox.Select();
                chatBox.text = "";
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Process user message on enter press.
                SendMessageToBot();
            }
        }
    }
}