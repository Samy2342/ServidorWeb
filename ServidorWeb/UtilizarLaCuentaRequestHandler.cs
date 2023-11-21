 using MongoDB.Driver;

 public static class UtilizarLaCuentaRequestHandler{
 
 public static IResult Ingresar(IngresarALaCuenta datos) {

        if(string.IsNullOrWhiteSpace(datos.Correo)){
            return Results.BadRequest("El correo es requerido");
        }
        if(string.IsNullOrWhiteSpace(datos.Contrasena)){
            return Results.BadRequest("La contraseña es requerida");
        }
         BaseDatos bd = new BaseDatos();
       var coleccion = bd.ObtenerColeccion<IngresarALaCuenta>("Usuarios");
       if(coleccion == null){
           throw new Exception ("No existe la coleccion usuarios");
       }
       FilterDefinitionBuilder<IngresarALaCuenta> filterBuilder = new FilterDefinitionBuilder<IngresarALaCuenta>();
       var filter = filterBuilder.Eq(x => x.Correo, datos.Correo);


       IngresarALaCuenta? usuarioExiste = coleccion.Find(filter).FirstOrDefault();
       if(usuarioExiste == null){
        return Results.BadRequest($"No existe un usuario con el correo ingresado");
       }
        if(usuarioExiste.Contrasena != datos.Contrasena){
            return Results.BadRequest($"La contraseña es incorrecta");
          }
        return Results.Ok("Se ingreso correctamente ala aplicacion");
    }
 }