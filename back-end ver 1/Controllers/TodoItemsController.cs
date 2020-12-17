using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using back_end_ver_1.models;
using System.IO;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;

namespace back_end_ver_1.Controllers
{
    [Route("api/[controller]")]
  
    public class TodoItemsController : Controller
    {
        TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }
        
        
        public IActionResult Index()
        {
            return View(_context.TodoItems.ToList());
        }

        /* //for one file
           [Consumes("application/json", "multipart/form-data")]
           [HttpPost]
           public IActionResult Create(PersonViewModel pvm)
           {

                     TodoItem todoItem = new TodoItem() { Name = pvm.Image.FileName };





                         if (pvm.Image != null)
                       {


                           byte[] imageData = null;



                           // считываем переданный файл в массив байтов
                           using (var binaryReader = new BinaryReader(pvm.Image.OpenReadStream()))
                           {
                               imageData = binaryReader.ReadBytes((int)pvm.Image.Length);
                           }

                       // установка массива байтов
                       todoItem.Image = imageData;
                       }
                       _context.TodoItems.Add(todoItem);
                       _context.SaveChanges();

               return RedirectToAction("Index");
           }
        */
        [Consumes("application/json", "multipart/form-data")]
        [HttpPost]
        public IActionResult UploadFiles(PersonViewModel pvm)
        {


            foreach (var source in Request.Form.Files)
            {


                TodoItem todoItem = new TodoItem() { Name = source.FileName , Author =pvm.Author };
                if (source != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(source.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)source.Length);
                    }

                    // установка массива байтов
                    todoItem.Image = imageData;
                }
                _context.TodoItems.Add(todoItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

       



    }
}
