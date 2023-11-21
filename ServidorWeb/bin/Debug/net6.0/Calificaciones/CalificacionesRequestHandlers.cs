public static class CalificacionesRequestHandlers {
    public static IResult MostrarCalificaciones() { 

    List<CalificacionMateria> list = new List<CalificacionMateria>();

    CalificacionMateria m1 = new CalificacionMateria();
    m1.Calificacion = 10;
    m1.Materia = "Programacion Orientada a Objetos";
    m1.Parcial = 1;
    m1.NumControl = 22328051050235

    CalificacionMateria m2 = new CalificacionMateria();
    m2.Calificacion = 9;
    m2.Materia = "Programacion Orientada a Eventos";
    m2.Parcial = 1;
    m2.NumControl = 22328051050235

    CalificacionMateria m3 = new CalificacionMateria();
    m3.Calificacion = 8;
    m3.Materia = "Geometria";
    m3.Parcial = 1;
    m3.NumControl = 22328051050235

    CalificacionMateria m4 = new CalificacionMateria();
    m4.Calificacion = 7.2;
    m4.Materia = "Biologia";
    m4.Parcial = 1;
    m4.NumControl = 22328051050235

    CalificacionMateria m1 = new CalificacionMateria();
    m1.Calificacion = 9;
    m1.Materia = "Ingles";
    m1.Parcial = 1;
    m1.NumControl = 22328051050235

    CalificacionMateria m1 = new CalificacionMateria();
    m1.Calificacion = 7;
    m1.Materia = "Etica";
    m1.Parcial = 1;
    m1.NumControl = 22328051050235

    CalificacionMateria m1 = new CalificacionMateria();
    m1.Calificacion = 7;
    m1.Materia = "Tutoria";
    m1.Parcial = 1;
    m1.NumControl = 22328051050235

    list.Add(m1);
    list.Add(m2);
    list.Add(m3);
    list.Add(m4);
    list.Add(m5);
    list.Add(m6);
    list.Add(m7);

    return Results.Ok(list);
    
    }
}