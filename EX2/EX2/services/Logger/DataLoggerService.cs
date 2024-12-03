using EX2.Models;

namespace EX2.services.Logger
{
    public class DataLoggerService: ILoggerService
    {
        private readonly TasksDbContext _dbContext;
        public DataLoggerService(TasksDbContext context)
        {
            _dbContext = context;
        }
        public void Log(string message)
        {
            try
            {
                //using (StreamWriter writer = new StreamWriter(_filePath, append: true))
                //{
                //    writer.WriteLine($"{DateTime.Now}:{message}");
                //}
                Logger1 l = new Logger1();
                l.logIn = message;
                _dbContext.Logger1.Add(l);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to log message: {ex.Message}");
            }
        }
    }
}
