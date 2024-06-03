using System.Net.Mime;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Queries;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Services;
using FlexPalPlatform.API.Subscriptions.Interfaces.REST.Resources;
using FlexPalPlatform.API.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FlexPalPlatform.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionsController (ISubscriptionCommandService subscriptionCommandService, ISubscriptionQueryService subscriptionQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionResource resource)
    {
        var createSubscriptionCommand = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        if (subscription is null) return BadRequest();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return CreatedAtAction(nameof(GetSubscriptionById),new {SubscriptionId=subscriptionResource.Id},subscriptionResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var getAllSubscriptionsQuery = new GetAllSubscriptionsQuery();
        var subscriptions = await subscriptionQueryService.Handle(getAllSubscriptionsQuery);
        var subscriptionResources = subscriptions.Select(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(subscriptionResources);
    }

    [HttpGet("{subscriptionId:int}")]
        
    public async Task<IActionResult> GetSubscriptionById(int subscriptionId)
    {
        var getSubscriptionByIdQuery = new GetSubscriptionByIdQuery(subscriptionId);
        var subscription = await subscriptionQueryService.Handle(getSubscriptionByIdQuery);
        if (subscription == null) return NotFound();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(subscriptionResource);
    }
}