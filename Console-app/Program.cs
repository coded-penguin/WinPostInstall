using WinPostInstall.Core.MenuSystem;
using WinPostInstall.Core.Controls;
using WinPostInstall.Hardware.Models;
using WinPostInstall.Hardware;
using WinPostInstall.Actions;
using WinPostInstall.Providers;

namespace WinPostInstall;

class Program
{
    static void Main()
    {
        // Налаштування консолі
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "WinPostInstall Tool";
        Console.CursorVisible = false;

        // Права адміністратора?
        CheckAdminRights();

        try
        {
            // Спробуємо ініціалізувати Hardware.Info, але якщо не вийде - працюватимемо без нього
            IHardwareProvider hardwareProvider = TryCreateHardwareProvider();

            // Створюємо Actions
            var cpuActions = new CpuActions(hardwareProvider);

            // Створюємо меню
            var menuBuilder = new MenuBuilder(cpuActions);
            var menu = menuBuilder.Build();

            // Запускаємо контролер меню
            var controls = new MenuControlsHandler(menu);
            controls.Run();
        }
        catch (Exception ex)
        {
            ShowErrorScreen(ex);
        }
    }

    private static void CheckAdminRights()
    {
        var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
        var principal = new System.Security.Principal.WindowsPrincipal(identity);

        if (!principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("УВАГА: Програма запущена без прав адміністратора!");
            Console.WriteLine("Деякі функції можуть не працювати.");
            Console.WriteLine("Для повної функціональності запустіть програму від імені адміністратора.");
            Console.ResetColor();
            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey(true);
        }
    }

    private static IHardwareProvider TryCreateHardwareProvider()
    {
        try
        {
            Console.WriteLine("Спроба ініціалізації Hardware.Info...");
            var provider = new HardwareInfoProvider();
            Console.WriteLine("✅ Hardware.Info успішно ініціалізовано");
            return provider;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Не вдалося ініціалізувати Hardware.Info: {ex.Message}");
            Console.WriteLine("Використовується заглушка...");

            // Повертаємо заглушку
            return new DummyHardwareProvider();
        }
    }

    private static void ShowErrorScreen(Exception ex)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║         КРИТИЧНА ПОМИЛКА              ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine($"\nПовідомлення: {ex.Message}");
        Console.WriteLine($"\nТип помилки: {ex.GetType().Name}");

        Console.WriteLine("\nРекомендації:");
        Console.WriteLine("1. Переконайтесь, що .NET 8+ встановлено");
        Console.WriteLine("2. Спробуйте запустити як адміністратор");
        Console.WriteLine("3. Перевстановіть пакет Hardware.Info");

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey(true);
    }
}

// Заглушка для тестування
public class DummyHardwareProvider : IHardwareProvider
{
    public IEnumerable<CpuInfo> GetCpuInfo()
    {
        return new List<CpuInfo>
        {
            new CpuInfo
            {
                Name = "Intel Core i7-12700K (Dummy Data)",
                Manufacturer = "Intel Corporation",
                Cores = 12,
                Threads = 20,
                MaxClockSpeedGHz = 5.0f,
                CurrentClockSpeedGHz = 3.6f,
                L2CacheSizeKb = 12288,
                L3CacheSizeKb = 25600
            }
        };
    }
}
