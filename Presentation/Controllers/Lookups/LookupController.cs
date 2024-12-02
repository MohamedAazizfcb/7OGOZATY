using Application.Dtos.Lookup.Request;
using Domain.Interfaces;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;

public abstract class LookupController: ControllerBase
{
    //private readonly ILookupService _baseService;
    //private readonly IApiResponseFactory _responseFactory;

    //public LookupController(ILookupService baseService, IApiResponseFactory responseFactory)
    //{
    //    _baseService = baseService;
    //    _responseFactory = responseFactory;
    //}

    //public async Task<IActionResult> GetAll()
    //{
    //    var operationResult = await _baseService.GetAllAsync();
    //    return _responseFactory.CreateApiResponse(operationResult);
    //}

    //public async Task<IActionResult> GetById(int id)
    //{
    //    var operationResult = await _baseService.GetByIdAsync(id);
    //    return _responseFactory.CreateApiResponse(operationResult);
    //}

    //public async Task<IActionResult> Create([FromBody] CreateUpdateLookupRequest entity)
    //{
    //    var operationResult = await _baseService.CreateAsync(entity);
    //    return _responseFactory.CreateApiResponse(operationResult);
    //}

    //public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateLookupRequest entity)
    //{
    //    var operationResult = await _baseService.UpdateAsync(id, entity);
    //    return _responseFactory.CreateApiResponse(operationResult);
    //}

    //public async Task<IActionResult> Delete(int id)
    //{
    //    var operationResult = await _baseService.DeleteAsync(id);
    //    return _responseFactory.CreateApiResponse(operationResult);
    //}
}
