using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHCoApps.Core;
using HHCoApps.Repository.Interfaces;

namespace HHCoApps.Repository.Implementations
{
    internal class ImportProductRepository : IImportProductRepository
    {
        private const string SQL_CONNECTION_STRING = "HHCoApps";
        private const string TABLE_NAME = "dbo.Category";

        public ImportProductRepository() { }

        public int AddImportLog(ImportLog entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Invalid data!");

            var parameter = new
            {
                entity.UserId,
                entity.ProductId,
                entity.SupplierId,
                entity.Quantity,
                entity.TotalCost,
                entity.TotalBaseCost,
                entity.ForeignCurrency,
                entity.Created
            };

            var keyNames = new[]
            {
                "Created"
            };

            var result = DapperRepositoryUtil.InsertIfNotExist(TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameter, keyNames);
            return result;
        }


    }
}
