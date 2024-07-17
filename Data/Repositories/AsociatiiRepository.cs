using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data.Repositories
{
    public class AsociatiiRepository : IAsociatiiRepository
    {
        private readonly string _connectionString;

        public AsociatiiRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }

        public async Task<IEnumerable<tblAsociatii>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblAsociatii";
                return await connection.QueryAsync<tblAsociatii>(sql);
            }
        }

        public async Task<tblAsociatii> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblAsociatii WHERE idAsoc = @Id";
                return await connection.QuerySingleOrDefaultAsync<tblAsociatii>(sql, new { Id = id });
            }
        }

        public async Task AddAsync(tblAsociatii asociatie)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    INSERT INTO tblAsociatii 
                    (Denumire, denScurta, Adresa, Presedinte, Administrator, Cenzor, AnLucru, LunaLucru, Telefon, 
                    CoefPausalAR, CoefPausaACM, cpia0den, cpia1den, cpia2den, cpia3den, cpia4den, cpib0den, cpib1den, 
                    cpib2den, cpib3den, cpib4den, cpib5den, cpib6den, cpic0den, cpic1den, cpic2den, cpic3den, cpic4den, 
                    cpic5den, cppasoc1den, cppasoc2den, cpp1den, cpp2den, cpp3den, cpp4den, cpiscara0den, cpiscara1den, 
                    cpiscara2den, cpiscara3den, cpia0val, cpia1val, cpia2val, cpia3val, cpia4val, cpib0val, cpib1val, 
                    cpib2val, cpib3val, cpib4val, cpib5val, cpib6val, cpic0val, cpic1val, cpic2val, cpic3val, cpic4val, 
                    cpic5val, cppasoc1val, cppasoc2val, PretGcal, PretAR, PretARptACM, PretACM, PretCPI, TotalCPI, 
                    PretCPPasoc1, PretCPPasoc2, modRepartizareCorectie, tipApartCorectie, calculat, secalculeazaRestante, 
                    raportAfis, Note, scanareConsumuri, modRepartizareCG, apameteo, raportAfisIstoric, penalizari, 
                    seCalcCPPASOC1, seCalcCPPASOC2, raportCentralizator, PretARptACMConventii)
                    VALUES 
                    (@Denumire, @denScurta, @Adresa, @Presedinte, @Administrator, @Cenzor, @AnLucru, @LunaLucru, @Telefon, 
                    @CoefPausalAR, @CoefPausaACM, @cpia0den, @cpia1den, @cpia2den, @cpia3den, @cpia4den, @cpib0den, @cpib1den, 
                    @cpib2den, @cpib3den, @cpib4den, @cpib5den, @cpib6den, @cpic0den, @cpic1den, @cpic2den, @cpic3den, 
                    @cpic4den, @cpic5den, @cppasoc1den, @cppasoc2den, @cpp1den, @cpp2den, @cpp3den, @cpp4den, @cpiscara0den, 
                    @cpiscara1den, @cpiscara2den, @cpiscara3den, @cpia0val, @cpia1val, @cpia2val, @cpia3val, @cpia4val, 
                    @cpib0val, @cpib1val, @cpib2val, @cpib3val, @cpib4val, @cpib5val, @cpib6val, @cpic0val, @cpic1val, 
                    @cpic2val, @cpic3val, @cpic4val, @cpic5val, @cppasoc1val, @cppasoc2val, @PretGcal, @PretAR, 
                    @PretARptACM, @PretACM, @PretCPI, @TotalCPI, @PretCPPasoc1, @PretCPPasoc2, @modRepartizareCorectie, 
                    @tipApartCorectie, @calculat, @secalculeazaRestante, @raportAfis, @Note, @scanareConsumuri, 
                    @modRepartizareCG, @apameteo, @raportAfisIstoric, @penalizari, @seCalcCPPASOC1, @seCalcCPPASOC2, 
                    @raportCentralizator, @PretARptACMConventii)";
                await connection.ExecuteAsync(sql, asociatie);
            }
        }

        public async Task UpdateAsync(tblAsociatii asociatie)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    UPDATE tblAsociatii SET
                    Denumire = @Denumire, denScurta = @denScurta, Adresa = @Adresa, Presedinte = @Presedinte, 
                    Administrator = @Administrator, Cenzor = @Cenzor, AnLucru = @AnLucru, LunaLucru = @LunaLucru, 
                    Telefon = @Telefon, CoefPausalAR = @CoefPausalAR, CoefPausaACM = @CoefPausaACM, cpia0den = @cpia0den, 
                    cpia1den = @cpia1den, cpia2den = @cpia2den, cpia3den = @cpia3den, cpia4den = @cpia4den, cpib0den = @cpib0den, 
                    cpib1den = @cpib1den, cpib2den = @cpib2den, cpib3den = @cpib3den, cpib4den = @cpib4den, cpib5den = @cpib5den, 
                    cpib6den = @cpib6den, cpic0den = @cpic0den, cpic1den = @cpic1den, cpic2den = @cpic2den, cpic3den = @cpic3den, 
                    cpic4den = @cpic4den, cpic5den = @cpic5den, cppasoc1den = @cppasoc1den, cppasoc2den = @cppasoc2den, 
                    cpp1den = @cpp1den, cpp2den = @cpp2den, cpp3den = @cpp3den, cpp4den = @cpp4den, cpiscara0den = @cpiscara0den, 
                    cpiscara1den = @cpiscara1den, cpiscara2den = @cpiscara2den, cpiscara3den = @cpiscara3den, cpia0val = @cpia0val, 
                    cpia1val = @cpia1val, cpia2val = @cpia2val, cpia3val = @cpia3val, cpia4val = @cpia4val, cpib0val = @cpib0val, 
                    cpib1val = @cpib1val, cpib2val = @cpib2val, cpib3val = @cpib3val, cpib4val = @cpib4val, cpib5val = @cpib5val, 
                    cpib6val = @cpib6val, cpic0val = @cpic0val, cpic1val = @cpic1val, cpic2val = @cpic2val, cpic3val = @cpic3val, 
                    cpic4val = @cpic4val, cpic5val = @cpic5val, cppasoc1val = @cppasoc1val, cppasoc2val = @cppasoc2val, 
                    PretGcal = @PretGcal, PretAR = @PretAR, PretARptACM = @PretARptACM, PretACM = @PretACM, PretCPI = @PretCPI, 
                    TotalCPI = @TotalCPI, PretCPPasoc1 = @PretCPPasoc1, PretCPPasoc2 = @PretCPPasoc2, modRepartizareCorectie = @modRepartizareCorectie, 
                    tipApartCorectie = @tipApartCorectie, calculat = @calculat, secalculeazaRestante = @secalculeazaRestante, 
                    raportAfis = @raportAfis, Note = @Note, scanareConsumuri = @scanareConsumuri, modRepartizareCG = @modRepartizareCG, 
                    apameteo = @apameteo, raportAfisIstoric = @raportAfisIstoric, penalizari = @penalizari, seCalcCPPASOC1 = @seCalcCPPASOC1, 
                    seCalcCPPASOC2 = @seCalcCPPASOC2, raportCentralizator = @raportCentralizator, PretARptACMConventii = @PretARptACMConventii
                    WHERE idAsoc = @idAsoc";
                await connection.ExecuteAsync(sql, asociatie);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM tblAsociatii WHERE idAsoc = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
