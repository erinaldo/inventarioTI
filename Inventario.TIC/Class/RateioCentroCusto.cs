﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class RateioCentroCusto
    {
        public int? CodColigada { get; set; }
        public int? IdMov { get; set; }
        public int? NSeqItMMov { get; set; }
        public string Referencia { get; set; }
        public string CodCCusto { get; set; }
        public string CentroCusto { get; set; }
        public decimal Valor { get; set; }
        public int? Qtde { get; set; }
        public decimal? Porcentagem { get; set; }
        public int? IdMovRatCcu { get; set; }

        public RateioCentroCusto()
        {

        }

        public List<RateioCentroCusto> GetRateioTelefoniaMovel(string referencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@REFERENCIA", referencia);
                    var rateios = connection.Query<RateioCentroCusto>("GETRATEIOTELMOVELVIVO", parametros, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<dynamic> GetDadosPedidoTOTVS(string numeroPedido)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@NUMEROMOV", numeroPedido);
                    var pedidos = connection.Query<dynamic>("GETDADOSPEDIDOTOTVS", parametros, commandType: CommandType.StoredProcedure).ToList();
                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetLastIdMovRatCCu()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var idMovRatCcu = connection.Query<int>("GETLASTIDMOVRATCCU", null, commandType: CommandType.StoredProcedure).ToList();
                    return idMovRatCcu.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RateioCentroCusto> GetRateioLinkInternet()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var rateios = connection.Query<RateioCentroCusto>("GETRATEIOUSUARIOSAD", null, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RateioCentroCusto> GetRateioEMailExchange(string referencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@REFERENCIA", referencia);

                    var rateios = connection.Query<RateioCentroCusto>("GETRATEIOEMAILEXCHANGE", parametros, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RateioCentroCusto> GetRateioEMailMaiex(string referencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@REFERENCIA", referencia);

                    var rateios = connection.Query<RateioCentroCusto>("GETRATEIOEMAILMAIEX", parametros, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RateioCentroCusto> GetRateioEMailPenso(string referencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@REFERENCIA", referencia);

                    var rateios = connection.Query<RateioCentroCusto>("GETRATEIOEMAILPENSO", parametros, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RateioCentroCusto> GetRateioTelefoniaFixa(string referencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    // var parametros = new DynamicParameters();
                    // parametros.Add("@REFERENCIA", referencia);

                    var rateios = connection.Query<RateioCentroCusto>("GETNOVORATEIOTELEFONIAFIXA", null, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RateioCentroCusto> GetRateioImpressoras(string referencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@REFERENCIA", referencia);

                    var rateios = connection.Query<RateioCentroCusto>("GETRATEIOIMPRESSORAS", parametros, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RateioCentroCusto> GetRateioDispositivosAlugados()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var rateios = connection.Query<RateioCentroCusto>("GETRATEIODISPOSITIVOALUGADO", null, commandType: CommandType.StoredProcedure).ToList();
                    return rateios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SetLastIdMovRatCCu(int idMovRatCcu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@IDMOVRATCCU", idMovRatCcu);

                    connection.Query("SETLASTIDMOVRATCCU", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
