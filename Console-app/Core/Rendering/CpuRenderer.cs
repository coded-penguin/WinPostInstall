using WinPostInstall.Hardware.Models;

namespace WinPostInstall.Core.Rendering;

public static class CpuRenderer
{
    public static void Render(IEnumerable<CpuInfo> cpus)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║           ІНФОРМАЦІЯ ПРО ПРОЦЕСОР           ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.ResetColor();

        int cpuNumber = 1;
        foreach (var cpu in cpus)
        {
            Console.WriteLine($"\n--- Процесор #{cpuNumber} ---");

            Console.WriteLine($"\n{"Назва:",-20} {cpu.Name}");
            Console.WriteLine($"{"Виробник:",-20} {cpu.Manufacturer}");
            Console.WriteLine($"{"Ядра:",-20} {cpu.Cores}");
            Console.WriteLine($"{"Потоки:",-20} {cpu.Threads}");
            Console.WriteLine($"{"Макс. частота:",-20} {cpu.MaxClockSpeedGHz:F2} GHz");
            Console.WriteLine($"{"Поточна частота:",-20} {cpu.CurrentClockSpeedGHz:F2} GHz");
            Console.WriteLine($"{"Кеш L2:",-20} {FormatCacheSize(cpu.L2CacheSizeKb)}");
            Console.WriteLine($"{"Кеш L3:",-20} {FormatCacheSize(cpu.L3CacheSizeKb)}");

            // Додаткова інформація
            Console.WriteLine($"\n{"Загальна інформація:",-20}");
            Console.WriteLine($"  - Потужність: {CalculatePowerEstimate(cpu)}");
            Console.WriteLine($"  - Тип: {DetectCpuType(cpu)}");

            cpuNumber++;
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n" + new string('═', 50));
        Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
        Console.ResetColor();
        Console.ReadKey(true);
    }

    private static string FormatCacheSize(uint kb)
    {
        if (kb == 0) return "Невідомо";
        if (kb < 1024) return $"{kb} KB";
        return $"{(kb / 1024.0):F1} MB";
    }

    private static string CalculatePowerEstimate(CpuInfo cpu)
    {
        int score = (int)(cpu.Cores * cpu.Threads * cpu.MaxClockSpeedGHz);
        if (score < 50) return "Слабкий";
        if (score < 150) return "Середній";
        if (score < 300) return "Потужний";
        return "Дуже потужний";
    }

    private static string DetectCpuType(CpuInfo cpu)
    {
        if (cpu.Name.Contains("Intel"))
        {
            if (cpu.Name.Contains("i9") || cpu.Name.Contains("i7")) return "Високопродуктивний";
            if (cpu.Name.Contains("i5")) return "Середній клас";
            return "Бюджетний";
        }

        if (cpu.Name.Contains("AMD"))
        {
            if (cpu.Name.Contains("Ryzen 9") || cpu.Name.Contains("Ryzen 7")) return "Високопродуктивний";
            if (cpu.Name.Contains("Ryzen 5")) return "Середній клас";
            return "Бюджетний";
        }

        return "Невідомий тип";
    }
}
