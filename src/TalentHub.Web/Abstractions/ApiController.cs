using Microsoft.AspNetCore.Mvc;

namespace TalentHub.Web.Abstractions;

[ApiController]
[Route("api/v")] //TODO: add api version
public abstract class ApiController : ControllerBase;
