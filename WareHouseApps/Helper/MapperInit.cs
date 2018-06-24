using AutoMapper;
using AutoMapper.Configuration;
using HHCoApps.Libs;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseApps.Models;

namespace WareHouseApps.Helper
{
    public class MapperInit
    { 
        /// <summary>
      /// Mapper configuration
      /// </summary>
        public MapperConfigurationExpression Configuration { get; } = new MapperConfigurationExpression();

        /// <summary>
        /// Initialize mapper
        /// </summary>
        public void Init()
        {
            MappingExtension.Mapping(Configuration);
            // Static mapper

            Configuration.CreateMap<SupplierModel, SupplierViewModel>().ReverseMap();
            Configuration.CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            Configuration.CreateMap<ProductModel, ProductViewModel>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.SupplierName, o => o.MapFrom(s => s.Supplier.CompanyName))
                .ReverseMap();

            Mapper.Initialize(Configuration);
        }
    }
}
