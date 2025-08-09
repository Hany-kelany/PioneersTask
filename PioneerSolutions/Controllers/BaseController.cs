using Microsoft.AspNetCore.Mvc;
using Pioneers.Core.Interfaces;


namespace PioneerSolutions.Controllers;
public class BaseController : Controller
{
    protected readonly IUnitOfWorkRepository _unitOfWork;

    public BaseController(IUnitOfWorkRepository unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
