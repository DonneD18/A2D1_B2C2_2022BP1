using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using ToDoListModel.Models;

class Program
{
    static async Task Main(string[] args)
    {
        const string baseUrl = "https://localhost:5001/api";

        // Get all tasks
        await GetAllTasks(baseUrl);

        // Create a new task
        await CreateTask(baseUrl);

        // Get a specific task
        await GetSpecificTask(baseUrl);

        // Update a task
        await UpdateTask(baseUrl);

        // Delete a task
        await DeleteTask(baseUrl);
    }

    static async Task GetAllTasks(string baseUrl)
    {
        using (var client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/ToDoList");
                if (response.IsSuccessStatusCode)
                {
                    var tasks = await response.Content.ReadFromJsonAsync<ToDoTask[]>();
                    Console.WriteLine("All Tasks:");
                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Finished: {task.Finished}");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve tasks. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static async Task CreateTask(string baseUrl)
    {
        using (var client = new HttpClient())
        {
            try
            {
                string description = "New task";
                HttpResponseMessage response = await client.PostAsJsonAsync($"{baseUrl}/ToDoList", new ToDoTask(description));
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Task created successfully. New task ID: {await response.Content.ReadAsAsync<int>()}");
                }
                else
                {
                    Console.WriteLine($"Failed to create task. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static async Task GetSpecificTask(string baseUrl)
    {
        using (var client = new HttpClient())
        {
            try
            {
                int taskId = 1; // Replace with the actual task ID you want to retrieve
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/ToDoList/{taskId}");
                if (response.IsSuccessStatusCode)
                {
                    var task = await response.Content.ReadFromJsonAsync<ToDoTask>();
                    Console.WriteLine($"Task retrieved successfully. ID: {task.Id}, Description: {task.Description}, Finished: {task.Finished}");
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve task. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static async Task UpdateTask(string baseUrl)
    {
        using (var client = new HttpClient())
        {
            try
            {
                int taskId = 1; // Replace with the actual task ID you want to update
                ToDoTask taskToUpdate = new ToDoTask { Id = taskId, Description = "Updated task", Finished = false };
                HttpResponseMessage response = await client.PutAsJsonAsync($"{baseUrl}/ToDoList/{taskId}", taskToUpdate);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Task updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to update task. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static async Task DeleteTask(string baseUrl)
    {
        using (var client = new HttpClient())
        {
            try
            {
                int taskId = 1; // Replace with the actual task ID you want to delete
                HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/ToDoList/{taskId}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to delete task. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

public class ToDoTask
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Finished { get; set; }
}
