using Dapper;
using GraduateProjectAPI.DTO.KnowledgeBase;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GraduateProjectAPI.Service.Interface
{
    public class KnowledgeBase : IKnowledgeBase
    {

        public string ConnectionString = @"Server=10.10.99.1, 1433;Database=DM;User Id=edu_user;Password=student12345;Encrypt=false";
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        /// <summary>
        /// Получение всех необходимый нам полей из таблицы Abonent, а также подгрузка данных из таблиц Address и PhoneNumber
        /// </summary>
        /// <returns></returns>
        public List<GroupDto> GettingTreeGroups()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = """
                    
                    DECLARE @KeyUser          INT = 23805; --Ключ сотрудника 23805 (Бурцев Д.В. Администратор), 28391 (Без прав)
                    DECLARE @IsAdmin          BIT = 1; --Является Администратором или нет (для ускорения выборки для админа)
                    DECLARE @showDeleted      BIT = 1; --Показывать удаленные группы
                    DECLARE @showADeleted     BIT = 1; --Показывать удаленные статьи
                    DECLARE @ShowNonPublished BIT = 1; --Показывать неопубликованные (Для админа 1)
                    DECLARE @ShowOnlyFavorite BIT = 1; --Показать ТОЛЬКО избранные

                    DECLARE @flagCompressed   INT = dbo.mdtf('Help_Content', 'Compressed');
                    DECLARE @flagDeleted      INT = dbo.mdtf('Help_Groups', 'Deleted');
                    DECLARE @flagIsPublished  INT = dbo.mdtf('Help_Groups', 'IsPublished');
                    DECLARE @flagIsPublic     INT = dbo.mdtf('Help_Groups', 'IsPublic');
                    DECLARE @keyTable         INT = dbo.ISUP_GetKeyTable('Help_Groups');

                    DECLARE @flagADeleted     INT = dbo.mdtf('Help_Content', 'Deleted');
                    DECLARE @flagAIsPublished INT = dbo.mdtf('Help_Content', 'IsPublished');
                    DECLARE @flagAExtracted   INT = dbo.mdtf('Help_Content', 'Extracted');
                    DECLARE @keyATable        INT = dbo.ISUP_GetKeyTable('Help_Content');
                    DECLARE @keyGTable        INT = dbo.ISUP_GetKeyTable('Help_Groups');

                    With GroupsDown as
                    (
                      Select
                        Key_Group,
                        Key_Parent,
                        1 as Sub
                      From
                        Help_Groups as HG 
                      WHERE
                        (
                          (@ShowNonPublished = 1) or
                          (HG.Flags & @flagIsPublished <> 0)
                        )and
                        (
                           (@showDeleted = 1) or
                           (Flags & @flagDeleted = 0)
                        )and
                        (
                           (@IsAdmin = 1) or
                           (Flags & @flagIsPublic <> 0) or
                           (dbo.HasAccessToRecordExt('Help_Groups', HG.Key_Group, 'VIEW', @KeyUser, 0) = 1)
                         ) 

                      union all 

                      SELECT
                        HG.Key_Group,
                        HG.Key_Parent,
                        0 as Sub
                      FROM
                        GroupsDown
                        INNER JOIN Help_Groups AS HG
                          ON HG.Key_Parent = GroupsDown.Key_Group
                      WHERE
                        (
                          (@ShowNonPublished = 1) or
                          (HG.Flags & @flagIsPublished <> 0)
                        )and
                        (
                           (@showDeleted = 1) or
                           (Flags & @flagDeleted = 0)
                        )    
                    ), Groups AS
                    (
                      SELECT 
                        Key_Group,
                        Key_Parent,
                        MAX(Sub) as Sub
                      FROM
                        GroupsDown
                      GROUP BY
                        Key_Group,
                        Key_Parent

                      UNION ALL

                      SELECT
                        HG.Key_Group,
                        HG.Key_Parent,
                        0 as Sub
                      FROM
                        Groups
                        INNER JOIN Help_Groups AS HG
                          ON HG.Key_Group = Groups.Key_Parent
                          AND HG.Key_Group not in (Select Key_Group from GroupsDown) 
                    )

                    SELECT DISTINCT
                      'G'+CAST(Gr.Key_Group AS VARCHAR(20)) AS KeyItem,
                      'G'+CAST(isNull(Gr.Key_Parent,0) AS VARCHAR(20)) AS KeyItemParent,
                      0 AS ListOrder,
                      Gr.Key_Group, 
                      Gr.Key_Parent, 
                      Gr.Name, 
                      Gr.Flags, 
                      Keys.Sub AS ImageIndex,
                      CASE WHEN Gr.Flags & @flagDeleted     <> 0 THEN 1 ELSE 0 END AS IsDeleted,
                      CASE WHEN Gr.Flags & @flagIsPublished <> 0 THEN 1 ELSE 0 END AS IsPublished,
                      0 AS IsExtracted,
                      1 as IsCompressed,
                      ISO.Key_Order,
                    --  CAST(ISNULL(Cnt.ValueWithChilds,0) AS VARCHAR(10))+
                    --    CASE WHEN ISNULL(Cnt.VALUE,0) <> 0 THEN ' ('+CAST(Cnt.Value AS VARCHAR(10))+')' ELSE '' END AS Qnt,
                      null as IsFavorite
                    FROM 
                      Help_Groups as Gr
                      INNER JOIN Groups as Keys 
                        ON Keys.Key_Group = Gr.Key_Group
                      LEFT JOIN ISUP_SortOrder AS ISO
                        ON ISO.Key_Table = @KeyTable
                        AND ISO.Key_Item = Gr.Key_Group
                    --  LEFT JOIN  GetGroupArticlesList AS Cnt on
                    --    Cnt.Key_Group = Gr.Key_Group
                    where
                      (@ShowOnlyFavorite = 0)

                    UNION ALL

                    SELECT DISTINCT
                      'A'+CAST(HC.Key_Content AS VARCHAR(20)) AS KeyItem,
                      'G'+CAST(HC.Key_Group AS VARCHAR(20)) AS KeyItemParent,
                      1 AS ListOrder,
                      HC.Key_Content, 
                      HC.Key_Group, 
                      HC.Name, 
                      HC.Flags,
                      CASE WHEN HC.Flags & @flagAExtracted <> 0   THEN 3 ELSE 2 END as ImageIndex, 
                      CASE WHEN HC.Flags & @flagADeleted <> 0     THEN 1 ELSE 0 END AS IsDeleted,
                      CASE WHEN HC.Flags & @flagAIsPublished <> 0 THEN 1 ELSE 0 END AS IsPublished,
                      CASE WHEN HC.Flags & @flagAExtracted <> 0   THEN 1 ELSE 0 END AS IsExtracted,
                      CASE WHEN HC.Flags & @flagCompressed <> 0   THEN 1 ELSE 0 END AS IsCompressed,
                      ISO.Key_Order,
                    --  null,
                      CASE WHEN FI.Key_Favorite is null then 0 else 1 END as IsFavorite
                    FROM 
                      Help_Content AS HC
                      INNER JOIN GroupsDown AS Keys 
                        ON Keys.Key_Group = HC.Key_Group
                      LEFT JOIN ISUP_SortOrder AS ISO
                        ON ISO.Key_Table = @KeyATable
                        AND ISO.Key_Item = HC.Key_Content
                      LEFT JOIN S_Subjects AS Author 
                        ON Author.Key_Sub = HC.Key_Author
                      LEFT JOIN S_Subjects AS Editor 
                        ON Editor.Key_Sub = HC.Key_Editor
                      LEFT JOIN ISUP_FavoriteItems as FI 
                        on FI.Key_User = @KeyUser
                        and FI.Key_Table = @KeyATable
                        and FI.Key_Item = HC.Key_Content
                    WHERE
                      (
                        (@showDeleted = 1) or
                        (HC.Flags & @flagADeleted = 0)
                      ) and
                      (
                        (@ShowNonPublished = 1) or
                        (HC.Flags & @flagAIsPublished <> 0)
                      ) and
                      (
                        (@ShowOnlyFavorite = 0) or
                        (FI.Key_Favorite is not null)
                      )
                    
                    """;
                dbConnection.Open();
                return dbConnection.Query<GroupDto>(query).ToList();
            }
        }


        public List<PaperDto> GetContentPaper(int KeyItems)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"
            --Запрос для выбора статьи

            DECLARE @KeyItem INT = @KeyItems; --Ключ статьи;
            DECLARE @KeySub  INT = 23805; --Ключ пользователя

            if Exists(Select Key_Content from Help_Content where Key_Content = @KeyItem) and
               not Exists(Select * from Help_Reads Where Key_HC = @KeyItem and Key_Sub = @KeySub)
               insert into Help_Reads (Key_HC, Key_Sub) values(@KeyItem, @KeySub);

            SELECT
              BodyPlainText,Key_Content,
              Author.Name as Author
            FROM 
              Help_Content AS HC
              LEFT JOIN S_Subjects AS Author 
                ON Author.Key_Sub = HC.Key_Author
            WHERE
              Key_Content = @KeyItem
            ";
                dbConnection.Open();
                return dbConnection.Query<PaperDto>(query, new { KeyItems }).ToList();
            }
        }


        public List<ArticleDto> GettingArticlesGroup(int idGroup)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"
                    
                    DECLARE @Key_Group        INT = 216; --Ключ выбранной группы
                    DECLARE @showDeleted      BIT = 1; --Показывать удаленные записи
                    DECLARE @ShowNonPublished BIT = 1; --Показывать неопубликованные записи

                    DECLARE @flagDeleted      INT = dbo.mdtf('Help_Groups', 'Deleted');
                    DECLARE @flagIsPublished  INT = dbo.mdtf('Help_Groups', 'IsPublished');
                    DECLARE @flagExtracted    INT = dbo.mdtf('Help_Content', 'Extracted');
                    DECLARE @keyTable         INT = dbo.ISUP_GetKeyTable('Help_Content');

                    --Выбираем все подчиненные группы

                    SELECT
                      'A'+CAST(HC.Key_Content as varchar(10)) as KeyRecord,
                      HC.Key_Content as Key_Item,
                      HC.Key_Group as Key_Parent, 
                      2 as ImageIndex, 
                      HC.Name, 
                      HC.Flags,
                      Author.Name AS AuthorName,
                      CASE WHEN HC.Flags & @flagDeleted <> 0 THEN 1 ELSE 0 END AS IsDeleted,
                      CASE WHEN HC.Flags & @flagIsPublished <> 0 THEN 1 ELSE 0 END AS IsPublished,
                      CASE WHEN HC.Flags & @flagExtracted <> 0 THEN 1 ELSE 0 END AS IsExtracted,
                      ISO.Key_Order,
                      HC.ModifyDate,
                      Editor.Name as EditorName
                    FROM 
                      Help_Content AS HC
                      LEFT JOIN ISUP_SortOrder AS ISO
                        ON ISO.Key_Table = @KeyTable
                        AND ISO.Key_Item = HC.Key_Content
                      LEFT JOIN S_Subjects AS Author 
                        ON Author.Key_Sub = HC.Key_Author
                      LEFT JOIN S_Subjects AS Editor 
                        ON Editor.Key_Sub = HC.Key_Editor
                    WHERE
                      (HC.Key_Group = @Key_Group)
                      and ((@showDeleted = 1) or (HC.Flags & @flagDeleted = 0)) 
                      and ((@ShowNonPublished = 1) or (HC.Flags & @flagIsPublished <> 0))

                    UNION ALL

                    SELECT DISTINCT
                      'G'+CAST(Gr.Key_Group AS VARCHAR(20)) AS KeyRecord,
                      Gr.Key_Group as Key_Item, 
                      Gr.Key_Parent,
                      1 as ImageIndex,
                      Gr.Name, 
                      Gr.Flags, 
                      'Группа' as AuthorName,
                      CASE WHEN Gr.Flags & @flagDeleted     <> 0 THEN 1 ELSE 0 END AS IsDeleted,
                      CASE WHEN Gr.Flags & @flagIsPublished <> 0 THEN 1 ELSE 0 END AS IsPublished,
                      0 AS IsExtracted,
                      ISO.Key_Order,
                      null as ModifyDate,
                      null as EditorName
                    FROM 
                      Help_Groups as Gr
                      LEFT JOIN ISUP_SortOrder AS ISO
                        ON ISO.Key_Table = @KeyTable
                        AND ISO.Key_Item = Gr.Key_Group
                    where
                      GR.Key_Parent = @Key_Group
                      and ((@showDeleted = 1) or (Gr.Flags & @flagDeleted = 0)) 
                      and ((@ShowNonPublished = 1) or (Gr.Flags & @flagIsPublished <> 0))

                    
                    
                    ";
                dbConnection.Open();
                return dbConnection.Query<ArticleDto>(query).ToList();
            }
        }

      
    }
}
