﻿using AutoMapper;
using AutoMapper.Configuration;
using HHCoApps.Core.EF;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Libs
{
    public static class MappingExtension
    {
        /// <summary>
        /// Initialize mapper
        /// </summary>
        public static void Mapping(this MapperConfigurationExpression Configuration)
        {
            Configuration.CreateMap<Users, UserModel>().ReverseMap();
            Configuration.CreateMap<Category, CategoryModel>().ReverseMap();            
            Configuration.CreateMap<Supplier, SupplierModel>().ReverseMap();
            Configuration.CreateMap<Product, ProductModel>().ReverseMap();

            //Configuration.CreateMap<UserModel, Users>();
            //Configuration.CreateMap<CategoryModel, Category>();
            //Configuration.CreateMap<ProductModel, Product>();
            //Configuration.CreateMap<SupplierModel, Supplier>();
        }
    }
}
