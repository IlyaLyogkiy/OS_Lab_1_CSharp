using System;
using System.IO;

namespace HelloApp
{
  class Program
  {
    static void Main(string[] args)
    {
     Menu: Console.WriteLine("\nВведите пункт для выполнения:\n1.Вывод информации о дисках\n2.Работа с файлами\n3.Работа с форматом JSON\n0.Выход");
      string choise = Console.ReadLine();
      switch (choise)
      {
        case "1":
          //вывод информации о логических дисках и тп
          DriveInfo[] drives = DriveInfo.GetDrives();

          foreach (DriveInfo drive in drives)
          {
            Console.WriteLine($"\nНазвание: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}");
            if (drive.IsReady)
            {
              Console.WriteLine($"Объем диска: {drive.TotalSize}");
              Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
              Console.WriteLine($"Метка: {drive.VolumeLabel}");
            }
          }
          break;
        case "2":
          // создаем каталог для файла
          string path = @"C:\SomeDir2";
          DirectoryInfo dirInfo = new DirectoryInfo(path);
          if (!dirInfo.Exists)
          {
            dirInfo.Create();
          }
          Console.WriteLine("\nВведите строку для записи в файл:");
          string text = Console.ReadLine();

          // запись в файл
          using (FileStream fstream = new FileStream($"{path}/note.txt", FileMode.OpenOrCreate))
          {
            // преобразуем строку в байты
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            fstream.Write(array, 0, array.Length);
            Console.WriteLine("Текст записан в файл");
          }

          // чтение из файла
          using (FileStream fstream = File.OpenRead($"{path}/note.txt"))
          {
            // преобразуем строку в байты
            byte[] array = new byte[fstream.Length];
            // считываем данные
            fstream.Read(array, 0, array.Length);
            // декодируем байты в строку
            string textFromFile = System.Text.Encoding.Default.GetString(array);
            Console.WriteLine($"Текст из файла: {textFromFile}");
          }
          //удаление файла
          File.Delete($"{path}/note.txt");
          Console.WriteLine("Файл был успешно удалён");
          break;
        case "3":
          
          break;
        case "0":
          Environment.Exit(0);
          break;
      }
        goto Menu;
      }
    }
  }

