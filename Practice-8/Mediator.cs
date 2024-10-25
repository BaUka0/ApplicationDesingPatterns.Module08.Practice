using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8
{
    public interface IMediator
    {
        void SendMessage(User sender, string message, string channel);
        void AddUser(User user, string channel);
        void RemoveUser(User user, string channel);
        void NotifyUserJoined(User user, string channel);
        void NotifyUserLeft(User user, string channel);
    }

    // Конкретный посредник для чата
    public class ChatMediator : IMediator
    {
        private Dictionary<string, List<User>> _usersByChannel = new Dictionary<string, List<User>>();

        public void SendMessage(User sender, string message, string channel)
        {
            if (!_usersByChannel.ContainsKey(channel)) return;
            foreach (var user in _usersByChannel[channel])
            {
                if (user != sender)
                {
                    user.ReceiveMessage(sender, message);
                }
            }
        }

        public void AddUser(User user, string channel)
        {
            if (!_usersByChannel.ContainsKey(channel))
            {
                _usersByChannel[channel] = new List<User>();
            }
            _usersByChannel[channel].Add(user);
            NotifyUserJoined(user, channel);
        }

        public void RemoveUser(User user, string channel)
        {
            if (!_usersByChannel.ContainsKey(channel)) return;
            _usersByChannel[channel].Remove(user);
            NotifyUserLeft(user, channel);
        }

        public void NotifyUserJoined(User user, string channel)
        {
            Console.WriteLine($"{user.Name} подключился к каналу {channel}");
            foreach (var u in _usersByChannel[channel])
            {
                if (u != user)
                {
                    u.NotifyUserJoined(user, channel);
                }
            }
        }

        public void NotifyUserLeft(User user, string channel)
        {
            Console.WriteLine($"{user.Name} покинул канал {channel}");
            foreach (var u in _usersByChannel[channel])
            {
                if (u != user)
                {
                    u.NotifyUserLeft(user, channel);
                }
            }
        }
    }

    // Интерфейс для пользователя
    public interface IUser
    {
        string Name { get; }
        void SendMessage(string message, string channel);
        void JoinChannel(string channel);
        void LeaveChannel(string channel);
        void ReceiveMessage(User sender, string message);
        void NotifyUserJoined(User user, string channel);
        void NotifyUserLeft(User user, string channel);
    }

    // Конкретный класс пользователя
    public class User : IUser
    {
        private readonly IMediator _mediator;
        private string _currentChannel;

        public User(string name, IMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public string Name { get; }

        public void SendMessage(string message, string channel)
        {
            _mediator.SendMessage(this, message, channel);
        }

        public void JoinChannel(string channel)
        {
            _mediator.AddUser(this, channel);
            _currentChannel = channel;
            Console.WriteLine($"{Name} присоединился к каналу {channel}");
        }

        public void LeaveChannel(string channel)
        {
            _mediator.RemoveUser(this, channel);
            Console.WriteLine($"{Name} покинул канал {channel}");
        }

        public void ReceiveMessage(User sender, string message)
        {
            Console.WriteLine($"[{_currentChannel}] {sender.Name}: {message}");
        }

        public void NotifyUserJoined(User user, string channel)
        {
            Console.WriteLine($"[{_currentChannel}] {user.Name} подключился к каналу");
        }

        public void NotifyUserLeft(User user, string channel)
        {
            Console.WriteLine($"[{_currentChannel}] {user.Name} покинул канал");
        }
    }

    internal class Mediator
    {
    }
}
