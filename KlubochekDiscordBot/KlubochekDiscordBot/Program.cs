using Discord;
using Discord.WebSocket;

namespace KlubochekDiscordBot
{
    class Program
    {
        

        static void Main(string[] args)
           => new Program().MainAsync().GetAwaiter().GetResult();



        private async Task MainAsync()
        {
            DiscordSocketClient client = new DiscordSocketClient();
            string path = @"E:\KlubochekDiscordBot\KlubochekDiscordBot\KlubochekDiscordBot\BotToken.txt";
            string token;



            //чтение токена и старт бота;
            using (StreamReader sr = new StreamReader(path))
            {
                token = sr.ReadToEnd().ToString();
            }
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            

            //подписки на ивенты
            client.Log += Client_Log;
            client.MessageReceived += CommandsHandler;


            Console.ReadLine();
        }

        private  Task CommandsHandler(SocketMessage msg)
        {
            switch (msg.Content)
            {
                case "!выдай роль":
                    {
                        msg.Channel.SendMessageAsync("Выдаю гуля!");
                        SocketUser author = msg.Author;
                        break;
                    }
                default:
                    break;
            }
            return Task.CompletedTask;
        }

        private static Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }
        
    }
}
