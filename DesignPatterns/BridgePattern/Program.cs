using System;

namespace BridgePattern
{
    //Simple Message object
    class Message 
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    abstract class MessageBroker
    {
        public MessageBroker(Message Message)
        {
            this.Message = Message;
        }
        public IMessageSender Sender { get; set; }

        public Message Message { get; set; }

        public virtual void Send() 
        {
            Sender.SendMessage(Message);
        }
    }

    class RabbitMq : MessageBroker
    {
        public RabbitMq(Message Message) : base(Message)
        {
        }
        public override void Send()
        {
            Console.WriteLine("Sends with RabbitMq");
            base.Send();
        }
    }
    class Kafka : MessageBroker
    {
        public Kafka(Message Message) : base(Message)
        {
        }
        public override void Send()
        {
            Console.WriteLine("Sends with Kafka");
            base.Send();
        }
    }



    //This is a bridge.It will act as bridge between a class and implementor classes
    interface IMessageSender
    {
        void SendMessage(Message Message);
    }

    //These classes are implementor classes
    class JsonSender : IMessageSender
    {
        public void SendMessage(Message Message)
        {
            Console.WriteLine($"Message subject : {Message.Subject} \nMessage body : {Message.Body}");
            Console.WriteLine("Sending message in JSON format...");
            Console.WriteLine("----------------------");
        }
    }
    class XmlSender : IMessageSender
    {
        public void SendMessage(Message Message)
        {
            Console.WriteLine($"Message subject : {Message.Subject} \nMessage body : {Message.Body}");
            Console.WriteLine("Sending message in XML format...");
            Console.WriteLine("----------------------");
            
        }
    }
    class Program
    {
        //
        /*
          Bridge pattern refactor our code as follows:
          Before Refactor:

         
                           ------------MessageBroker----------
                          /                                   \
                      RabbitMq                                 Kafka
                    /         \                              /       \
                   /           \                            /         \
                  /             \                          /           \
         RabbitMqXmlSender  RabbitMqJsonSender   KafkaXmlSender   KafkaJsonSender
                             
                             
        After Refactor:

                         MessageBroker                         MessageSender
                       /              \                       /             \
                      /                \                     /               \
       RabbitMq(MessageSender)     Kafka(MessageSender)    Json              Xml


         */
        static void Main(string[] args)
        {
            Message message = new Message() { Subject = "Hello World", Body = "How is it going?" };
            MessageBroker sender = new RabbitMq(message);
            sender.Sender = new XmlSender();
            sender.Send();
            sender = new Kafka(message);
            sender.Sender = new JsonSender();
            sender.Send();



            //NOTE - State pattern has similar syntax as well
        }
    }
}
