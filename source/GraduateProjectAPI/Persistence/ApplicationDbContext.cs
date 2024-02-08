using System;
using System.Collections.Generic;
using GraduateProjectAPI.Entities.Documents;
using Microsoft.EntityFrameworkCore;

namespace GraduateProjectAPI.Persistence;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocContragent> DocContragents { get; set; }

    public virtual DbSet<DocContragentAccount> DocContragentAccounts { get; set; }

    public virtual DbSet<DocContragentType> DocContragentTypes { get; set; }

    public virtual DbSet<DocImage> DocImages { get; set; }

    public virtual DbSet<DocList> DocLists { get; set; }

    public virtual DbSet<DocNote> DocNotes { get; set; }

    public virtual DbSet<DocNoteContragentType> DocNoteContragentTypes { get; set; }

    public virtual DbSet<DocNoteCounter> DocNoteCounters { get; set; }

    public virtual DbSet<DocNoteOperation> DocNoteOperations { get; set; }

    public virtual DbSet<DocNoteOperationRole> DocNoteOperationRoles { get; set; }

    public virtual DbSet<DocNotePropertyType> DocNotePropertyTypes { get; set; }

    public virtual DbSet<DocNoteRelationType> DocNoteRelationTypes { get; set; }

    public virtual DbSet<DocNoteRole> DocNoteRoles { get; set; }

    public virtual DbSet<DocNoteTable> DocNoteTables { get; set; }

    public virtual DbSet<DocNoteTableDump> DocNoteTableDumps { get; set; }

    public virtual DbSet<DocNoteTableDumpField> DocNoteTableDumpFields { get; set; }

    public virtual DbSet<DocNoteTableField> DocNoteTableFields { get; set; }

    public virtual DbSet<DocOperation> DocOperations { get; set; }

    public virtual DbSet<DocOrigin> DocOrigins { get; set; }

    public virtual DbSet<DocPrivacy> DocPrivacies { get; set; }

    public virtual DbSet<DocPrivateListSearch> DocPrivateListSearches { get; set; }

    public virtual DbSet<DocPrivatePermission> DocPrivatePermissions { get; set; }

    public virtual DbSet<DocPrivateSelection> DocPrivateSelections { get; set; }

    public virtual DbSet<DocProcessRelation> DocProcessRelations { get; set; }

    public virtual DbSet<DocProcessTemplate> DocProcessTemplates { get; set; }

    public virtual DbSet<DocProcessing> DocProcessings { get; set; }

    public virtual DbSet<DocProperty> DocProperties { get; set; }

    public virtual DbSet<DocPropertyType> DocPropertyTypes { get; set; }

    public virtual DbSet<DocRecord> DocRecords { get; set; }

    public virtual DbSet<DocRelation> DocRelations { get; set; }

    public virtual DbSet<DocRelationType> DocRelationTypes { get; set; }

    public virtual DbSet<DocRoute> DocRoutes { get; set; }

    public virtual DbSet<DocRouteDependence> DocRouteDependences { get; set; }

    public virtual DbSet<DocSelection> DocSelections { get; set; }

    public virtual DbSet<DocSupervision> DocSupervisions { get; set; }

    public virtual DbSet<DocTemplateRelation> DocTemplateRelations { get; set; }

    public virtual DbSet<DocVersion> DocVersions { get; set; }

    public virtual DbSet<DocVersionProcessing> DocVersionProcessings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.10.99.1, 1433;Database=DM;User Id=edu_user;Password=student12345;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocContragent>(entity =>
        {
            entity.HasKey(e => e.KeyContragent).HasName("PK_DocContragents_KeyContragent");

            entity.ToTable("Doc_Contragents", tb => tb.HasComment(""));

            entity.HasIndex(e => new { e.KeyContragentType, e.KeyDoc }, "IX_DocContragents_KeyContragentTypeIncludeKeySub");

            entity.HasIndex(e => new { e.KeyContragentType, e.KeySub, e.KeyDoc }, "IX_DocContragents_KeyContragentTypeKeyDocKeySub");

            entity.HasIndex(e => e.KeyDoc, "IX_DocContragents_KeyDoc");

            entity.HasIndex(e => new { e.KeyContragentType, e.KeyDoc }, "IX_DocContragents_KeyDoc_whrKeyContragentType4").HasFilter("([Key_ContragentType]=(4))");

            entity.HasIndex(e => e.KeyDoc, "IX_DocContragents_KeyDoc_whrKeyContragentType5").HasFilter("([Key_ContragentType]=(5))");

            entity.HasIndex(e => new { e.KeyDoc, e.KeyContragentType }, "NonClusteredIndex-20230126-155628").IsDescending(false, true);

            entity.HasIndex(e => new { e.KeyDoc, e.KeyContragentType }, "UI_DocContragents_KeyDocKeyContragentType");

            entity.HasIndex(e => new { e.KeySub, e.KeyDoc, e.Flags, e.KeyContragent }, "_dta_index_Doc_Contragents_17_1534537146__K2_K1_K5_K4").IsUnique();

            entity.Property(e => e.KeyContragent).HasColumnName("Key_Contragent");
            entity.Property(e => e.AsContragentView)
                .HasMaxLength(4000)
                .HasComment("Если задано, в документах вместо информации из субъектов используется эта.");
            entity.Property(e => e.Flags).HasComment("(Default)");
            entity.Property(e => e.KeyContragentType)
                .HasComment("Тип контрагента")
                .HasColumnName("Key_ContragentType");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.KeySub)
                .HasComment("Субъект (KS)")
                .HasColumnName("Key_Sub");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.View)
                .HasMaxLength(2000)
                .HasComputedColumnSql("([dbo].[Doc_ContragentView]([Key_Contragent]))", false)
                .HasComment("Универсальное полное представление записи для использования в метаданных");

            entity.HasOne(d => d.KeyContragentTypeNavigation).WithMany(p => p.DocContragents)
                .HasForeignKey(d => d.KeyContragentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocContragents_KeyContragentType");

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocContragents)
                .HasForeignKey(d => d.KeyDoc)
                .HasConstraintName("Contragents_KeyDoc_CD");
        });

        modelBuilder.Entity<DocContragentAccount>(entity =>
        {
            entity.HasKey(e => e.KeyContragentAccount);

            entity.ToTable("Doc_ContragentAccounts", tb => tb.HasComment(""));

            entity.HasIndex(e => e.KeyContragent, "IX_DocContragentAccounts_KeyDocContragent");

            entity.Property(e => e.KeyContragentAccount).HasColumnName("Key_ContragentAccount");
            entity.Property(e => e.Flags).HasComment("(Default)");
            entity.Property(e => e.KeyAccount)
                .HasComment("Счет контрагента")
                .HasColumnName("Key_Account");
            entity.Property(e => e.KeyContragent)
                .HasComment("Контрагент документа")
                .HasColumnName("Key_Contragent");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyContragentNavigation).WithMany(p => p.DocContragentAccounts)
                .HasForeignKey(d => d.KeyContragent)
                .HasConstraintName("DocContragentAccounts_KeyContragent_CD");
        });

        modelBuilder.Entity<DocContragentType>(entity =>
        {
            entity.HasKey(e => e.KeyContragentType).HasName("PK_S_ContragentTypes");

            entity.ToTable("Doc_ContragentTypes");

            entity.Property(e => e.KeyContragentType).HasColumnName("Key_ContragentType");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Sn)
                .HasMaxLength(50)
                .HasColumnName("SN");
            entity.Property(e => e.SysName)
                .HasMaxLength(50)
                .HasComputedColumnSql("([SN])", false);
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<DocImage>(entity =>
        {
            entity.HasKey(e => e.KeyImage).HasName("PK_Doc_Image");

            entity.ToTable("Doc_Images", tb => tb.HasComment(""));

            entity.HasIndex(e => e.CheckOuted, "IX_DocImages_CheckOuted");

            entity.HasIndex(e => e.KeyDoc, "IX_DocImages_KeyDoc");

            entity.HasIndex(e => e.VersionArchive, "IX_DocImages_VersionArchive");

            entity.HasIndex(e => e.Md5sum, "IX_DocImages_md5sum");

            entity.Property(e => e.KeyImage)
                .HasComment("PK")
                .HasColumnName("Key_Image");
            entity.Property(e => e.CheckOuted)
                .HasComment("Время, когда файл был взят на редактирование")
                .HasColumnType("datetime");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.FileExtension)
                .HasMaxLength(8)
                .HasComputedColumnSql("(CONVERT([nvarchar](8),reverse(substring(reverse([FileName]),(1),charindex('.',reverse([FileName])))),0))", true);
            entity.Property(e => e.FileName)
                .HasMaxLength(250)
                .HasComment("Имя файла");
            entity.Property(e => e.FileSize).HasComputedColumnSql("(CONVERT([bigint],isnull(datalength([Image]),(0)),0))", true);
            entity.Property(e => e.Flags).HasComment("(Application)");
            entity.Property(e => e.Image)
                .HasComment("Файл вложения")
                .HasColumnType("image");
            entity.Property(e => e.KeyArchive).HasColumnName("Key_Archive");
            entity.Property(e => e.KeyAttachmentType).HasColumnName("Key_AttachmentType");
            entity.Property(e => e.KeyCheckOuter)
                .HasComment("Кто взял файл на редактирование")
                .HasColumnName("Key_CheckOuter");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.Md5sum)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("md5sum");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .HasComment("Наименование вложения");
            entity.Property(e => e.Serial)
                .HasMaxLength(50)
                .HasComment("Порядковый номер");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VersionArchive)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocImages)
                .HasForeignKey(d => d.KeyDoc)
                .HasConstraintName("DocImage_KeyDoc_CD");
        });

        modelBuilder.Entity<DocList>(entity =>
        {
            entity.HasKey(e => e.KeyDoc);

            entity.ToTable("Doc_List", tb =>
                {
                    tb.HasComment("");
                    tb.HasTrigger("trDocListFixRoute");
                });

            entity.HasIndex(e => new { e.KeyDoc, e.KeyState }, "IDX_Doc_List_Key_State");

            entity.HasIndex(e => e.Date, "IX_DocList_Date");

            entity.HasIndex(e => e.Date, "IX_DocList_DateInclude");

            entity.HasIndex(e => e.Flags, "IX_DocList_FlagsIncludeRestrictions");

            entity.HasIndex(e => new { e.Date, e.Flags, e.KeyDoc, e.KeyNote, e.KeyUsers, e.Restrictions }, "IX_DocList_Include").IsUnique();

            entity.HasIndex(e => e.KeyDoc, "IX_DocList_KeyDoc_Include_Number").IsUnique();

            entity.HasIndex(e => e.KeyDoc, "IX_DocList_KeyDoc_Include_RegNumDoc").IsUnique();

            entity.HasIndex(e => e.KeyNote, "IX_DocList_KeyNote").HasFillFactor(80);

            entity.HasIndex(e => e.KeyNote, "IX_DocList_KeyNoteInclude");

            entity.HasIndex(e => new { e.KeyNote, e.KeyDoc }, "IX_DocList_KeyNoteKeyDocInclude").IsUnique();

            entity.HasIndex(e => new { e.KeyNote, e.KeyDoc }, "IX_DocList_KeyNoteKeyDocIncludeDate").IsUnique();

            entity.HasIndex(e => e.KeyParent, "IX_DocList_KeyParent");

            entity.HasIndex(e => e.KeyUsers, "IX_DocList_KeyUser").HasFillFactor(80);

            entity.HasIndex(e => new { e.KeyUsers, e.Flags, e.Restrictions }, "IX_DocList_KeyUsersInclude");

            entity.HasIndex(e => e.RegNumDoc, "IX_DocList_Regnum");

            entity.HasIndex(e => new { e.KeyNote, e.Restrictions, e.KeyDoc, e.Flags }, "Idx_DocList_KeyNoteRestrKeyDocFlags").IsUnique();

            entity.HasIndex(e => new { e.KeyDoc, e.Date, e.KeyNote }, "_dta_index_Doc_List_5_2141719178__K1_K9_K3_4_11").IsUnique();

            entity.Property(e => e.KeyDoc)
                .HasComment("")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Дата регистрации в ИСУП")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Фактическая дата документа (по умолчанию = Created).")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Finished)
                .HasComment("Дата окончания действия документа")
                .HasColumnType("datetime");
            entity.Property(e => e.Flags).HasComment("Набор бинарных флагов. Младшие два байта зарезервированы документооборотом, старшие два байта предоставлены подсистемам.");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyParent)
                .HasComment("иерархия")
                .HasColumnName("Key_Parent");
            entity.Property(e => e.KeyPrivacy)
                .HasDefaultValueSql("([dbo].[Doc_GetDefaultPrivacy]())")
                .HasComment("Гриф секретности")
                .HasColumnName("Key_Privacy");
            entity.Property(e => e.KeyState)
                .HasComment("Состояние документа")
                .HasColumnName("Key_State");
            entity.Property(e => e.KeySub)
                .HasComment("... НЕ ПОДДЕРЖИВАЕТСЯ... ??")
                .HasColumnName("Key_Sub");
            entity.Property(e => e.KeyUsers)
                .HasComment("Создатель (KSM)")
                .HasColumnName("Key_Users");
            entity.Property(e => e.NumDoc)
                .HasComment("... НЕ ПОДДЕРЖИВАЕТСЯ... ??")
                .HasColumnName("Num_Doc");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComputedColumnSql("([RegNum_Doc])", false);
            entity.Property(e => e.RegNumDoc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Внутренний рег.№")
                .HasColumnName("RegNum_Doc");
            entity.Property(e => e.Restrictions).HasComment("Ограничения сверху");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.View)
                .HasMaxLength(500)
                .HasComputedColumnSql("([dbo].[Doc_View]([Key_Doc]))", false)
                .HasComment("Вычисляемое поле. Собирает представление записи.");

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocLists)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocList_KeyNote");

            entity.HasOne(d => d.KeyParentNavigation).WithMany(p => p.InverseKeyParentNavigation)
                .HasForeignKey(d => d.KeyParent)
                .HasConstraintName("DocList_KeyParent");

            entity.HasOne(d => d.KeyPrivacyNavigation).WithMany(p => p.DocLists)
                .HasForeignKey(d => d.KeyPrivacy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocList_KeyPrivacy");
        });

        modelBuilder.Entity<DocNote>(entity =>
        {
            entity.HasKey(e => e.KeyNote).HasName("PK_DocNotes");

            entity.ToTable("Doc_Notes", tb => tb.HasComment(""));

            entity.HasIndex(e => e.KeyNote, "IXI_DocNotes_Name");

            entity.HasIndex(e => e.Sn, "IX_DocNotes_SN");

            entity.HasIndex(e => e.Name, "UI_DocNotes_Name").IsUnique();

            entity.HasIndex(e => new { e.KeyNote, e.Sn }, "_dta_index_Doc_Notes_5_1848302290__K1_K15_8");

            entity.HasIndex(e => new { e.KeyNote, e.Sn, e.Name }, "_dta_index_Doc_Notes_5_1848302290__K1_K15_K8");

            entity.HasIndex(e => new { e.Name, e.KeyNote }, "_dta_index_Doc_Notes_5_1848302290__K8_K1_15");

            entity.Property(e => e.KeyNote)
                .HasComment("")
                .HasColumnName("Key_Note");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CreatorOwns).HasComputedColumnSql("([dbo].[Doc_GetNoteOrigins]([Key_Note],'CreatorOwns'))", false);
            entity.Property(e => e.FinishCaption)
                .HasMaxLength(100)
                .HasComment("Заголовок для поля \"Дата окончания\" в карточке документов вида.");
            entity.Property(e => e.FinishHint)
                .HasMaxLength(1000)
                .HasComment("Всплывающая подсказка для поля \"Дата окончания\" в карточке документов вида.");
            entity.Property(e => e.FormDoc)
                .HasComment("Шаблон")
                .HasColumnType("image");
            entity.Property(e => e.FormDocFileName)
                .HasMaxLength(250)
                .HasComment("Имя файла шаблона");
            entity.Property(e => e.InstanceDefault).HasComputedColumnSql("([dbo].[Doc_GetNoteOrigins]([Key_Note],'InstanceDefault'))", false);
            entity.Property(e => e.InstanceRequired).HasComputedColumnSql("([dbo].[Doc_GetNoteOrigins]([Key_Note],'InstanceRequired'))", false);
            entity.Property(e => e.KeyForm)
                .HasComment("Форма-реализатор структурированного документа.")
                .HasColumnName("Key_Form");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyPrivacy)
                .HasDefaultValueSql("([dbo].[Doc_GetDefaultPrivacy]())")
                .HasComment("Гриф секретности по умолчанию для документов этого вида")
                .HasColumnName("Key_Privacy");
            entity.Property(e => e.KeyStateArhive)
                .HasComment("Статус при сдаче документа в архив")
                .HasColumnName("Key_StateArhive");
            entity.Property(e => e.KeyStateCancel)
                .HasComment("Статус при отклонении документа")
                .HasColumnName("Key_StateCancel");
            entity.Property(e => e.KeyStateNew)
                .HasComment("Статус при создании документа")
                .HasColumnName("Key_StateNew");
            entity.Property(e => e.KeyStatePlay)
                .HasComment("Статус при запуске документа")
                .HasColumnName("Key_StatePlay");
            entity.Property(e => e.KeyStateStop)
                .HasComment("Статус при остановке документа")
                .HasColumnName("Key_StateStop");
            entity.Property(e => e.KeyWizard)
                .HasComment("Форма мастер создания документа")
                .HasColumnName("Key_Wizard");
            entity.Property(e => e.LimitedFunction).HasMaxLength(150);
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasComment("");
            entity.Property(e => e.NameE).HasMaxLength(100);
            entity.Property(e => e.NameK)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Краткое наим. (используется при генерации №док-та)")
                .HasColumnName("Name_K");
            entity.Property(e => e.NumberDigits)
                .HasDefaultValue(4)
                .HasComment("Количество цифр в порядковом номере документа");
            entity.Property(e => e.NumberMask)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OnInsert)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Наименование хранимой процедуры SQL, вызываемой при регистрации документа посредством SQL API.");
            entity.Property(e => e.OnPermissions)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Наименование хранимой процедуры SQL, вызываемой при расчёте разрешений к документу, предоставляемых подсистемой.");
            entity.Property(e => e.OnUpdate)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Наименование хранимой процедуры SQL, вызываемой при обновлении Doc_List посредством UI.");
            entity.Property(e => e.PopupMenu)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Наименование компонента TPopupMenu, предоставляющего характерный контекст документов вида");
            entity.Property(e => e.Restrictions).HasComment("Ограничение сверху для создаваемых документов.");
            entity.Property(e => e.Sn)
                .HasMaxLength(50)
                .HasComment("Системное имя вида документа")
                .HasColumnName("SN");
            entity.Property(e => e.StartCaption)
                .HasMaxLength(100)
                .HasComment("Заголовок для поля \"Дата начала\" в карточке документов вида.");
            entity.Property(e => e.StartHint)
                .HasMaxLength(1000)
                .HasComment("Всплывающая подсказка для поля \"Дата начала\" в карточке документов вида.");
            entity.Property(e => e.StoredTakes)
                .HasComputedColumnSql("([dbo].[Doc_GetNoteOrigins]([Key_Note],'StoredTakes'))", false)
                .HasComment("Ограничения архивного документа");
            entity.Property(e => e.SysName)
                .HasMaxLength(50)
                .HasComputedColumnSql("([SN])", false);

            entity.HasOne(d => d.KeyPrivacyNavigation).WithMany(p => p.DocNotes)
                .HasForeignKey(d => d.KeyPrivacy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNotes_KeyPrivacy");
        });

        modelBuilder.Entity<DocNoteContragentType>(entity =>
        {
            entity.HasKey(e => e.KeyNoteContragentType).HasName("PK_DocNoteContragentTypes");

            entity.ToTable("Doc_NoteContragentTypes");

            entity.HasIndex(e => new { e.KeyNote, e.KeyContragentType }, "UI_DocNoteContragentTypes_Keys").IsUnique();

            entity.Property(e => e.KeyNoteContragentType).HasColumnName("Key_NoteContragentType");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.Flags).HasComment("(Caption, Unique)");
            entity.Property(e => e.KeyClass)
                .HasComment("Класс субъекта, выступающего в качестве контрагента. Если не указывать - значит допускается любой класс.")
                .HasColumnName("Key_Class");
            entity.Property(e => e.KeyClassView).HasColumnName("Key_ClassView");
            entity.Property(e => e.KeyContragentType)
                .HasComment("Тип контрагента")
                .HasColumnName("Key_ContragentType");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyContragentTypeNavigation).WithMany(p => p.DocNoteContragentTypes)
                .HasForeignKey(d => d.KeyContragentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteContragentTypes_KeyContragentType");

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocNoteContragentTypes)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteContragentTypes_KeyNote");
        });

        modelBuilder.Entity<DocNoteCounter>(entity =>
        {
            entity.HasKey(e => e.KeyNoteCounter);

            entity.ToTable("Doc_NoteCounters");

            entity.HasIndex(e => new { e.KeyNote, e.KeyDepartment }, "UI_DocNoteCounters_Keys").IsUnique();

            entity.Property(e => e.KeyNoteCounter).HasColumnName("Key_NoteCounter");
            entity.Property(e => e.Counter).HasComment("Значение счетчика");
            entity.Property(e => e.KeyDepartment)
                .HasComment("Подразделение (KSM)")
                .HasColumnName("Key_Department");
            entity.Property(e => e.KeyNote)
                .HasComputedColumnSql("([Key_Notes])", false)
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComment("Вид документа")
                .HasColumnName("Key_Notes");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNotesNavigation).WithMany(p => p.DocNoteCounters)
                .HasForeignKey(d => d.KeyNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteCounters_KeyNote");
        });

        modelBuilder.Entity<DocNoteOperation>(entity =>
        {
            entity.HasKey(e => e.KeyNoteOperation).HasName("PK_DocNoteOperations");

            entity.ToTable("Doc_NoteOperations");

            entity.HasIndex(e => e.MaxDelay, "IX_DocNoteOperations_MaxDelay");

            entity.HasIndex(e => new { e.KeyNote, e.KeyOperation }, "UI_DocNoteOperations_Keys").IsUnique();

            entity.Property(e => e.KeyNoteOperation).HasColumnName("Key_NoteOperation");
            entity.Property(e => e.ChecksumFn)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComputedColumnSql("([OnChecksum])", false)
                .HasColumnName("ChecksumFN");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CommentOnConfirm).HasMaxLength(50);
            entity.Property(e => e.CommentOnDecline).HasMaxLength(50);
            entity.Property(e => e.DelayProcedure)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Flags).HasComment("(CommentRequired, Controlled, Required, SelectionAllowed, Unique)");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyOperation)
                .HasComment("Действие")
                .HasColumnName("Key_Operation");
            entity.Property(e => e.MaxDelay).HasDefaultValue(0);
            entity.Property(e => e.OnChecksum)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Наименование функции, с помощью котрой будет расчитываться контрольная сумма по документу при выполнении этого действия.");
            entity.Property(e => e.OnConfirm)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Наименование хранимой процедуры SQL, вызываемой при выполнении действия посредством SQL API.");
            entity.Property(e => e.OnDecline)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Наименование хранимой процедуры SQL, вызываемой при отклонении действия посредством SQL API.");
            entity.Property(e => e.Permissions).HasComment("Разрешения по умолчанию");
            entity.Property(e => e.Restrictions).HasComment("Накладываемые ограничения");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocNoteOperations)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteOperations_KeyNote");

            entity.HasOne(d => d.KeyOperationNavigation).WithMany(p => p.DocNoteOperations)
                .HasForeignKey(d => d.KeyOperation)
                .HasConstraintName("DocNoteOperations_KeyOperation_CD");
        });

        modelBuilder.Entity<DocNoteOperationRole>(entity =>
        {
            entity.HasKey(e => e.KeyNoteOperationRole).HasName("PK_DocNoteOperationRoles");

            entity.ToTable("Doc_NoteOperationRoles");

            entity.HasIndex(e => new { e.KeyNoteOperation, e.KeyRole }, "UI_DocNoteOperationRoles_Keys").IsUnique();

            entity.Property(e => e.KeyNoteOperationRole).HasColumnName("Key_NoteOperationRole");
            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.Flags).HasComment("Confirming, Declining");
            entity.Property(e => e.KeyNoteOperation)
                .HasComment("Действие")
                .HasColumnName("Key_NoteOperation");
            entity.Property(e => e.KeyRole)
                .HasComment("Роль, позволяющая Flags")
                .HasColumnName("Key_Role");

            entity.HasOne(d => d.KeyNoteOperationNavigation).WithMany(p => p.DocNoteOperationRoles)
                .HasForeignKey(d => d.KeyNoteOperation)
                .HasConstraintName("DocNoteOperationRoles_KeyNoteOperation_CD");
        });

        modelBuilder.Entity<DocNotePropertyType>(entity =>
        {
            entity.HasKey(e => e.KeyNotePropertyType).HasName("PK_DocNotePropertyTypes");

            entity.ToTable("Doc_NotePropertyTypes");

            entity.HasIndex(e => new { e.KeyNote, e.KeyPropertyType }, "UI_DocNotePropertyTypes_Keys").IsUnique();

            entity.Property(e => e.KeyNotePropertyType).HasColumnName("Key_NotePropertyType");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.DefValue).HasColumnType("ntext");
            entity.Property(e => e.KeyDefValue).HasColumnName("Key_DefValue");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyPropertyType)
                .HasComment("Вид свойства")
                .HasColumnName("Key_PropertyType");
            entity.Property(e => e.Origin).HasComment("Оригинальное разрешение к документу, необходимое для редактирования этого свойства. 0 - разрешений не требуется.");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocNotePropertyTypes)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNotePropertyTypes_KeyNote");

            entity.HasOne(d => d.KeyPropertyTypeNavigation).WithMany(p => p.DocNotePropertyTypes)
                .HasForeignKey(d => d.KeyPropertyType)
                .HasConstraintName("NotePropertyTypes_KeyPropertyType_CD");
        });

        modelBuilder.Entity<DocNoteRelationType>(entity =>
        {
            entity.HasKey(e => e.KeyNoteRelationType).HasName("PK_DocNoteRelations");

            entity.ToTable("Doc_NoteRelationTypes");

            entity.HasIndex(e => new { e.KeyNote, e.KeyRelationType }, "UI_DocNoteRelationTypes_Keys").IsUnique();

            entity.Property(e => e.KeyNoteRelationType).HasColumnName("Key_NoteRelationType");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyRelationType)
                .HasComment("Тип отношения")
                .HasColumnName("Key_RelationType");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocNoteRelationTypes)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteRelationTypes_KeyNote");

            entity.HasOne(d => d.KeyRelationTypeNavigation).WithMany(p => p.DocNoteRelationTypes)
                .HasForeignKey(d => d.KeyRelationType)
                .HasConstraintName("NoteRelationTypes_KeyRelationType_CD");
        });

        modelBuilder.Entity<DocNoteRole>(entity =>
        {
            entity.HasKey(e => e.KeyNoteRole);

            entity.ToTable("Doc_NoteRoles");

            entity.HasIndex(e => new { e.KeyNote, e.KeyRole }, "UI_DocNoteRoles_Keys").IsUnique();

            entity.Property(e => e.KeyNoteRole).HasColumnName("Key_NoteRole");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.Flags).HasComment("(CreationRequired, Unrestricted)");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyRole)
                .HasComment("Роль")
                .HasColumnName("Key_Role");
            entity.Property(e => e.Permissions).HasComment("Разрешения, предоставляемые ролью к документам вида.");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocNoteRoles)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteRoles_KeyNote");
        });

        modelBuilder.Entity<DocNoteTable>(entity =>
        {
            entity.HasKey(e => e.KeyNoteTable).HasName("PK_DocNoteTables");

            entity.ToTable("Doc_NoteTables");

            entity.Property(e => e.KeyNoteTable).HasColumnName("Key_NoteTable");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.ImageIndex).HasComment("Индекс ассоциируемой картинки");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasComment("Наименование характерной таблицы");
            entity.Property(e => e.Origin).HasComment("Оригинальное разрешение к документу, необходимое для редактирования табличных данных.");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocNoteTables)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteTables_KeyNote");
        });

        modelBuilder.Entity<DocNoteTableDump>(entity =>
        {
            entity.HasKey(e => e.KeyNoteTableDump).HasName("PK_Doc_NoteTableExports");

            entity.ToTable("Doc_NoteTableDumps");

            entity.HasIndex(e => new { e.KeyNoteTable, e.KeyTable }, "UI_DocNoteTableDumps_Keys").IsUnique();

            entity.Property(e => e.KeyNoteTableDump).HasColumnName("Key_NoteTableDump");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.KeyNoteTable)
                .HasComment("Характерная таблица")
                .HasColumnName("Key_NoteTable");
            entity.Property(e => e.KeyTable)
                .HasComment("Конечная таблица, в которую будет осуществлён экспорт.")
                .HasColumnName("Key_Table");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Origin).HasComment("Разрешения, необходимые к документу, чтобы иметь возможность произвести выгрузку.");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNoteTableNavigation).WithMany(p => p.DocNoteTableDumps)
                .HasForeignKey(d => d.KeyNoteTable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteTableDumps_KeyNoteTable");
        });

        modelBuilder.Entity<DocNoteTableDumpField>(entity =>
        {
            entity.HasKey(e => e.KeyNoteTableDumpField).HasName("PK_Doc_NoteTableExportFields");

            entity.ToTable("Doc_NoteTableDumpFields");

            entity.HasIndex(e => new { e.KeyNoteTableDump, e.KeyDestinationField }, "UI_DocNoteTableDumpFields_Keys").IsUnique();

            entity.Property(e => e.KeyNoteTableDumpField).HasColumnName("Key_NoteTableDumpField");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.DefValue)
                .HasMaxLength(1000)
                .HasComment("Текст значения по умолчанию");
            entity.Property(e => e.Flags).HasComment("(DefIfNull)");
            entity.Property(e => e.KeyDefValue)
                .HasComment("Ключ значения по умолчанию")
                .HasColumnName("Key_DefValue");
            entity.Property(e => e.KeyDestinationField)
                .HasComment("Поле из конечной таблицы, в котрое будут записаны данные")
                .HasColumnName("Key_DestinationField");
            entity.Property(e => e.KeyNoteTableDump).HasColumnName("Key_NoteTableDump");
            entity.Property(e => e.KeySourceField)
                .HasComment("Поле характерной таблицы, из которого будут взяты данные для перекачки в конечную таблицу. Имеет приоритет перед DefValue.")
                .HasColumnName("Key_SourceField");
            entity.Property(e => e.KeySourceProperty)
                .HasComment("Характерное свойство документа-источник")
                .HasColumnName("Key_SourceProperty");

            entity.HasOne(d => d.KeyNoteTableDumpNavigation).WithMany(p => p.DocNoteTableDumpFields)
                .HasForeignKey(d => d.KeyNoteTableDump)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteTableDumpFields_KeyNoteTableDump");

            entity.HasOne(d => d.KeySourceFieldNavigation).WithMany(p => p.DocNoteTableDumpFields)
                .HasForeignKey(d => d.KeySourceField)
                .HasConstraintName("DocNoteTableDumpFields_KeySourceField");

            entity.HasOne(d => d.KeySourcePropertyNavigation).WithMany(p => p.DocNoteTableDumpFields)
                .HasForeignKey(d => d.KeySourceProperty)
                .HasConstraintName("DocNoteTableDumpFields_KeySourceProperty");
        });

        modelBuilder.Entity<DocNoteTableField>(entity =>
        {
            entity.HasKey(e => e.KeyNoteTableField);

            entity.ToTable("Doc_NoteTableFields");

            entity.Property(e => e.KeyNoteTableField).HasColumnName("Key_NoteTableField");
            entity.Property(e => e.Caption)
                .HasMaxLength(500)
                .HasComment("Заголовок столбца в таблице (по-русски)");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.DefValue)
                .HasMaxLength(500)
                .HasComment("Текст значения по умолчанию для этого поля");
            entity.Property(e => e.DisplayOrder).HasComment("Порядок отображения в таблице (по умолчанию)");
            entity.Property(e => e.Flags).HasComment("(Copied)");
            entity.Property(e => e.Hint)
                .HasMaxLength(500)
                .HasComment("Всплывающая подсказка для заголовка столбца");
            entity.Property(e => e.KeyDataClass)
                .HasComment("Класс данных, хранимых в поле")
                .HasColumnName("Key_DataClass");
            entity.Property(e => e.KeyDefValue)
                .HasComment("Ключ значения по умолчанию для этого поля")
                .HasColumnName("Key_DefValue");
            entity.Property(e => e.KeyField)
                .HasComment("Поле таблицы Doc_Tables, в котором будет храниться ключ данных.")
                .HasColumnName("Key_Field");
            entity.Property(e => e.KeyNoteTable)
                .HasComment("Вид характерной таблицы")
                .HasColumnName("Key_NoteTable");
            entity.Property(e => e.KeyValueField)
                .HasComment("Поле таблицы Doc_Tables, в котором будет храниться значение данных.")
                .HasColumnName("Key_ValueField");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyNoteTableNavigation).WithMany(p => p.DocNoteTableFields)
                .HasForeignKey(d => d.KeyNoteTable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocNoteTableFields_KeyNoteTable");
        });

        modelBuilder.Entity<DocOperation>(entity =>
        {
            entity.HasKey(e => e.KeyOperation);

            entity.ToTable("Doc_Operations");

            entity.Property(e => e.KeyOperation)
                .HasComment("")
                .HasColumnName("Key_Operation");
            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.CommentOnConfirm)
                .HasMaxLength(50)
                .HasComment("Автокомментарий при выполнении действия");
            entity.Property(e => e.CommentOnDecline)
                .HasMaxLength(50)
                .HasComment("Автокомментарий при отклонении действия");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Наименование операции");
            entity.Property(e => e.ReportName)
                .HasMaxLength(50)
                .HasComment("Наименование операции в отчёте");
            entity.Property(e => e.Sn)
                .HasMaxLength(100)
                .HasColumnName("SN");
            entity.Property(e => e.SysName)
                .HasMaxLength(100)
                .HasComputedColumnSql("([SN])", false);
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<DocOrigin>(entity =>
        {
            entity.HasKey(e => e.KeyOrigin);

            entity.ToTable("Doc_Origins");

            entity.HasIndex(e => new { e.KeyNote, e.Origin }, "UI_DocOrigins_KeyNoteOrigin").IsUnique();

            entity.Property(e => e.KeyOrigin).HasColumnName("Key_Origin");
            entity.Property(e => e.Basis).HasComment("Базовое системное разрешение (только для дополнительных разрешений)");
            entity.Property(e => e.Flags).HasComment("(CreatorOwns, Restrictable, DelegateAllowed, DelegateRestricted, DelegateNecessary, DelegateOptional, etc.)");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа (если Null - для всех видов)")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.Origin).HasComment("Оригинальный флаг");
            entity.Property(e => e.Permits)
                .HasMaxLength(250)
                .HasComment("Что разрешает оригинальный флаг");

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocOrigins)
                .HasForeignKey(d => d.KeyNote)
                .HasConstraintName("DocOrigins_KeyNotes");
        });

        modelBuilder.Entity<DocPrivacy>(entity =>
        {
            entity.HasKey(e => e.KeyPrivacy).HasName("PK_Doc_Levels");

            entity.ToTable("Doc_Privacies");

            entity.Property(e => e.KeyPrivacy).HasColumnName("Key_Privacy");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.Departions).HasComment("Разрешения для подразделения создателя");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasComment("");
            entity.Property(e => e.Organitions).HasComment("Разрешения для организации создателя");
            entity.Property(e => e.Permissions).HasComment("Разрешения для всех");
            entity.Property(e => e.Sn)
                .HasMaxLength(100)
                .HasComment("необходимо только для идентификации при синхронизации БД")
                .HasColumnName("SN");
            entity.Property(e => e.SysName)
                .HasMaxLength(100)
                .HasComputedColumnSql("([SN])", false);
        });

        modelBuilder.Entity<DocPrivateListSearch>(entity =>
        {
            entity.HasKey(e => e.KeyPrivateList);

            entity.ToTable("Doc_PrivateListSearch");

            entity.Property(e => e.KeyPrivateList).HasColumnName("Key_PrivateList");
            entity.Property(e => e.KeyPropertyType)
                .HasComment("Свойство документа")
                .HasColumnName("Key_PropertyType");
            entity.Property(e => e.KeyUserOwner)
                .HasComment("Владелец значения (KSM)")
                .HasColumnName("Key_UserOwner");
            entity.Property(e => e.KeyValue)
                .HasComment("Key значения")
                .HasColumnName("Key_Value");
            entity.Property(e => e.Value)
                .HasMaxLength(80)
                .HasComment("Значение свойства");

            entity.HasOne(d => d.KeyPropertyTypeNavigation).WithMany(p => p.DocPrivateListSearches)
                .HasForeignKey(d => d.KeyPropertyType)
                .HasConstraintName("PrivateListSearch_KeyPropertyType_CD");
        });

        modelBuilder.Entity<DocPrivatePermission>(entity =>
        {
            entity.HasKey(e => e.KeyPrivatePermission);

            entity.ToTable("Doc_PrivatePermissions");

            entity.HasIndex(e => e.KeyUserOwner, "IX_DocPrivatePermissions_KeyUserOwner");

            entity.HasIndex(e => e.KeyUserPermited, "IX_DocPrivatePermissions_KeyUserPermited");

            entity.Property(e => e.KeyPrivatePermission).HasColumnName("Key_PrivatePermission");
            entity.Property(e => e.Finish)
                .HasComment("Время окончания действия делегирования")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Flags).HasComment("(Substitution)");
            entity.Property(e => e.KeyBase)
                .HasComment("Ссылка на документ-основание для делегирования разрешений")
                .HasColumnName("Key_Base");
            entity.Property(e => e.KeyNote)
                .HasComputedColumnSql("([Key_Notes])", false)
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComment("На какой вид документа. NULL - на все виды документов.")
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyUserOwner)
                .HasComment("Кто разрешил (KSM)")
                .HasColumnName("Key_UserOwner");
            entity.Property(e => e.KeyUserPermited)
                .HasComment("Кому разрешил ( KSM)")
                .HasColumnName("Key_UserPermited");
            entity.Property(e => e.Permissions).HasComment("Что разрешил");
            entity.Property(e => e.Start)
                .HasComment("Время начала действия делегирования")
                .HasColumnType("smalldatetime");

            entity.HasOne(d => d.KeyBaseNavigation).WithMany(p => p.DocPrivatePermissions)
                .HasForeignKey(d => d.KeyBase)
                .HasConstraintName("DocPrivatePermissions_KeyBase");

            entity.HasOne(d => d.KeyNotesNavigation).WithMany(p => p.DocPrivatePermissions)
                .HasForeignKey(d => d.KeyNotes)
                .HasConstraintName("DocPrivatePermissions_KeyNote");
        });

        modelBuilder.Entity<DocPrivateSelection>(entity =>
        {
            entity.HasKey(e => e.KeyPrivateSelection);

            entity.ToTable("Doc_PrivateSelections");

            entity.Property(e => e.KeyPrivateSelection).HasColumnName("Key_PrivateSelection");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.KeyParent).HasColumnName("Key_Parent");
            entity.Property(e => e.KeyUserOwner)
                .HasComment("Владелец (KSM)")
                .HasColumnName("Key_UserOwner");
            entity.Property(e => e.KeyUserReceiver).HasColumnName("Key_UserReceiver");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.PeriodBegin).HasColumnType("smalldatetime");
            entity.Property(e => e.PeriodEnd).HasColumnType("smalldatetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyParentNavigation).WithMany(p => p.InverseKeyParentNavigation)
                .HasForeignKey(d => d.KeyParent)
                .HasConstraintName("DocPrivateSelections_KeyParent");
        });

        modelBuilder.Entity<DocProcessRelation>(entity =>
        {
            entity.HasKey(e => e.KeyProcessRelation);

            entity.ToTable("Doc_ProcessRelations", tb =>
                {
                    tb.HasComment("");
                    tb.HasTrigger("trDocProcessRelationsFixRoute");
                });

            entity.HasIndex(e => new { e.KeyNode, e.KeyParent }, "IX_DocProcessRelations_KeyNode");

            entity.HasIndex(e => e.KeyParent, "IX_DocProcessRelations_KeyParent");

            entity.Property(e => e.KeyProcessRelation).HasColumnName("Key_ProcessRelation");
            entity.Property(e => e.KeyNode)
                .HasComment("Инстанция")
                .HasColumnName("Key_Node");
            entity.Property(e => e.KeyParent)
                .HasComment("Предшественник... Почему NULL ?? если есть связь, значит есть предшественник ведь")
                .HasColumnName("Key_Parent");

            entity.HasOne(d => d.KeyNodeNavigation).WithMany(p => p.DocProcessRelationKeyNodeNavigations)
                .HasForeignKey(d => d.KeyNode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProcessRelations_KeyNode");

            entity.HasOne(d => d.KeyParentNavigation).WithMany(p => p.DocProcessRelationKeyParentNavigations)
                .HasForeignKey(d => d.KeyParent)
                .HasConstraintName("ProcessRelations_Key_Parent");
        });

        modelBuilder.Entity<DocProcessTemplate>(entity =>
        {
            entity.HasKey(e => e.KeyProcessTemplate).HasName("PK_Doc_RegTemplate");

            entity.ToTable("Doc_ProcessTemplate");

            entity.HasIndex(e => e.KeyRoute, "IX_DocProcessTemplate_KeyRoute");

            entity.HasIndex(e => e.KeyRoute, "IX_DocProcessTemplate_KeyRouteInclude");

            entity.Property(e => e.KeyProcessTemplate).HasColumnName("Key_ProcessTemplate");
            entity.Property(e => e.CommentSender).HasMaxLength(4000);
            entity.Property(e => e.ExecutorSysName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Исполнитель - макрос");
            entity.Property(e => e.Flags).HasComment("Флаг определяющий возможность изменения инстанции во время движения (исполнитель, операция, доступ)");
            entity.Property(e => e.KeyOperation)
                .HasComment("Операция")
                .HasColumnName("Key_Operation");
            entity.Property(e => e.KeyRoute)
                .HasComment("Маршрут")
                .HasColumnName("Key_Route");
            entity.Property(e => e.KeyUserExecutor)
                .HasComment("Исполнитель (KSM), если не указывать, при использовании будет подставляться авторизованный пользователь.")
                .HasColumnName("Key_UserExecutor");
            entity.Property(e => e.Permissions).HasComment("Разрешения инстанции");
            entity.Property(e => e.Serial).HasComment("Порядковый номер, предназначен для сортировки, если шаблон маршрута используется как шаблон для печати");
            entity.Property(e => e.StateCancel)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.StateDone)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.KeyOperationNavigation).WithMany(p => p.DocProcessTemplates)
                .HasForeignKey(d => d.KeyOperation)
                .HasConstraintName("Template_KeyOperation");

            entity.HasOne(d => d.KeyRouteNavigation).WithMany(p => p.DocProcessTemplates)
                .HasForeignKey(d => d.KeyRoute)
                .HasConstraintName("Template_KeyRoute_CD");
        });

        modelBuilder.Entity<DocProcessing>(entity =>
        {
            entity.HasKey(e => e.KeyProcessing).HasName("PK_DocProcessing");

            entity.ToTable("Doc_Processing", tb =>
                {
                    tb.HasComment("");
                    tb.HasTrigger("trDocProcessingFixRoute");
                });

            entity.HasIndex(e => new { e.Executed, e.KeyUserExecutor }, "IX_DocProcessingExecutedKeyUserExecutor");

            entity.HasIndex(e => new { e.Executed, e.KeyDoc, e.Flags, e.KeyUserExecutor, e.Started, e.Received }, "IX_DocProcessing_ExecutedInclude");

            entity.HasIndex(e => new { e.KeyUserExecutor, e.Executed, e.Received, e.Started, e.KeyDoc }, "IX_DocProcessing_ExecutedKeyUserExecutor");

            entity.HasIndex(e => new { e.KeyUserExecutor, e.Executed, e.Received }, "IX_DocProcessing_ExecutedReceived");

            entity.HasIndex(e => new { e.Flags, e.Executed }, "IX_DocProcessing_FlagsExecuted");

            entity.HasIndex(e => e.KeyDoc, "IX_DocProcessing_KeyDocInclude");

            entity.HasIndex(e => e.KeyUserExecutor, "IX_DocProcessing_KeyExecutorInclude");

            entity.HasIndex(e => e.KeyOperation, "IX_DocProcessing_KeyOperationIncludes");

            entity.HasIndex(e => e.KeyUserSender, "IX_DocProcessing_KeySender");

            entity.HasIndex(e => new { e.KeyUserExecutor, e.Executed, e.Started }, "IX_DocProcessing_MRU").IsDescending(false, true, true);

            entity.HasIndex(e => e.Received, "IX_DocProcessing_Received");

            entity.Property(e => e.KeyProcessing).HasColumnName("Key_Processing");
            entity.Property(e => e.CheckSum)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Контрольная сумма всей важной* информации документа на момент выполнения действия по алгоритму MD5. Для разных видов документов считается посвоему. Выдержка из справки: BINARY_CHECKSUM(*) will return a different value for most, but not all, changes to the row, and can be used to detect most row modifications.");
            entity.Property(e => e.CommentExecutor).HasComment("Комментарий исполнителя действия");
            entity.Property(e => e.CommentSender).HasComment("Комментарий отправителя");
            entity.Property(e => e.Controlled)
                .HasComment("Дата контроля выполнения работы, инициализируется UserSender'ом")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Executed)
                .HasComment("Дата выполнения действия")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Flags).HasComment("(Ownership, FixedOperation, FixedPermissions, FixedExecutor)");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.KeyOperation)
                .HasComment("Операция")
                .HasColumnName("Key_Operation");
            entity.Property(e => e.KeyUserExecutor)
                .HasComment("Исполнитель")
                .HasColumnName("Key_UserExecutor");
            entity.Property(e => e.KeyUserSender)
                .HasComment("Отправитель (KSM) - кто указал действие")
                .HasColumnName("Key_UserSender");
            entity.Property(e => e.Limited).HasColumnType("smalldatetime");
            entity.Property(e => e.Permissions).HasComment("Разрешения для инстанции");
            entity.Property(e => e.Received)
                .HasComment("Дата когда до инстанции дошла очередь")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Started)
                .HasComment("Когда исполнитель начал работу. Определяется по дате просмотра документа.")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.StateCancel)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.StateDone)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.View)
                .HasMaxLength(500)
                .HasComputedColumnSql("([dbo].[Doc_ProcessView]([Key_Processing]))", false)
                .HasComment("Вычисляемое поле. Собирает представление записи.");

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocProcessings)
                .HasForeignKey(d => d.KeyDoc)
                .HasConstraintName("Processing_KeyDoc_CD");

            entity.HasOne(d => d.KeyOperationNavigation).WithMany(p => p.DocProcessings)
                .HasForeignKey(d => d.KeyOperation)
                .HasConstraintName("Processing_KeyOperation");
        });

        modelBuilder.Entity<DocProperty>(entity =>
        {
            entity.HasKey(e => e.KeyProperty).HasName("PK_DocProperties");

            entity.ToTable("Doc_Properties", tb => tb.HasComment("Содержит список и значения свойств документа, характерных для вида документа"));

            entity.HasIndex(e => e.KeyDoc, "IX_DocProperties_KeyDoc");

            entity.HasIndex(e => e.KeyPropertyType, "IX_DocProperties_KeyPropertyTypeIncludeKeyDocKeyValue");

            entity.HasIndex(e => new { e.KeyDoc, e.KeyPropertyType }, "IX_DocProperties_KeyPropertyTypeKeyDocInclude").IsUnique();

            entity.HasIndex(e => new { e.KeyPropertyType, e.KeyValue }, "IX_DocProperties_KeyPropertyTypeKeyValueIncludeKeyDoc");

            entity.HasIndex(e => new { e.KeyDoc, e.KeyPropertyType }, "UI_DocProperties_Keys").IsUnique();

            entity.Property(e => e.KeyProperty).HasColumnName("Key_Property");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.KeyPropertyType)
                .HasComment("Свойство")
                .HasColumnName("Key_PropertyType");
            entity.Property(e => e.KeyValue)
                .HasComment("Ключ значения свойства")
                .HasColumnName("Key_Value");
            entity.Property(e => e.Value)
                .HasMaxLength(1000)
                .HasComment("Значение свойства");
            entity.Property(e => e.View)
                .HasMaxLength(500)
                .HasComputedColumnSql("([dbo].[Doc_PropertyView]([Key_Property]))", false)
                .HasComment("Вычисляемое поле. Собирает представление записи.");

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocProperties)
                .HasForeignKey(d => d.KeyDoc)
                .HasConstraintName("Properties_KeyDoc_CD");

            entity.HasOne(d => d.KeyPropertyTypeNavigation).WithMany(p => p.DocProperties)
                .HasForeignKey(d => d.KeyPropertyType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Properties_KeyPropertyType");
        });

        modelBuilder.Entity<DocPropertyType>(entity =>
        {
            entity.HasKey(e => e.KeyPropertyType).HasName("PK_DocPropertyTypes_KeyPropertyType");

            entity.ToTable("Doc_PropertyTypes");

            entity.HasIndex(e => new { e.KeyPropertyType, e.Sn }, "IX_DocPropertyTypes_SN").IsUnique();

            entity.HasIndex(e => e.SysName, "IX_DocPropertyTypes_SysName");

            entity.Property(e => e.KeyPropertyType).HasColumnName("Key_PropertyType");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.FieldExpression)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FieldName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComputedColumnSql("([dbo].[ISUP_TableFieldName]([Key_TableField]))", false)
                .HasComment("*для поиска документов. Имя поля, значение которого ассоциируется");
            entity.Property(e => e.Flags).HasComment("MRU, Searchable, Editable, Visible");
            entity.Property(e => e.KeyDataClass).HasColumnName("Key_DataClass");
            entity.Property(e => e.KeyFrame).HasColumnName("Key_Frame");
            entity.Property(e => e.KeyTableField)
                .HasComment("Имя поля, значение")
                .HasColumnName("Key_TableField");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Sn)
                .HasMaxLength(50)
                .HasColumnName("SN");
            entity.Property(e => e.SysName)
                .HasMaxLength(50)
                .HasComputedColumnSql("([SN])", false);
            entity.Property(e => e.ValueList).IsUnicode(false);
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<DocRecord>(entity =>
        {
            entity.HasKey(e => e.KeyRecord).HasName("PK_DocTables");

            entity.ToTable("Doc_Records");

            entity.HasIndex(e => e.KeyDoc, "IX_DocRecords_KeyDoc");

            entity.Property(e => e.KeyRecord).HasColumnName("Key_Record");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий к записи характерной таблицы")
                .HasColumnType("ntext");
            entity.Property(e => e.I0)
                .HasComment("Поле с ключом данных № 0")
                .HasColumnName("i0");
            entity.Property(e => e.I1).HasColumnName("i1");
            entity.Property(e => e.I2).HasColumnName("i2");
            entity.Property(e => e.I3).HasColumnName("i3");
            entity.Property(e => e.I4).HasColumnName("i4");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.KeyNoteTable)
                .HasComment("Характерная таблица")
                .HasColumnName("Key_NoteTable");
            entity.Property(e => e.S0)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("Поле с значением данных № 0")
                .HasColumnName("s0");
            entity.Property(e => e.S1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("s1");
            entity.Property(e => e.S2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("s2");
            entity.Property(e => e.S3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("s3");
            entity.Property(e => e.S4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("s4");
            entity.Property(e => e.Serial)
                .HasMaxLength(50)
                .HasComment("Порядковый номер записи");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocRecords)
                .HasForeignKey(d => d.KeyDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocRecords_KeyDoc");

            entity.HasOne(d => d.KeyNoteTableNavigation).WithMany(p => p.DocRecords)
                .HasForeignKey(d => d.KeyNoteTable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocRecords_KeyNoteTable");
        });

        modelBuilder.Entity<DocRelation>(entity =>
        {
            entity.HasKey(e => e.KeyRelation).HasName("PK_DocRelations");

            entity.ToTable("Doc_Relations", tb => tb.HasComment(""));

            entity.HasIndex(e => e.KeyObject, "IX_DocRelations_KeyObject");

            entity.HasIndex(e => e.KeyRelationType, "IX_DocRelations_KeyRelationTypeInclude");

            entity.HasIndex(e => e.KeySubject, "IX_DocRelations_KeySubject");

            entity.HasIndex(e => new { e.KeyObject, e.KeySubject, e.KeyRelationType }, "UI_DocRelations_Keys").IsUnique();

            entity.Property(e => e.KeyRelation).HasColumnName("Key_Relation");
            entity.Property(e => e.Comment)
                .HasMaxLength(250)
                .HasComment("");
            entity.Property(e => e.KeyObject)
                .HasComment("Предшествующий (базовый) документ")
                .HasColumnName("Key_Object");
            entity.Property(e => e.KeyRelationType)
                .HasComment("Тип отношения")
                .HasColumnName("Key_RelationType");
            entity.Property(e => e.KeySubject)
                .HasComment("Последующий документ")
                .HasColumnName("Key_Subject");

            entity.HasOne(d => d.KeyObjectNavigation).WithMany(p => p.DocRelationKeyObjectNavigations)
                .HasForeignKey(d => d.KeyObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocRelations_KeyObject");

            entity.HasOne(d => d.KeyRelationTypeNavigation).WithMany(p => p.DocRelations)
                .HasForeignKey(d => d.KeyRelationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocRelations_KeyRelationType");

            entity.HasOne(d => d.KeySubjectNavigation).WithMany(p => p.DocRelationKeySubjectNavigations)
                .HasForeignKey(d => d.KeySubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocRelations_KeySubject");
        });

        modelBuilder.Entity<DocRelationType>(entity =>
        {
            entity.HasKey(e => e.KeyRelationType).HasName("PK_Doc_Kits");

            entity.ToTable("Doc_RelationTypes");

            entity.HasIndex(e => e.Sn, "IX_DocRelationTypes_SN");

            entity.Property(e => e.KeyRelationType).HasColumnName("Key_RelationType");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("");
            entity.Property(e => e.Sn)
                .HasMaxLength(50)
                .HasColumnName("SN");
            entity.Property(e => e.SysName)
                .HasMaxLength(50)
                .HasComputedColumnSql("([SN])", false);
        });

        modelBuilder.Entity<DocRoute>(entity =>
        {
            entity.HasKey(e => e.KeyRoute);

            entity.ToTable("Doc_Routes");

            entity.Property(e => e.KeyRoute)
                .HasComment("ПК")
                .HasColumnName("Key_Route");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.Flags).HasComment("(Default)");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyUserOwner)
                .HasComment("Владелец (KSM)")
                .HasColumnName("Key_UserOwner");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasComment("Нименование маршрута")
                .UseCollation("Cyrillic_General_CI_AS");

            entity.HasOne(d => d.KeyNoteNavigation).WithMany(p => p.DocRoutes)
                .HasForeignKey(d => d.KeyNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocRoutes_KeyNote");
        });

        modelBuilder.Entity<DocRouteDependence>(entity =>
        {
            entity.HasKey(e => e.KeyRouteDependence).HasName("PK_Doc_RouteDependencies");

            entity.ToTable("Doc_RouteDependences");

            entity.Property(e => e.KeyRouteDependence).HasColumnName("Key_RouteDependence");
            entity.Property(e => e.KeyDataClass)
                .HasComment("Класс данных")
                .HasColumnName("Key_DataClass");
            entity.Property(e => e.KeyRoute)
                .HasComment("Маршрут")
                .HasColumnName("Key_Route");
            entity.Property(e => e.KeyValue)
                .HasComment("Key значения")
                .HasColumnName("Key_Value");
            entity.Property(e => e.Value)
                .HasMaxLength(500)
                .HasComment("Str значения");

            entity.HasOne(d => d.KeyRouteNavigation).WithMany(p => p.DocRouteDependences)
                .HasForeignKey(d => d.KeyRoute)
                .HasConstraintName("RouteDependencies_KeyRoute_CD");
        });

        modelBuilder.Entity<DocSelection>(entity =>
        {
            entity.HasKey(e => e.KeySelection);

            entity.ToTable("Doc_Selections", tb => tb.HasComment(""));

            entity.HasIndex(e => new { e.KeyDoc, e.KeyPrivateSelection }, "IX_DocSelections_KeyDocKeyPrivateSelection");

            entity.HasIndex(e => e.KeyPrivateSelection, "IX_DocSelections_KeyPrivateSelection");

            entity.Property(e => e.KeySelection).HasColumnName("Key_Selection");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.KeyPrivateSelection)
                .HasComment("Подборка")
                .HasColumnName("Key_PrivateSelection");

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocSelections)
                .HasForeignKey(d => d.KeyDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Selections_KeyDoc");

            entity.HasOne(d => d.KeyPrivateSelectionNavigation).WithMany(p => p.DocSelections)
                .HasForeignKey(d => d.KeyPrivateSelection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Selections_KeyPrivateSelection");
        });

        modelBuilder.Entity<DocSupervision>(entity =>
        {
            entity.HasKey(e => e.KeySupervision);

            entity.ToTable("Doc_Supervisions");

            entity.HasIndex(e => new { e.KeyDoc, e.KeyUserSupervisor }, "IX_DocSupervisions_KeyDocKeyUserSupervisor");

            entity.HasIndex(e => e.KeyUserSupervisor, "IX_DocSupervisions_KeyUserSupervisorKeyDoc");

            entity.Property(e => e.KeySupervision).HasColumnName("Key_Supervision");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.KeyUserSupervisor)
                .HasComment("Кто взял на контроль")
                .HasColumnName("Key_UserSupervisor");

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocSupervisions)
                .HasForeignKey(d => d.KeyDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Supervisions_KeyDoc");
        });

        modelBuilder.Entity<DocTemplateRelation>(entity =>
        {
            entity.HasKey(e => e.KeyProcessRelation);

            entity.ToTable("Doc_TemplateRelations");

            entity.Property(e => e.KeyProcessRelation).HasColumnName("Key_ProcessRelation");
            entity.Property(e => e.KeyNode)
                .HasComment("Инстанция")
                .HasColumnName("Key_Node");
            entity.Property(e => e.KeyParent)
                .HasComment("Предшественник")
                .HasColumnName("Key_Parent");

            entity.HasOne(d => d.KeyNodeNavigation).WithMany(p => p.DocTemplateRelationKeyNodeNavigations)
                .HasForeignKey(d => d.KeyNode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TemplateRelations_KeyNode");

            entity.HasOne(d => d.KeyParentNavigation).WithMany(p => p.DocTemplateRelationKeyParentNavigations)
                .HasForeignKey(d => d.KeyParent)
                .HasConstraintName("TemplateRelations_KeyParent");
        });

        modelBuilder.Entity<DocVersion>(entity =>
        {
            entity.HasKey(e => e.KeyVersion);

            entity.ToTable("Doc_Versions");

            entity.HasIndex(e => e.Flags, "IX_DocVersions_Flags");

            entity.HasIndex(e => e.KeyBasis, "IX_DocVersions_KeyBasis");

            entity.HasIndex(e => e.KeyDoc, "IX_DocVersions_KeyDoc");

            entity.Property(e => e.KeyVersion)
                .HasComment("Версия.")
                .HasColumnName("Key_Version");
            entity.Property(e => e.Comment)
                .HasMaxLength(256)
                .HasComment("Примечание.");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Дата начала актуальности версии")
                .HasColumnType("datetime");
            entity.Property(e => e.KeyBasis)
                .HasComment("Документ-основание, инициировавший создание версии")
                .HasColumnName("Key_Basis");
            entity.Property(e => e.KeyDoc)
                .HasComment("Документ")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.Version).HasComment("Автоинкрементный номер версии");

            entity.HasOne(d => d.KeyBasisNavigation).WithMany(p => p.DocVersionKeyBasisNavigations)
                .HasForeignKey(d => d.KeyBasis)
                .HasConstraintName("Versions_KeyBasis");

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.DocVersionKeyDocNavigations)
                .HasForeignKey(d => d.KeyDoc)
                .HasConstraintName("Versions_KeyDoc_CD");
        });

        modelBuilder.Entity<DocVersionProcessing>(entity =>
        {
            entity.HasKey(e => e.KeyVersionProcessing);

            entity.ToTable("Doc_VersionProcessing");

            entity.HasIndex(e => new { e.KeyVersion, e.KeyOperation, e.KeyUserExecutor }, "VersionProcessing_UI_VOUe").IsUnique();

            entity.Property(e => e.KeyVersionProcessing).HasColumnName("Key_VersionProcessing");
            entity.Property(e => e.CommentExecutor)
                .HasMaxLength(2000)
                .HasComment("Комментарий исполнителя действия");
            entity.Property(e => e.Executed)
                .HasComment("Дата выполнения действия")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.KeyOperation)
                .HasComment("Действие")
                .HasColumnName("Key_Operation");
            entity.Property(e => e.KeyUserExecutor)
                .HasComment("Исполнитель")
                .HasColumnName("Key_UserExecutor");
            entity.Property(e => e.KeyVersion)
                .HasComment("Версия")
                .HasColumnName("Key_Version");
            entity.Property(e => e.Started)
                .HasComment("Когда исполнитель начал работу. Определяется по дате просмотра документа.")
                .HasColumnType("smalldatetime");

            entity.HasOne(d => d.KeyOperationNavigation).WithMany(p => p.DocVersionProcessings)
                .HasForeignKey(d => d.KeyOperation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VersionProcessing_KeyOperation");

            entity.HasOne(d => d.KeyVersionNavigation).WithMany(p => p.DocVersionProcessings)
                .HasForeignKey(d => d.KeyVersion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VersionProcessing_KeyVersion_CD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
