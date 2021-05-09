using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoApi.Helpers;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("to-do-tasks")]
    public class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly ILogger<ToDoTasksController> _logger;

        public ToDoTasksController(IToDoTaskRepository toDoTaskRepository, ILogger<ToDoTasksController> logger)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_toDoTaskRepository.Get());
            }
            catch (InvalidOperationException e)
            {
                var error = new ApiError(e.Message);
                return StatusCode(error.StatusCode, error);
            }
        }

        [HttpPost]
        public IActionResult Create(ToDoTaskCreateModel taskData)
        {
            try
            {
                var task = _toDoTaskRepository.Create(taskData);
                return Ok(task);
            }
            catch (InvalidOperationException e)
            {
                var error = new ApiError(e.Message);
                return StatusCode(error.StatusCode, error);
            }
            catch (Exception e)
            {
                string errorMessage = "An unknown error occured while saving a To Do task.";
                string logMessage = errorMessage += $" Error details: {e.Message}";

                _logger.LogError(logMessage);
                var error = new ApiError(errorMessage);

                return StatusCode(error.StatusCode, error);
            }
        }
    }
}