using DtoLayer.CustomerDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class BaseProjectContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=10.10.100.200;initial catalog=CustomerMeetingDb;user id=Dilek1;password=Dilek1;TrustServerCertificate=true");
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.CreateAppUser)
                .WithMany(u => u.CreatedMeetings)
                .HasForeignKey(m => m.CreateUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.UpdateAppUser)
                .WithMany(u => u.UpdatedMeetings)
                .HasForeignKey(m => m.UpdateUserID)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public async Task<List<BalanceDto>> GetBalanceByRepresentativeAsync(string representativeCode)
        {
            var balances = new List<BalanceDto>();

            try
            {
                using (var connection = new SqlConnection("server=10.10.100.200;initial catalog=CustomerMeetingDb;user id=Dilek1;password=Dilek1;TrustServerCertificate=true"))
                {
                    using (var command = new SqlCommand("R01TemsilciBakiye", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TEMSİLCİKOD", representativeCode);

                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var balance = new BalanceDto
                                {
                                    kod = reader["kod"].ToString(),
                                    Unvan = reader["Unvan"].ToString(),
                                    Sehir = reader["Sehir"].ToString(),
                                    Ulke = reader["Ulke"].ToString(),
                                    BorcBakiye = reader.GetDecimal(reader.GetOrdinal("BorcBakiye")),
                                    AlacakBakiye = reader.GetDecimal(reader.GetOrdinal("AlacakBakiye")),
                                    RiskTürü = reader["RiskTürü"].ToString(),
                                    calisilan_doviz_turu = reader["calisilan_doviz_turu"].ToString(),
                                    CariTip = reader["CariTip"].ToString(),
                                    Bakiye = reader.GetDecimal(reader.GetOrdinal("Bakiye")),
                                    MüsteriTemsilcisi = reader["MüsteriTemsilcisi"].ToString(),
                                    SatisBölgesi = reader["SatisBölgesi"].ToString(),
                                    KODM = reader["KODM"].ToString()
                                };
                                balances.Add(balance);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata loglama
                Console.WriteLine($"Error: {ex.Message}");
            }

            return balances;
        }


    }
}
