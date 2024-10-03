using Microsoft.AspNetCore.Mvc;
using ToDoListModel.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationProgrammingInterfaceToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        // GET: api/<ToDoListController>
        [HttpGet]
        public IEnumerable<ToDoTask> Get()
        {
            return ToDoTask.ReadAll();
        }

        // GET api/<ToDoListController>/5
        [HttpGet("{id}")]
        public ToDoTask Get(int id)
        {
            return ToDoTask.Read(id);
        }

        // POST api/<ToDoListController>
        [HttpPost]
        public void Post([FromBody] string description)
        {
            ToDoTask newtask = new ToDoTask(description);
            newtask.Create();
        }

        // PUT api/<ToDoListController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            ToDoTask finishTask = ToDoTask.Read(id);
            finishTask.FinishTask();
        }

        // DELETE api/<ToDoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ToDoTask deleteTask = ToDoTask.Read(id);
            deleteTask.Delete();
        }
    }
}
