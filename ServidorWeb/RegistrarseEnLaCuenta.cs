using MongoDB.Bson;

public class RegistrarseEnLaCuenta {

public string CorreoNuevo { get; set; } = string.Empty;
public string Nombre { get; set; } = string.Empty;
public string ContraseñaNueva { get; set; } = string.Empty;

public ObjectId Id { get; set; } 
}
