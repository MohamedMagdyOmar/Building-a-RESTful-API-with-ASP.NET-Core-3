using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
    [Route("api/[controller]")]

    // ApiController attribute is not strictly necessary, but we need it, 
    // because by ading this attribute we are configuring this controller with features
    // and behaviours aimed at improving the development experience when building APIs. 
    // like attrbute routing whci will return automatically 400 bad request if we have bad input
    [ApiController]

    // here we inherit from ControllerBase, we can also inherit from Controller but in this case we are supporting views!,
    // which has no need for API
    // while ControllerBase contains basic functionality that a controller needs, 
    // like access to model state, common methods for returning responses
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
        }
        public IActionResult GetAuthors()
        {
           var authorsFromRepository = _courseLibraryRepository.GetAuthors();
            return new JsonResult(authorsFromRepository);
        }
    }
}
