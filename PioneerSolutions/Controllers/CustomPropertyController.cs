using Microsoft.AspNetCore.Mvc;
using Pioneers.Core.Interfaces;
using Pioneers.Core.Models;
using PioneerSolutions.ViewModel;

namespace PioneerSolutions.Controllers
{
    public class CustomPropertyController : BaseController
    {
        public CustomPropertyController(IUnitOfWorkRepository _unitOfWork) : base(_unitOfWork)
        {
        }

        public async Task<IActionResult> Index()
        {
            var properties = await _unitOfWork.CustomPropertyRepository.GetAllAsync(cp => cp.DropdownOptions);
            var viewModels = properties.Select(cp => new CustomPropertyViewModel
            {
                Id = cp.Id,
                Name = cp.Name,
                Type = cp.Type,
                IsRequired = cp.IsRequired,
                DropdownOptions = cp.DropdownOptions.ToList()
            }).ToList();

            return View(viewModels);
        }


        // GET: CustomProperty/Create
        public IActionResult Create()
        {
            return View(new CustomPropertyViewModel());
        }

        // POST: CustomProperty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomPropertyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var property = new CustomProperty
                {
                    Name = model.Name,
                    Type = model.Type,
                    IsRequired = model.IsRequired
                };

                await _unitOfWork.CustomPropertyRepository.AddAsync(property);

                // Add dropdown options if it's a dropdown type
                if (model.Type == PropertyDataType.Dropdown && !string.IsNullOrWhiteSpace(model.DropdownOptionsText))
                {
                    var options = model.DropdownOptionsText.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var option in options)
                    {
                        var dropdownOption = new DropdownOption
                        {
                            Value = option.Trim(),
                            CustomPropertyId = property.Id
                        };
                        await _unitOfWork.DropdownOptionRepository.AddAsync(dropdownOption);
                    }
                }

                TempData["SuccessMessage"] = "Custom property created successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: CustomProperty/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var property = await _unitOfWork.CustomPropertyRepository.GetByIdAsync(id, cp => cp.DropdownOptions);
            if (property == null)
            {
                return NotFound();
            }

            var viewModel = new CustomPropertyViewModel
            {
                Id = property.Id,
                Name = property.Name,
                Type = property.Type,
                IsRequired = property.IsRequired,
                DropdownOptions = property.DropdownOptions.ToList(),
                DropdownOptionsText = string.Join(", ", property.DropdownOptions.Select(o => o.Value))
            };

            return View(viewModel);
        }

        // POST: CustomProperty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomPropertyViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var property = await _unitOfWork.CustomPropertyRepository.GetByIdAsync(id, cp => cp.DropdownOptions);
                if (property == null)
                {
                    return NotFound();
                }

                property.Name = model.Name;
                property.Type = model.Type;
                property.IsRequired = model.IsRequired;
             

                await _unitOfWork.CustomPropertyRepository.UpdateAsync(property);

                // Update dropdown options if it's a dropdown type
                if (model.Type == PropertyDataType.Dropdown)
                {
                    // Remove existing options
                    foreach (var existingOption in property.DropdownOptions)
                    {
                        await _unitOfWork.DropdownOptionRepository.DeleteAsync(existingOption.Id);
                    }

                    // Add new options
                    if (!string.IsNullOrWhiteSpace(model.DropdownOptionsText))
                    {
                        var options = model.DropdownOptionsText.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        foreach (var option in options)
                        {
                            var dropdownOption = new DropdownOption
                            {
                                Value = option.Trim(),
                                CustomPropertyId = property.Id
                            };
                            await _unitOfWork.DropdownOptionRepository.AddAsync(dropdownOption);
                        }
                    }
                }

                TempData["SuccessMessage"] = "Custom property updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: CustomProperty/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _unitOfWork.CustomPropertyRepository.GetByIdAsync(id, cp => cp.DropdownOptions);
            if (property == null)
            {
                return NotFound();
            }

            var viewModel = new CustomPropertyViewModel
            {
                Id = property.Id,
                Name = property.Name,
                Type = property.Type,
                IsRequired = property.IsRequired,
                DropdownOptions = property.DropdownOptions.ToList()
            };

            return View(viewModel);
        }

        // POST: CustomProperty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.CustomPropertyRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = "Custom property deleted successfully.";
            return RedirectToAction(nameof(Index));
        }



    }
}
