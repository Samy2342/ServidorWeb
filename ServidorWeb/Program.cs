using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(option => option.SerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapGet("/", () => "Hello World!");

app.MapGet("/control-escolar/alumnos", AlumnosRequestHandler.ListarAlumnos);

app.MapPost("/Registro/registrarse", RegistroRequestHandler.Registrarse);

app.MapPost("/OlvidarContrasena", RegistroRequestHandler.Recuperar);

app.MapPost("/Ingresar", UtilizarLaCuentaRequestHandler.Ingresar);

app.MapPost("/categorias/crear", CategoriasRequestHandler.Crear);

app.MapGet("/categorias",CategoriasRequestHandler.Listar);

app.MapGet("/lenguaje/{idCategoria}",LenguajeRequestHanlder.ListarRegistros);

app.MapPost("/lenguaje",LenguajeRequestHanlder.CrearRegistro);

app.MapDelete("/lenguaje/{id}",LenguajeRequestHanlder.Eliminar);

app.MapGet("/lenguaje/buscar", LenguajeRequestHanlder.Buscar);

app.Run();
