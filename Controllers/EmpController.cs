using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public IWebHostEnvironment env;

        public EmpController(ApplicationDbContext db,IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        [Route("AddEmp")]
        [HttpPost]
        public IActionResult AddEmp([FromForm]Emp e)
        {
            db.Emps.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [Route("GetEmps")]
        [HttpGet]
        public IActionResult GetEmp() 
        {
            var d = db.Emps.ToList();
            return Ok(d);
        }
        
        [Route("DelEmps/{id}")]
        [HttpDelete]
        public IActionResult DelEmps(int id) 
        {
            var d1 = db.Emps.Find(id);
            var d = db.Emps.Remove(d1);
            db.SaveChanges();
            return Ok("Deleted");
        }
        
        
        [Route("UpdateEmp/{id}")]
        [HttpPatch]
        public IActionResult UpdateEmp(int id,Emp e) 
        {
            e.Id = id;
            db.Emps.Update(e);
            db.SaveChanges();
            return Ok("Deleted");
        }
        
        [Route("AddMultipleEmp")]
        [HttpPost]
        public IActionResult AddMultipleEmp(List<Emp> e) 
        {
            
            db.Emps.AddRange(e);
            db.SaveChanges();
                
            
            return Ok("Added");
        }
        
        
        [Route("DeleteMultipleEmp")]
        [HttpDelete]
        public IActionResult DeleteMultipleEmp(List<int> e) 
        {
           var data=db.Emps.Where(x=>e.Contains(x.Id)).ToList();
            db.RemoveRange(data);
            db.SaveChanges();
            return Ok("Deleted Multiple");
        }
        
        
        
        [Route("UploadFile")]
        [HttpPost]
        public IActionResult UploadFile(IFormFile e) 
        {
            //var path = env.WebRootPath;
            var filepath = "Images/" + e.FileName;
            //var fullpath=Path.Combine(path,filepath);
            FileStream stream = new FileStream(filepath, FileMode.Create);
            e.CopyTo(stream);


            return Ok("Done Upload Successfull");
        }
    }
}
