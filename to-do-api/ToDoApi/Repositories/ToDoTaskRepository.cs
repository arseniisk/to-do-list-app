using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ToDoApi.Entities;
using ToDoApi.Helpers;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public interface IToDoTaskRepository
    {
        IEnumerable<ToDoTaskReadModel> Get();
        ToDoTaskReadModel Create(ToDoTaskCreateModel taskData);
    }

    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ApiContext _context;
        private readonly ILogger<ToDoTaskRepository> _logger;

        public ToDoTaskRepository(ApiContext context, ILogger<ToDoTaskRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<ToDoTaskReadModel> Get()
        {
            try
            {
                return _context.ToDoTasks
                    .Where(x => x.IsDeleted == false)
                    .Select(x => new ToDoTaskReadModel(x));
            }
            catch (Exception e)
            {
                string errorMessage = "An error ocured while getting a list of To Do task from the database.";
                LogError(errorMessage, e);

                throw new InvalidOperationException(errorMessage);
            }
        }

        public ToDoTaskReadModel Create(ToDoTaskCreateModel taskData)
        {
            var toDoTask = new ToDoTask()
            {
                Description = taskData.Description,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            try
            {
                _context.ToDoTasks.Add(toDoTask);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                string errorMessage = "An error ocured while saving a To Do task to the database.";
                LogError(errorMessage, e);

                throw new InvalidOperationException(errorMessage);
            }

            return new ToDoTaskReadModel(toDoTask);
        }

        private void LogError(string errorMessage, Exception e)
        {
            string logMessage = errorMessage += $" Error details: {e.Message}";
            _logger.LogError(logMessage);
        }
    }
}
