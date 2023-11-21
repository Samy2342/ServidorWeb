using System.Runtime.CompilerServices;
using MongoDB.Driver;
public static class RegistroRequestHandler{
public static IResult Registrarse(RegistrarseEnLaCuenta datos){
    if(string .IsNullOrWhiteSpace(datos.Nombre)){
        return Results.BadRequest("El Nombre es Requerido");
    }
    if(string .IsNullOrWhiteSpace(datos.ContraseñaNueva)){
        return Results.BadRequest("La contraseña es requerida");
    }
    if(string .IsNullOrWhiteSpace(datos.CorreoNuevo)){
        return Results.BadRequest("El correo es requerido");
    }

       BaseDatos bd = new BaseDatos();
       var coleccion = bd.ObtenerColeccion<RegistrarseEnLaCuenta>("Usuarios");
       if(coleccion == null){
           throw new Exception ("No existe la coleccion usuarios");
       }
       FilterDefinitionBuilder<RegistrarseEnLaCuenta> filterBuilder = new FilterDefinitionBuilder<RegistrarseEnLaCuenta>();
       var filter = filterBuilder.Eq(x => x.CorreoNuevo, datos.CorreoNuevo);


       RegistrarseEnLaCuenta? usuarioExiste = coleccion.Find(filter).FirstOrDefault();
       if(usuarioExiste != null){
        return Results.BadRequest($"Ya existe un usuario con el correo {datos.CorreoNuevo}");
       }
       coleccion.InsertOne(datos);
       return Results.Ok();
  }
  
    public static IResult Recuperar (RecuperarCuenta datos){
        if(string .IsNullOrWhiteSpace(datos.Correo)){
        return Results.BadRequest("El Correo es requerido");

    }
     BaseDatos bd = new BaseDatos();
       var coleccion = bd.ObtenerColeccion<RegistrarseEnLaCuenta>("Usuarios");
       if(coleccion == null){
           throw new Exception ("No existe la coleccion usuarios");
       }
       FilterDefinitionBuilder<RegistrarseEnLaCuenta> filterBuilder = new FilterDefinitionBuilder<RegistrarseEnLaCuenta>();
     var filter = filterBuilder.Eq(x => x.CorreoNuevo, datos.Correo);
     return Results.Ok();
  }

}


