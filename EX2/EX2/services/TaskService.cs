using EX2.Repositories;
using EX2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
using EX2.services.Logger;

namespace EX2.services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILoggerService _logger;
        private readonly services.Logger.LoggerFactory _loggerFactory;
        
        public TaskService(ITaskRepository taskRepository, services.Logger.LoggerFactory loggerFactory)
        {
            _taskRepository = taskRepository;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.GetLogger("database");
        }
        public IEnumerable<Tasks> GetTasks()
        {
            _logger.Log("hiiiiiiiiiii");
            return _taskRepository.GetTasks();
        }
        public void addTask(string? Title, string? Date, string? Status, int UserId, int ProjectId)
        {
            Tasks newTask = new Tasks();
            newTask.Title = Title;
            newTask.Date = Date;
            newTask.Status = Status;
            newTask.UserId = UserId;
            newTask.ProjectId = ProjectId;
            _taskRepository.addTask(newTask);
            _logger.Log("Good Morning!!!!");
        }
        public void DeleteTaskById(int id)
        {
            _taskRepository.DeleteTaskById(id);
        }
        public void updateTask(int Id, string? Title, string? Date, string? Status, int ProjectId, int UserId)
        {
            Tasks newTask = new Tasks();
            newTask.Title = Title;
            newTask.Date = Date;
            newTask.Status = Status;
            newTask.ProjectId = ProjectId;
            newTask.UserId = UserId;
            _taskRepository.updateTask(Id,newTask);
        }
        public IEnumerable<Tasks> getTasksByUser(int id)
        {
            var tasks = new List<Tasks>();
            var tasksList = _taskRepository.GetTasks();
            foreach(var t in tasksList)
            {
                if(t.UserId == id)
                {
                    tasks.Add(t);
                }
            }
            return tasks;
        }
        //public Tasks AddTaskWithProject(int Id, string? Title, string? Date, string? Status, int ProjectId)
        //{
        //    Tasks newTask = new Tasks();
        //    newTask.Id = Id;
        //    newTask.Title = Title;
        //    newTask.Date = Date;
        //    newTask.Status = Status;
        //    newTask.ProjectId = ProjectId;
        //    _taskRepository.addTask(newTask);
        //}
    }
}