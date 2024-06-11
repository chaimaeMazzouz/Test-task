using Test_task.Data;
using Test_task.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("CandidateDb");
builder.Services.AddSqlite<CandidateBbContext>(connString);
var app = builder.Build();
app.MapCandidatesEndpoints();

app.Run();
