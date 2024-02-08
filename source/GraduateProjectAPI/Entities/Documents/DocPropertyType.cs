using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocPropertyType
{
    public int KeyPropertyType { get; set; }

    public int? KeyDataClass { get; set; }

    /// <summary>
    /// Имя поля, значение
    /// </summary>
    public int? KeyTableField { get; set; }

    /// <summary>
    /// MRU, Searchable, Editable, Visible
    /// </summary>
    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    public string Name { get; set; } = null!;

    public string? Sn { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public string? SysName { get; set; }

    /// <summary>
    /// *для поиска документов. Имя поля, значение которого ассоциируется
    /// </summary>
    public string? FieldName { get; set; }

    public int? KeyFrame { get; set; }

    public string? FieldExpression { get; set; }

    public string? ValueList { get; set; }

    public virtual ICollection<DocNotePropertyType> DocNotePropertyTypes { get; set; } = new List<DocNotePropertyType>();

    public virtual ICollection<DocPrivateListSearch> DocPrivateListSearches { get; set; } = new List<DocPrivateListSearch>();

    public virtual ICollection<DocProperty> DocProperties { get; set; } = new List<DocProperty>();
}
