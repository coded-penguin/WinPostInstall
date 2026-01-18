using WinPostInstall.Core.Rendering;
using WinPostInstall.Hardware;

namespace WinPostInstall.Actions;

public class CpuActions
{
    private readonly IHardwareProvider _hardwareProvider;

    public CpuActions(IHardwareProvider hardwareProvider)
    {
        _hardwareProvider = hardwareProvider;
    }

    public void Show()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Отримання інформації про процесор...");

            var data = _hardwareProvider.GetCpuInfo();

            if (data == null || !data.Any())
            {
                ShowNoDataMessage();
            }
            else
            {
                CpuRenderer.Render(data);
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
    }

    private void ShowNoDataMessage()
    {
        Console.Clear();
        Console.WriteLine("=== Інформація про процесор ===");
        Console.WriteLine("\nНе вдалося отримати дані про процесор.");
        Console.WriteLine("\nМожливі причини:");
        Console.WriteLine("1. Відсутні права адміністратора");
        Console.WriteLine("2. Проблема з бібліотекою Hardware.Info");
        Console.WriteLine("3. Система не підтримується");

        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey(true);
    }

    private void ShowErrorMessage(Exception ex)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("=== ПОМИЛКА ===");
        Console.ResetColor();

        Console.WriteLine($"\n{ex.Message}");
        Console.WriteLine($"\nТип: {ex.GetType().Name}");

        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey(true);
    }
}
