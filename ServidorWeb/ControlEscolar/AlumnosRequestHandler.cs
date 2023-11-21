using MongoDB.Bson;
using MongoDB.Driver;

public static class AlumnosRequestHandler {

public static IResult ListarAlumnos() {
    string connectionString = "mongodb+srv://Samuel:SLAMY123@cluster0.qira4r7.mongodb.net/?retryWrites=true&w=majority";
    MongoClient client = new MongoClient(connectionString);
    var collection = client.GetDatabase("ControlEscolar").GetCollection<Alumno>("Alumnos");
    FilterDefinitionBuilder<Alumno> filters = new FilterDefinitionBuilder<Alumno>();
    var list = collection.Find(filters.Empty).ToList();
    return Results.Ok(list);
}
}