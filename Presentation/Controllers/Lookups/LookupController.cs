using Domain.Interfaces;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LookupController<T> : ControllerBase where T : class
{
    private readonly ILookupService<T> _baseService;
    private readonly IApiResponseFactory _responseFactory;

    public LookupController(ILookupService<T> baseService, IApiResponseFactory responseFactory)
    {
        _baseService = baseService;
        _responseFactory = responseFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var operationResult = await _baseService.GetAllAsync();
        return _responseFactory.CreateApiResponse(operationResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var operationResult = await _baseService.GetByIdAsync(id);
        return _responseFactory.CreateApiResponse(operationResult);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] T entity)
    {
        var operationResult = await _baseService.CreateAsync(entity);
        return _responseFactory.CreateApiResponse(operationResult);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] T entity)
    {
        var operationResult = await _baseService.UpdateAsync(id, entity);
        return _responseFactory.CreateApiResponse(operationResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var operationResult = await _baseService.DeleteAsync(id);
        return _responseFactory.CreateApiResponse(operationResult);
    }
}
