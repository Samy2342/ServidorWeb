using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using System.Text.RegularExpressions;
public static class LenguajeRequestHanlder{
public static IResult ListarRegistros (string idCategoria){
     var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
     var filter = filterBuilder.Eq(x => x.IdCategoria, idCategoria);
     BaseDatos bd = new BaseDatos();
     var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
     var lista = coleccion.Find (filter).ToList ();
     return Results.Ok(lista. Select(x => new {
     Id = x.Id. ToString(),
    IdCategoria = x.IdCategoria,
    Titulo = x. Titulo,
    Descripcion = x.Descripcion,
    EsVideo = x.EsVideo,
    Url = x.Url
}).ToList());
}
public static IResult CrearRegistro(LenguajeDTO dto) {
     // Validar que el usuario haya capturado todos los registros
       if (string.IsNullOrWhiteSpace(dto.IdCategoria)){
            return Results.BadRequest ("Es necesario la id de la categoria");
        }
             if (string.IsNullOrWhiteSpace(dto.Descripcion)){
            return Results.BadRequest ("Es necesario una descripcion");
        }
                if (string.IsNullOrWhiteSpace(dto.Titulo)){
            return Results.BadRequest ("Es necesario un titulo");
        }
                if (string.IsNullOrWhiteSpace(dto.Url)){
            return Results.BadRequest ("Es necesario un url");
        }
     // Validar que el object id tenga el format válido
    if(!ObjectId. TryParse(dto.IdCategoria, out ObjectId idCategoria)){
         return Results.BadRequest($"El Id de la categoría {dto.IdCategoria} no es válido");
    }
     BaseDatos bd = new BaseDatos();
     // Validar que exista la categoría
     var filterBuilderCategorias = new FilterDefinitionBuilder<CategoriaDbMap>();
     var filterCategoria =filterBuilderCategorias.Eq(x => x.Id, idCategoria);
     var coleccionCategoria=bd.ObtenerColeccion<CategoriaDbMap>("Categorias");
     var categoria = coleccionCategoria.Find(filterCategoria).FirstOrDefault();

    if(categoria == null){
         return Results.NotFound($"No existe una categoría con ID - {dto.IdCategoria}");
    }

     LenguajeDbMap registro = new LenguajeDbMap();
     registro. Titulo = dto.Titulo;
    registro.EsVideo = dto.EsVideo;
    registro.Descripcion = dto.Descripcion;
    registro.Url = dto.Url;
     registro. IdCategoria = dto.IdCategoria;

    var coleccionLenguaje = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
    coleccionLenguaje!.InsertOne(registro);
     return Results.Ok(registro.Id.ToString());
    }
    public static IResult Eliminar(string id){
    if(!ObjectId. TryParse(id, out ObjectId idLenguaje)){
         return Results.BadRequest($"El Id proporcionad ({id}) no es válido");
    }
     BaseDatos bd = new BaseDatos();
     var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
     var filter = filterBuilder.Eq(x => x.Id, idLenguaje);
    var coleccion =bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
     coleccion! .DeleteOne (filter);
     return Results.NoContent();
    }


public static IResult Buscar(string texto){
    var queryExpr = new BsonRegularExpression (new Regex(texto, RegexOptions.IgnoreCase));
    var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
    var filter = filterBuilder.Regex("Ttulo", queryExpr)  |
        filterBuilder.Regex("Descripcion", queryExpr);

        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
        var lista = coleccion.Find(filter).ToList();

        return Results.Ok(lista.Select(x => new {
          Id = x.Id.ToString(),
          IdCategoria = x.IdCategoria,
          Titulo = x.Titulo,
          Descripcion = x.Descripcion,
          EsVideo = x.EsVideo,
          Url = x.Url
        }).ToList());
}
}