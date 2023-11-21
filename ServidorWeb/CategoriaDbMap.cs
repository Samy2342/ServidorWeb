using MongoDB.Bson;

public class CategoriaDbMap {
    public ObjectId Id { get; set; }
    public string Nombre { get; set; } = String.Empty;
    public string UrlIcono {get; set;} = string.Empty;
}