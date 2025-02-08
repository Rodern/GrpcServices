using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using WeatherService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<WeatherService.Services.WeatherService>();

//const int Port = 50051;
//var server = new Server { 
//    Services = { .BindService(new MyServiceImpl()) }, Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) } }; 
//server.Start(); 

//Console.WriteLine("gRPC server listening on port " + Port); 
//Console.ReadKey();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
