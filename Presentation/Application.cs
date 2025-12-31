using Microsoft.Extensions.DependencyInjection;
using Application.CodeMetrics;
using Application.Operations;
using Application.Matrix;
using Presentation.Resources;
using Domain.Enums;

namespace Presentation;

public class ConsoleApplication
{
    private readonly IServiceProvider _serviceProvider;

    public ConsoleApplication(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine(PresentationMessages.MainMenuTitle);
            Console.WriteLine(PresentationMessages.MenuOption1);
            Console.WriteLine(PresentationMessages.MenuOption2);
            Console.WriteLine(PresentationMessages.MenuOption3);
            Console.WriteLine(PresentationMessages.MenuOption4);
            Console.Write(PresentationMessages.ChooseOption);

            string option = Console.ReadLine() ?? "";

            if (int.TryParse(option, out int optionNumber) && Enum.IsDefined(typeof(MenuOption), optionNumber))
            {
                var menuOption = (MenuOption)optionNumber;
                switch (menuOption)
                {
                    case MenuOption.Option1:
                        var setOperations = _serviceProvider.GetRequiredService<SetOperations>();
                        setOperations.Execute();
                        break;
                    case MenuOption.Option2:
                        var compareSequence = _serviceProvider.GetRequiredService<CompareSequence>();
                        compareSequence.Execute();
                        break;
                    case MenuOption.Option3:
                        var consoleMatrix = _serviceProvider.GetRequiredService<ConsoleMatrix>();
                        consoleMatrix.Execute();
                        break;
                    case MenuOption.Option4:
                        running = false;
                        Console.WriteLine(PresentationMessages.Goodbye);
                        break;
                }
            }
            else
            {
                Console.WriteLine(PresentationMessages.InvalidOption);
            }
        }
    }
}
