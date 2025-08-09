using Microsoft.AspNetCore.Mvc;
using Pioneers.Core.Interfaces;
using Pioneers.Core.Models;
using PioneerSolutions.ViewModel;

namespace PioneerSolutions.Controllers;

public class EmployeeController : BaseController
{
    public EmployeeController(IUnitOfWorkRepository _unitOfWork) : base(_unitOfWork)
    {
    }
    public async Task<IActionResult> Index()
    {
        var employees = await _unitOfWork.EmployeeRepository.GetAllWithPropertiesAsync();
        var viewModels = employees.Select(emp => new EmployeeListViewModel
        {
            Id = emp.Id,
            Code = emp.Code,
            Name = emp.Name,
            CustomProperties = emp.PropertyValues.ToDictionary(
                pv => pv.EmployeeProperty.Name,
                pv => FormatPropertyValue(pv.Value, pv.EmployeeProperty.Type)
            )
        }).ToList();

        return View(viewModels);
    }

    public async Task<IActionResult> Create()
    {
        var customProperties = await _unitOfWork.CustomPropertyRepository.GetAllAsync(cp => cp.DropdownOptions);
        var viewModel = new CreateEmployeeViewModel
        {
            CustomProperties = customProperties.Select(cp => new CustomPropertyInputViewModel
            {
                PropertyId = cp.Id,
                PropertyName = cp.Name,
                PropertyType = cp.Type.ToString(),
                IsRequired = cp.IsRequired,
                DropdownOptions = cp.DropdownOptions.Select(o => o.Value).ToList()
            }).ToList()
        };

        return View(viewModel);
    }
   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateEmployeeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var employee = new Employee
            {
                Code = model.Code,
                Name = model.Name
            };

            await _unitOfWork.EmployeeRepository.AddAsync(employee);

            // Add property values
            foreach (var propInput in model.CustomProperties.Where(cp => !string.IsNullOrWhiteSpace(cp.Value)))
            {
                var propertyValue = new EmployeePropertyValue
                {
                    EmployeeId = employee.Id,
                    CustomPropertyId = propInput.PropertyId,
                    Value = propInput.Value
                };
                await _unitOfWork.EmployeePropertyValueRepository.AddAsync(propertyValue);
            }

            //TempData["SuccessMessage"] = "Employee created successfully.";
            return RedirectToAction(nameof(Index));
        }

        var customProperties = await _unitOfWork.CustomPropertyRepository.GetAllAsync(cp => cp.DropdownOptions);
        model.CustomProperties = customProperties.Select(cp => new CustomPropertyInputViewModel
        {
            PropertyId = cp.Id,
            PropertyName = cp.Name,
            PropertyType = cp.Type.ToString(),
            IsRequired = cp.IsRequired,
            DropdownOptions = cp.DropdownOptions.Select(o => o.Value).ToList(),
            Value = model.CustomProperties.FirstOrDefault(p => p.PropertyId == cp.Id)?.Value
        }).ToList();

        return View(model);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _unitOfWork.EmployeeRepository.GetByIdWithPropertiesAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        var allCustomProperties = await _unitOfWork.CustomPropertyRepository.GetAllAsync(cp => cp.DropdownOptions);

        var viewModel = new EmployeeViewModel
        {
            Id = employee.Id,
            Code = employee.Code,
            Name = employee.Name,
            PropertyValues = allCustomProperties.Select(cp => new PropertyValueViewModel
            {
                CustomPropertyId = cp.Id,
                PropertyName = cp.Name,
                PropertyType = cp.Type,
                IsRequired = cp.IsRequired,
                DropdownOptions = cp.DropdownOptions.ToList(),
                Value = employee.PropertyValues.FirstOrDefault(pv => pv.CustomPropertyId == cp.Id)?.Value ?? ""
            }).ToList()
        };

        return View(viewModel);
    }

 
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EmployeeViewModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdWithPropertiesAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Code = model.Code;
            employee.Name = model.Name;

            await _unitOfWork.EmployeeRepository.UpdateAsync(employee);

           
            foreach (var propValue in model.PropertyValues)
            {
                var existingValue = employee.PropertyValues.FirstOrDefault(pv => pv.CustomPropertyId == propValue.CustomPropertyId);

                if (existingValue != null)
                {
                    if (!string.IsNullOrWhiteSpace(propValue.Value))
                    {
                        existingValue.Value = propValue.Value;
                        await _unitOfWork.EmployeePropertyValueRepository.UpdateAsync(existingValue);
                    }
                    else
                    {
                        await _unitOfWork.EmployeePropertyValueRepository.DeleteAsync(existingValue.Id);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(propValue.Value))
                {
                    var newPropertyValue = new EmployeePropertyValue
                    {
                        EmployeeId = employee.Id,
                        CustomPropertyId = propValue.CustomPropertyId,
                        Value = propValue.Value
                    };
                    await _unitOfWork.EmployeePropertyValueRepository.AddAsync(newPropertyValue);
                }
            }
            //TempData["SuccessMessage"] = "Employee updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _unitOfWork.EmployeeRepository.GetByIdWithPropertiesAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        var viewModel = new EmployeeListViewModel
        {
            Id = employee.Id,
            Code = employee.Code,
            Name = employee.Name,
            CustomProperties = employee.PropertyValues.ToDictionary(
                pv => pv.EmployeeProperty.Name,
                pv => FormatPropertyValue(pv.Value, pv.EmployeeProperty.Type)
            )
        };

        return View(viewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _unitOfWork.EmployeeRepository.DeleteAsync(id);
        //TempData["SuccessMessage"] = "Employee deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

    private string FormatPropertyValue(string value, PropertyDataType type)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "";

        return type switch
        {
            PropertyDataType.Date => DateTime.TryParse(value, out var date) ? date.ToString("dd/MM/yyyy") : value,
            PropertyDataType.Boolean => bool.TryParse(value, out var boolValue) ? (boolValue ? "Yes" : "No") : value,
            _ => value
        };
    }
}


