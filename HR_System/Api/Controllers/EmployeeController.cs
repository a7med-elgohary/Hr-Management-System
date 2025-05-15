using AutoMapper;
using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;
using HR_System.RequestClasses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNew([FromForm] EmployeeDto employeeDto)
        {
            if (employeeDto == null)
                return BadRequest("Employee data is required.");

            if (!ModelState.IsValid)
                return BadRequest("Invalid model data.");

            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.AddAsync(employee);
            return Ok(employee);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromForm] EmployeeDto employee )
        {
            //if (id != employee.Id) return BadRequest("ID mismatch");
           
            var existingEmployee = await _employeeRepository.GetByIdAsync(id);
            if (existingEmployee == null)
                return NotFound("Employee not found");
            _mapper.Map(employee, existingEmployee);
            if (employee.file != null && employee.file.Length > 0)
            {
                // تحديد المسار الذي سيتم حفظ الصورة فيه
                var rootPath = Directory.GetCurrentDirectory(); // المسار الأساسي للتطبيق
                var fileDirectory = Path.Combine(rootPath, "wwwroot", "images");

                // التأكد من أن المجلد موجود، وإذا لم يكن موجودًا، قم بإنشائه
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                // تحديد اسم الملف بشكل فريد (اختياري)
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(employee.file.FileName);

                // تحديد المسار الكامل لحفظ الصورة
                var filePath = Path.Combine(fileDirectory, uniqueFileName);

                // حفظ الصورة في المسار المحدد
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await employee.file.CopyToAsync(stream);
                }

                // تعيين الـ URL للصورة في الكائن Employee
                existingEmployee.Url = "~/images/" + uniqueFileName; // URL للصورة relative للـ root
            }
            var success = await _employeeRepository.UpdateAsync(existingEmployee);

            if (!success) return NotFound("Employee not found or update failed"); // Handle failure properly

            return NoContent(); // Success, return HTTP 204
        }

        //[HttpPost]
        //public async Task<ActionResult<Employee>> Create([FromForm] Employee employee)
        //{
            
        //    // Save the photo
        //    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
        //    Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists
        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(employee.Url.FileName);
        //    var filePath = Path.Combine(uploadsFolder, fileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await employee.Photo.CopyToAsync(stream);
        //    }

        //    // Create the employee
        //    var employee = new Employee
        //    {
        //        FullName = employee.FullName,
        //        Email = employee.Email,
        //        Address = employee.Address,
        //        PhoneNumber = employee.PhoneNumber,
        //        JobTitle = employee.JobTitle,
        //        HireDate = employee.HireDate,
        //        NetSalary = employee.NetSalary,
        //        DepartmentId = employee.DepartmentId,
        //        Url = $"/uploads/{fileName}" // Relative path to access later
        //    };

        //    var createdEmployee = await _employeeRepository.AddAsync(employee);
        //    return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _employeeRepository.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var value =  _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }



    }
}
