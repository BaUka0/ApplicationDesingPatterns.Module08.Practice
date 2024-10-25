using System;
namespace Practice_8
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Light light = new Light();
            AirConditioner airConditioner = new AirConditioner();
            TV tv = new TV();

            LightOnCommand lightOn = new LightOnCommand(light);
            LightOffCommand lightOff = new LightOffCommand(light);
            AirConditionerOnCommand airConditionerOn = new AirConditionerOnCommand(airConditioner);
            AirConditionerOffCommand airConditionerOff = new AirConditionerOffCommand(airConditioner);
            TVOnCommand tvOn = new TVOnCommand(tv);
            TVOffCommand tvOff = new TVOffCommand(tv);

            RemoteControl remote = new RemoteControl();

            remote.SetCommand(0, lightOn, lightOff);
            remote.SetCommand(1, airConditionerOn, airConditionerOff);
            remote.SetCommand(2, tvOn, tvOff);

            Console.WriteLine("Нажимаем кнопку 1");
            remote.OnButtonWasPressed(0);
            Console.WriteLine("Нажимаем кнопку 2");
            remote.OnButtonWasPressed(1);
            Console.WriteLine("Нажимаем кнопку 3");
            remote.OnButtonWasPressed(2);

            ICommand[] macroCommands = { lightOn, airConditionerOn, tvOn };
            MacroCommand macro = new MacroCommand(macroCommands);

            Console.WriteLine("Выполняем макрокоманду...");
            macro.Execute();

            Console.WriteLine("Отменяем макрокоманду...");
            macro.Undo();

            //Template
            ReportGenerator pdfReport = new PdfReport();
            pdfReport.GenerateReport();

            ReportGenerator excelReport = new ExcelReport();
            excelReport.GenerateReport();

            ReportGenerator htmlReport = new HtmlReport();
            htmlReport.GenerateReport();

            ReportGenerator csvReport = new CsvReport();
            csvReport.GenerateReport();

            ReportGenerator emailReport = new EmailReport();
            emailReport.GenerateReport();*/

            //Mediator
            var mediator = new ChatMediator();

            // Создаем пользователей
            var user1 = new User("Иван", mediator);
            var user2 = new User("Петр", mediator);
            var user3 = new User("Мария", mediator);

            // Создаем каналы
            var channel1 = "Общий";
            var channel2 = "Музыка";

            // Добавляем пользователей в каналы
            user1.JoinChannel(channel1);
            user2.JoinChannel(channel1);
            user3.JoinChannel(channel2);

            // Отправляем сообщения
            user1.SendMessage("Привет!", channel1);
            user2.SendMessage("Как дела?", channel1);
            user3.SendMessage("Слушаю музыку!", channel2);

            // Удаляем пользователя из канала
            user2.LeaveChannel(channel1);
        }
    }
}