﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployee.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges: false); 
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee) {
            if (employee is null)
                return BadRequest("EmployerForCreationDto object is null");

            var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);
            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            if (employee is null) return BadRequest("EmployeeForUpdateDto object is null");

            _service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, compTrackChanges: false, empTrackChanges: true);

            return NoContent();


        }
    }
}
