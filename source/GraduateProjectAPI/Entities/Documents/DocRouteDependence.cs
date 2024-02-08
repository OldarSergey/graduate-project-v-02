using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocRouteDependence
{
    public int KeyRouteDependence { get; set; }

    /// <summary>
    /// Маршрут
    /// </summary>
    public int KeyRoute { get; set; }

    /// <summary>
    /// Класс данных
    /// </summary>
    public int KeyDataClass { get; set; }

    public int Flags { get; set; }

    /// <summary>
    /// Key значения
    /// </summary>
    public int? KeyValue { get; set; }

    /// <summary>
    /// Str значения
    /// </summary>
    public string? Value { get; set; }

    public string? Comment { get; set; }

    public virtual DocRoute KeyRouteNavigation { get; set; } = null!;
}
