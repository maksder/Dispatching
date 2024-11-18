using System.Reflection;
using Dispatching.Dal;
using Dispatching.Dal.Persistence.CircuitBoards;
using Dispatching.Dal.Persistence.HistoryEvents;
using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using Dispatching.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddDbContext<WriteDbContext>();
services.AddScoped<ICircuitBoardRepository, CircuitBoardRepository>();
services.AddScoped<IHistoryEventRepository, HistoryEventRepository>();
services.AddScoped<UnitOfWork<WriteDbContext>>();
services.AddMediatR(Assembly.GetExecutingAssembly());
services.AddControllers();
services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
	db.Database.Migrate();
}

app.UseExceptionHandler(errorApp =>
{
	errorApp.Run(ExceptionHandler.HandleAsync);
});
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting()
   .UseEndpoints(t => t.MapControllers());
//app.UseCors(t => t.AllowAnyOrigin());

app.Run();
