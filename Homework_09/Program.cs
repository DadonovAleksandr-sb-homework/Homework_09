﻿using System;
using System.IO;


namespace Homework_09
{
    class Program
    {
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

            try
            {
                if (File.Exists("token"))
                {
                    var bot = new MyTelegramBot(File.ReadAllText("token"));         // своя обертка для телеграм-клиента
                    if(bot.Start())
                        Console.WriteLine($"Запуск бота {bot.Name}");    
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                
            Console.ReadLine();
        }
        
    }
}