using WinPostInstall.Actions;
using WinPostInstall.Core.MenuSystem;

namespace WinPostInstall.Core.MenuSystem;

public class MenuBuilder
{
    private readonly CpuActions _cpuActions;
    // Потім додамо інші Actions:
    // private readonly RamActions _ramActions;
    // private readonly GpuActions _gpuActions;
    // private readonly DiskActions _diskActions;

    public MenuBuilder(CpuActions cpuActions)
    {
        _cpuActions = cpuActions;
    }

    public Menu Build()
    {
        var rootItems = new List<MenuItem>
        {
            new MenuItem("📊 Інформація про систему", new List<MenuItem>
            {
                new MenuItem("💻 Процесор (CPU)", () => _cpuActions.Show()),
                new MenuItem("🧠 Оперативна пам'ять (RAM)", () => ShowComingSoon("RAM")),
                new MenuItem("🎮 Відеокарта (GPU)", () => ShowComingSoon("GPU")),
                new MenuItem("💾 Диски", () => ShowComingSoon("Диски")),
                new MenuItem("🔌 Материнська плата", () => ShowComingSoon("Материнська плата")),
            }),

            new MenuItem("⚡ Оптимізація Windows", new List<MenuItem>
            {
                new MenuItem("🛑 Вимкнути непотрібні служби", () => ShowComingSoon("Вимкнення служб")),
                new MenuItem("🧹 Очистити тимчасові файли", () => ShowComingSoon("Очищення тимчасових файлів")),
                new MenuItem("🔋 Оптимізувати живлення", () => ShowComingSoon("Оптимізація живлення")),
                new MenuItem("🚫 Вимкнути телеметрію", () => ShowComingSoon("Вимкнення телеметрії")),
            }),

            new MenuItem("🧽 Очищення системи", new List<MenuItem>
            {
                new MenuItem("🗑️ Очистити корзину", () => CleanRecycleBin()),
                new MenuItem("🌐 Очистити кеш браузерів", () => ShowComingSoon("Кеш браузерів")),
                new MenuItem("📁 Очистити папку Temp", () => CleanTempFolder()),
                new MenuItem("📉 Очистити файли оновлень", () => ShowComingSoon("Файли оновлень")),
            }),

            new MenuItem("🔧 Налаштування системи", new List<MenuItem>
            {
                new MenuItem("👁️ Сховати значок кошика", () => ShowComingSoon("Значок кошика")),
                new MenuItem("🎨 Вимкнути прозорість", () => ShowComingSoon("Прозорість")),
                new MenuItem("⚙️ Оптимізувати Visual Effects", () => ShowComingSoon("Visual Effects")),
            }),

            new MenuItem("ℹ️ Про програму", () => ShowAbout()),

            new MenuItem("🚪 Вийти", () => ExitProgram())
        };

        return new Menu(rootItems);
    }

    private void ShowComingSoon(string featureName)
    {
        Console.Clear();
        Console.WriteLine($"=== {featureName} ===");
        Console.WriteLine("Ця функція ще в розробці.");
        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення...");
        Console.ReadKey(true);
    }

    private void CleanRecycleBin()
    {
        Console.Clear();
        Console.WriteLine("=== Очищення корзини ===");
        try
        {
            // Спрощена версія без Shell32
            Console.WriteLine("Очищення корзини...");

            // Альтернативний спосіб через командний рядок
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c rd /s /q %systemdrive%\\$Recycle.Bin";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();

            Console.WriteLine("✅ Корзину очищено!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Помилка: {ex.Message}");
        }
        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey(true);
    }

    private void CleanTempFolder()
    {
        Console.Clear();
        Console.WriteLine("=== Очищення папки Temp ===");

        try
        {
            string tempPath = Path.GetTempPath();
            Console.WriteLine($"Шлях до Temp: {tempPath}");

            var files = Directory.GetFiles(tempPath);
            var directories = Directory.GetDirectories(tempPath);

            Console.WriteLine($"Знайдено файлів: {files.Length}");
            Console.WriteLine($"Знайдено папок: {directories.Length}");

            Console.Write("\nОчистити? (y/n): ");
            var key = Console.ReadKey(true);

            if (key.KeyChar == 'y' || key.KeyChar == 'Y')
            {
                int deletedFiles = 0;
                foreach (var file in files)
                {
                    try
                    {
                        File.Delete(file);
                        deletedFiles++;
                    }
                    catch { }
                }

                Console.WriteLine($"\n✅ Видалено файлів: {deletedFiles}");
            }
            else
            {
                Console.WriteLine("\n❌ Скасовано");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Помилка: {ex.Message}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey(true);
    }

    private void ShowAbout()
    {
        Console.Clear();
        Console.WriteLine("=== WinPostInstall Tool ===");
        Console.WriteLine("Версія: 1.0.0");
        Console.WriteLine("Автор: Ваш проект");
        Console.WriteLine("\nФункції:");
        Console.WriteLine("- Інформація про апаратне забезпечення");
        Console.WriteLine("- Оптимізація Windows");
        Console.WriteLine("- Очищення системи");
        Console.WriteLine("- Налаштування системних параметрів");
        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey(true);
    }

    private void ExitProgram()
    {
        Console.Clear();
        Console.WriteLine("Дякуємо за використання WinPostInstall Tool!");
        Console.WriteLine("До побачення!");
        Thread.Sleep(1500);
        Environment.Exit(0);
    }
}
