using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocPrivacy
{
    public int KeyPrivacy { get; set; }

    public int Flags { get; set; }

    /// <summary>
    /// Разрешения для всех
    /// </summary>
    public int Permissions { get; set; }

    /// <summary>
    /// Разрешения для организации создателя
    /// </summary>
    public int Organitions { get; set; }

    /// <summary>
    /// Разрешения для подразделения создателя
    /// </summary>
    public int Departions { get; set; }

    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    /// <summary>
    /// необходимо только для идентификации при синхронизации БД
    /// </summary>
    public string? Sn { get; set; }

    public string? SysName { get; set; }

    public virtual ICollection<DocList> DocLists { get; set; } = new List<DocList>();

    public virtual ICollection<DocNote> DocNotes { get; set; } = new List<DocNote>();
}
