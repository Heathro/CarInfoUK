namespace CarInfoUK;

internal class Program
{
    static void Main(string[] args)
    {
        const string databaseToken = "VERY_SECRET_DVLA_ACCESS_KEY";
        const string telegramToken = "VERY_SECRET_TELEGRAM_BOT_TOKEN";

        var database = new Database(databaseToken);
        var bot = new Bot(telegramToken, database);

        Console.ReadLine();
        bot.ShutDown();
    }
}