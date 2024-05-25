using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlensePOC;
using VlensePOC.Dtos;
using VlensePOC.Modes;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<VlenseDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("NpgSql"));
});


var app = builder.Build();

app.MapPost("/steps/front", async ([FromBody] Step step, [FromServices] VlenseDbContext dbContext) =>
{
    step.CreateAt = DateTime.UtcNow;
    var entry = dbContext.Steps.Add(step);
    await dbContext.SaveChangesAsync();
    return entry.Entity;
});

app.MapPost("/steps/back", async ([FromBody] Step step, [FromServices] VlenseDbContext dbContext) =>
{
    step.CreateAt = DateTime.UtcNow;
    var entry = dbContext.Steps.Add(step);
    await dbContext.SaveChangesAsync();
    return entry.Entity;
});

app.MapGet("/steps/{parentId}", async ([FromRoute] Guid parentId, [FromServices] VlenseDbContext dbContext) =>
{
    var successSteps = await dbContext.Steps.Where(s => (s.Id == parentId || s.ParentStepId == parentId) && s.IsSuccess).ToListAsync();

    if (successSteps.Count < 1)
    {
        return Results.NotFound(new
        {
            message = "no success steps found"
        });
    }
    
    var frontStep = successSteps?.FirstOrDefault(s => s.StepType == StepType.Front);
    var backStep = successSteps?.FirstOrDefault(s => s.StepType == StepType.Back);

    return Results.Ok(new StepDto
    {
        Id = parentId,
        CreateAt = frontStep?.CreateAt ?? backStep!.CreateAt,
        FirstName = frontStep?.FirstName,
        LastName = frontStep?.LastName,
        JobName = backStep?.JobName,
        NationalId = frontStep?.NationalId,
        IsSuccess = frontStep is { IsSuccess: true } && backStep is { IsSuccess: true },
    });
});

app.Run();