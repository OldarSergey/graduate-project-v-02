using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocRoute
{
    /// <summary>
    /// ПК
    /// </summary>
    public int KeyRoute { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Владелец (KSM)
    /// </summary>
    public int? KeyUserOwner { get; set; }

    /// <summary>
    /// (Default)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Нименование маршрута
    /// </summary>
    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    public int KeyNotes { get; set; }

    public virtual ICollection<DocProcessTemplate> DocProcessTemplates { get; set; } = new List<DocProcessTemplate>();

    public virtual ICollection<DocRouteDependence> DocRouteDependences { get; set; } = new List<DocRouteDependence>();

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;

    public virtual SSubject? KeyUserOwnerNavigation { get; set; }
}
