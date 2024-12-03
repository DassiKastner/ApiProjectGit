using EX2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EX2.services
{
    public interface ITaskService
    {
        IEnumerable<Tasks> GetTasks();
        void addTask(string? Title, string? Date, string? Status, int UserId, int ProjectId);
        void DeleteTaskById(int id);
        void updateTask(int Id, string? Title, string? Date, string? Status, int ProjectId, int UserId);
        IEnumerable<Tasks> getTasksByUser(int id);
        //IActionResult AddTaskWithProject(int Id, string? Title, string? Date, string? Status, int ProjectId);
    }
}
