using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class Light
    {
        private bool _isOn;
        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Свет включен.");
        }
        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("Свет выключен.");
        }
    }
    public class AirConditioner
    {
        private bool _isOn;
        private int _temperature;
        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Кондиционер включен.");
        }
        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("Кондиционер выключен.");
        }
    }
    public class TV
    {
        private bool _isOn;
        private int _channel;

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Телевизор включен.");
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("Телевизор выключен.");
        }
    }
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }
    public class AirConditionerOnCommand : ICommand
    {
        private AirConditioner _airConditioner;

        public AirConditionerOnCommand(AirConditioner airConditioner)
        {
            _airConditioner = airConditioner;
        }

        public void Execute()
        {
            _airConditioner.TurnOn();
        }

        public void Undo()
        {
            _airConditioner.TurnOff();
        }
    }

    public class AirConditionerOffCommand : ICommand
    {
        private AirConditioner _airConditioner;

        public AirConditionerOffCommand(AirConditioner airConditioner)
        {
            _airConditioner = airConditioner;
        }

        public void Execute()
        {
            _airConditioner.TurnOff();
        }

        public void Undo()
        {
            _airConditioner.TurnOn();
        }
    }
    public class TVOnCommand : ICommand
    {
        private TV _tv;

        public TVOnCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.TurnOn();
        }

        public void Undo()
        {
            _tv.TurnOff();
        }
    }

    public class TVOffCommand : ICommand
    {
        private TV _tv;

        public TVOffCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.TurnOff();
        }

        public void Undo()
        {
            _tv.TurnOn();
        }
    }
    public class RemoteControl
    {
        private ICommand[] _onCommands;
        private ICommand[] _offCommands;
        private ICommand _undoCommand;

        public RemoteControl()
        {
            _onCommands = new ICommand[7];
            _offCommands = new ICommand[7];
            _undoCommand = null;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            _onCommands[slot] = onCommand;
            _offCommands[slot] = offCommand;
        }

        public void OnButtonWasPressed(int slot)
        {
            if (_onCommands[slot] != null)
            {
                _onCommands[slot].Execute();
                _undoCommand = _onCommands[slot];
            }
        }

        public void OffButtonWasPressed(int slot)
        {
            if (_offCommands[slot] != null)
            {
                _offCommands[slot].Execute();
                _undoCommand = _offCommands[slot];
            }
        }

        public void UndoButtonWasPressed()
        {
            if (_undoCommand != null)
            {
                _undoCommand.Undo();
            }
        }
    }
    public class MacroCommand : ICommand
    {
        private ICommand[] _commands;

        public MacroCommand(ICommand[] commands)
        {
            _commands = commands;
        }

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            for (int i = _commands.Length - 1; i >= 0; i--)
            {
                _commands[i].Undo();
            }
        }
    }
}
