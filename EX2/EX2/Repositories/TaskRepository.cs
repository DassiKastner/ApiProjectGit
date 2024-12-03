
using EX2.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace EX2.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TasksDbContext _context;
        public TaskRepository(TasksDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Tasks> GetTasks()
        {
            return _context.Tasks.ToList();
        }
        public void addTask(Tasks newTask)
        {
            try
            {
                _context.Tasks.Add(newTask);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"אין משתמש/פרויקט במערכת😁😢😢{newTask.UserId}"+ex.Message);
            }
        }

        public void DeleteTaskById(int id)
        {
            Tasks? thisTask = _context.Tasks.Find(id);
            _context.Tasks.Remove(thisTask);
            _context.SaveChanges();

        }

        public void updateTask(int Id,Tasks newTask)
        {
            Tasks? thisTask = _context.Tasks.Find(Id);
            thisTask.Title = newTask.Title;
            thisTask.Date = newTask.Date;
            thisTask.Status = newTask.Status;
            thisTask.ProjectId = newTask.ProjectId;
            thisTask.UserId = newTask.UserId;
            _context.SaveChanges();
        }
    }
}
