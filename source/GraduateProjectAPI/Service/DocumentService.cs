using GraduateProjectAPI.DTO;
using GraduateProjectAPI.Entities.Documents;
using GraduateProjectAPI.Persistence;
using GraduateProjectAPI.Service.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<List<DocumentDto>> GetAllDocumentAsync(int userId, int resultModel, string expression)
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

