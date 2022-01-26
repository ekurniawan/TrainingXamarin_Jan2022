using BackendWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackendWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private List<Course> courses;

        public CourseController()
        {
            courses = new List<Course>()
            {
                new Course()
                {
                    Id=1,
                    Title ="Xamarin Cross Platform",
                    Description = "Cross Platform Mobile App Dev",
                    Price = 200,
                    Pic = "monkey1.png"
                },
                new Course()
                {
                    Id=2,
                    Title = "Xamarin IOS",
                    Description = "Xamarin IOS",
                    Price = 250,
                    Pic = "aspcore.png"
                }
            };
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return courses;
        }

        [HttpGet("{id}")]
        public Course Get(int id)
        {
            var result = courses.Where(c => c.Id == id).FirstOrDefault();
            return result;
        }

        [HttpGet("GetByTitle")]
        public IEnumerable<Course> Get(string title)
        {
            var results = courses.Where(c => c.Title.Contains(title)).ToList();
            return results;
        }

    }
}
