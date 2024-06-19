using GraduateProjectAPI.DTO;
using GraduateProjectAPI.Entities.Documents;
using GraduateProjectAPI.Persistence;
using GraduateProjectAPI.Service.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraduateProjectAPI.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly ApplicationDbContext _context;

        private readonly string _connectionString;

        public DocumentService(IConfiguration configuration, ApplicationDbContext context)
        {
            _connectionString = configuration.GetConnectionString("AtomexDbConnection");
            _context = context;
        }

        public async Task<List<DocumentDto>> GetIncomingWorkDocuments(int userId, int resultModel, string expression)
        {
            var documents = new List<DocumentDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Doc_Documents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@KeyUser", userId);
                    command.Parameters.AddWithValue("@ResultMode", resultModel);
                    command.Parameters.AddWithValue("@Expression", expression);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var document = new DocumentDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Key_Doc")),
                                RegistrationNumber = reader.GetString(reader.GetOrdinal("RegNum_Doc")),
                                Date = reader.IsDBNull(reader.GetOrdinal("date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("date")),
                                Created = reader.GetString(reader.GetOrdinal("Users")),
                                PublicComment = reader.IsDBNull(reader.GetOrdinal("comment")) ? null : reader.GetString(reader.GetOrdinal("comment")),
                                TypeDoc = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note")),
                                PrivateComment = reader.IsDBNull(reader.GetOrdinal("UserComment")) ? null : reader.GetString(reader.GetOrdinal("UserComment")),
                                Security = reader.IsDBNull(reader.GetOrdinal("Privacy")) ? null : reader.GetString(reader.GetOrdinal("Privacy")),
                            };
                            documents.Add(document);
                        }
                    }
                }
            }
            return documents;
        }

        public async Task<List<InstacesDocumentDto>> GetRouteInstances(int documentId)
        {
            int dpfPrintOnly = await GetDpfPrintOnlyAsync();
            int showPrintOnly = 1;

            // Установка формата даты
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var result = await GetDocProcessingData(documentId, dpfPrintOnly, showPrintOnly);
            return result;
            
        }

        private async Task<int> GetDpfPrintOnlyAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT dbo.mdtf('Doc_Processing', 'dpfPrintOnly') AS DpfPrintOnly", connection))
                {
                    await connection.OpenAsync();

                    var result = await command.ExecuteScalarAsync();

                   
                    int dpfPrintOnly = Convert.ToInt32(result);

                    return dpfPrintOnly;
                }
            }
        }




        private async Task<List<InstacesDocumentDto>> GetDocProcessingData(int documentId, int dpfPrintOnly, int showPrintOnly)
        {
            var docProcessings = await _context.DocProcessings
                .Include(dp => dp.KeyOperationNavigation)
                .Include(dp => dp.KeyUserSenderNavigation)
                .Include(dp => dp.KeyUserExecutorNavigation)
                .Include(dp => dp.KeyDocNavigation)
                .Where(dp => (showPrintOnly == 1 || (dp.Flags & dpfPrintOnly) == 0) && dp.KeyDoc == documentId)
                .OrderBy(dp => (dp.Flags & dpfPrintOnly) == 0 ? 0 : 1)
                .ToListAsync();
            if (docProcessings.Count != 0)
            {
                var result = docProcessings.Select(dp => new InstacesDocumentDto
                {
                    UserSender = dp.KeyUserSenderNavigation.ShortNameActual,
                    UserExecutor = dp.KeyUserExecutorNavigation.ShortNameActual,
                    Operation = dp.KeyOperationNavigation != null ? dp.KeyOperationNavigation.Name : "Ознакомление", // Если dp.KeyOperationNavigation равно null, используем "Ознакомление"
                    CommentExecutor = dp.CommentExecutor,
                    Started = dp.Started,
                    Executed = dp.Executed,
                    Received = dp.Received,
                    //UncompletedPredecessorCount = GetUncompletedPredecessorCount(dp.KeyProcessing, dpfPrintOnly) 
                })
                .ToList();

                return result;
            }



            return null;
        }


        private int GetUncompletedPredecessorCount(int processingId, int dpfPrintOnly)
        {
            var result = _context.DocProcessRelations
             .Join(_context.DocProcessings,
                 relations => relations.KeyParent,
                 processingParent => processingParent.KeyProcessing,
                 (relations, processingParent) => new { relations, processingParent })
             .Join(_context.DocProcessings,
                 temp => temp.relations.KeyNode,
                 processingChild => processingChild.KeyProcessing,
                 (temp, processingChild) => new { temp.relations, temp.processingParent, processingChild })
             .Where(temp => temp.processingChild.KeyProcessing == processingId)
             .Select(temp => new { temp.relations, temp.processingParent })
             .Union(
                 _context.DocProcessRelations
                     .Join(_context.DocProcessRelations,
                         relationsRecursive => relationsRecursive.KeyParent,
                         relations => relations.KeyNode,
                         (relationsRecursive, relations) => new { relationsRecursive, relations })
                     .Join(_context.DocProcessings,
                         temp => temp.relations.KeyParent,
                         processingParent => processingParent.KeyProcessing,
                         (temp, processingParent) => new { temp.relations, processingParent })
                     .Join(_context.DocProcessings,
                         temp => temp.relations.KeyNode,
                         processingChild => processingChild.KeyProcessing,
                         (temp, processingChild) => new { temp.relations, temp.processingParent, processingChild })
                     .Where(temp => temp.processingChild.KeyProcessing == processingId || (temp.processingChild.Flags & dpfPrintOnly) != 0)
                     .Select(temp => new { temp.relations, temp.processingParent }))
             .Count(x => x.processingParent.Executed == null && (x.processingParent.Flags & dpfPrintOnly) == 0);
          
                    return result;

        }

        public async Task<List<DocumentDto>> GetOutgoingDocumentsWork(string nameProcedure, int pageNumber, int pageSize, int userId)
        {
            var documents = new List<DocumentDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(nameProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@KeySubMaster", userId);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var document = new DocumentDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Key_Doc")),
                                RegistrationNumber = reader.GetString(reader.GetOrdinal("RegNum_Doc")),
                                Date = reader.IsDBNull(reader.GetOrdinal("date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("date")),
                                Created = reader.GetString(reader.GetOrdinal("Users")),
                                PublicComment = reader.IsDBNull(reader.GetOrdinal("comment")) ? null : reader.GetString(reader.GetOrdinal("comment")),
                                TypeDoc = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note")),
                                PrivateComment = reader.IsDBNull(reader.GetOrdinal("UserComment")) ? null : reader.GetString(reader.GetOrdinal("UserComment")),
                            };
                            documents.Add(document);
                        }
                    }
                }
            }
            return documents;
        }

        public async Task<List<ArchiveDto>> GetListArchive(int year)
        {
            int dnfDirectCreation = 1;

            var result = _context.DocLists
                 .Where(d => d.Date.Year == year)
                 .GroupBy(d => d.KeyNote)
                 .Select(g => new
                 {
                     Key_Note = g.Key,
                     DocumentCount = g.Count()
                 })
                 .Join(_context.DocNotes,
                       nd => nd.Key_Note,
                       dn => dn.KeyNote,
                       (nd, dn) => new
                       {
                           dn.KeyNote,
                           dn.Name,
                           dn.Flags,
                           nd.DocumentCount
                       })
                 .Where(r => r.DocumentCount > 0)
                 .OrderBy(r => r.Name);

            var resultDto = result.Select(ar => new ArchiveDto
            {
                KeyNote = ar.KeyNote,
                Name = ar.Name,
                Flags = ar.Flags,
                DocumentCount = ar.DocumentCount
            })
            .ToList();
            return resultDto;
        }

        public async Task<List<DocumentDto>> GetListDocumentKeyNoteArchive(int keyNote, int year, int pageNumber, int pageSize, int userId)
        {
            var documents = new List<DocumentDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Doc_GetListArchive", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@KeyNote", keyNote);
                    command.Parameters.AddWithValue("@KeySubMaster", userId);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var document = new DocumentDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Key_Doc")),
                                RegistrationNumber = reader.GetString(reader.GetOrdinal("RegNum_Doc")),
                                Date = reader.IsDBNull(reader.GetOrdinal("date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("date")),
                                Created = reader.GetString(reader.GetOrdinal("Users")),
                                PublicComment = reader.IsDBNull(reader.GetOrdinal("comment")) ? null : reader.GetString(reader.GetOrdinal("comment")),
                                TypeDoc = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note")),
                                PrivateComment = reader.IsDBNull(reader.GetOrdinal("UserComment")) ? null : reader.GetString(reader.GetOrdinal("UserComment")),
                            };
                            documents.Add(document);
                        }
                    }
                }
            }
            return documents;
        }
    }
}
