using Application.Contracts;
using Application.Dtos.Lookup.Request;
using Domain.Entities.Lookups;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;

public abstract class LookupController<T>: ControllerBase where T : Lookup
{
    private readonly ILookupService<T> _lookupService;
    private readonly IApiResponseFactory _responseFactory;

    public LookupController(ILookupService<T> lookupService, IApiResponseFactory responseFactory)
    {
        _lookupService = lookupService;
        _responseFactory = responseFactory;
    }

    public async Task<IActionResult> GetAll()
    {
        var operationResult = await _lookupService.GetAllAsync();
        return _responseFactory.CreateApiResponse(operationResult);
    }

    public async Task<IActionResult> GetById(int id)
    {
        var operationResult = await _lookupService.GetByIdAsync(id);
        return _responseFactory.CreateApiResponse(operationResult);
    }

    public async Task<IActionResult> Create([FromBody] CreateUpdateLookupRequest entity)
    {
        var operationResult = await _lookupService.AddAsync(entity);
        return _responseFactory.CreateApiResponse(operationResult);
    }

    public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateLookupRequest entity)
    {
        var operationResult = await _lookupService.UpdateAsync(id, entity);
        return _responseFactory.CreateApiResponse(operationResult);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var operationResult = await _lookupService.DeleteAsync(id);
        return _responseFactory.CreateApiResponse(operationResult);
    }
}
