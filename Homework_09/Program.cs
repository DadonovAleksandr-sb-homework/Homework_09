using System;
using System.IO;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;


namespace Homework_09
{
    class Program
    {
        private static TelegramBotClient bot;
        static void Main(string[] args)
        {
            // Бот обладает следующим набором функций:
            //     Принимает сообщения и команды от пользователя.
            //     Сохраняет аудиосообщения, картинки и произвольные файлы.
            //     Позволяет пользователю просмотреть список загруженных файлов.
            //     Позволяет скачать выбранный файл.
            //
            // Команды можно делать разные, но среди них должна присутствовать команда /start.
            //
            // Вы можете сделать бота на любую тематику. Например, ваш бот может искать видео на YouTube,
            // выводить курс криптовалют, отображать данные о погоде и так далее.
            //
            // Что оценивается
            //
            // Бот принимает текстовые сообщения.
            //     Бот реагирует на команду /start.
            //     Бот позволяет сохранять на диск изображения, аудио- и другие файлы.
            //     С помощью произвольной команды можно просмотреть список сохранённых файлов и скачать любой из них.
            
            
            string token = "1734825343:AAEHjIFX2yF4bZ3ZWLZJRb8WBl5TTbDWN6U";

            bot = new TelegramBotClient(token);

            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            
            Console.ReadLine();
        }

        private static void MessageListener(object? sender, MessageEventArgs e)
        {
            string text =
                $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
            Console.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            if (e.Message.Type == MessageType.Document)
            {
                Console.WriteLine(e.Message.Document.FileId);
                Console.WriteLine(e.Message.Document.FileName);
                Console.WriteLine(e.Message.Document.FileSize);

                Download(e.Message.Document.FileId, e.Message.Document.FileName);
            }

            if (e.Message.Text == null) return;
            var messageText = e.Message.Text;

            bot.SendTextMessageAsync(e.Message.Chat.Id, $"{messageText}");
        }

        private static async void Download(string fileId, string path)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream("_" + path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();
            
            fs.Dispose();
        }
    }
}