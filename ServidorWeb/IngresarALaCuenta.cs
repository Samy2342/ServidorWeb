using MongoDB.Bson;

public class IngresarALaCuenta{
    public ObjectId Id {get;set;}
    public string Correo{get;set;}= string.Empty;
    public string Contrasena{get;set;}= string.Empty;
}

public class RecuperarCuenta {

public string Correo { get; set; } = string.Empty;



}