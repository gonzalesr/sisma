using System;
using System.ComponentModel.DataAnnotations;


namespace SismaV02.Models
{
    [MetadataType(typeof(BarrioMetadata))]
    public partial class Barrio
    {
    }

    [MetadataType(typeof(CalleMetadata))]
    public partial class Calle
    {
    }

    [MetadataType(typeof(BitacoraMetadata))]
    public partial class Bitacora
    {
    }

    [MetadataType(typeof(CatServicioMetadata))]
    public partial class CatServicio
    {
    }
    [MetadataType(typeof(CobroServicioMetadata))]
    public partial class CobroServicio
    { }

    [MetadataType(typeof(PrecioServicioMetadata))]
    public partial class PrecioServicio
    { }
}