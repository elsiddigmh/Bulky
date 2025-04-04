﻿using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public ICompanyRepository Company { get; }
        public IShoppingCartRepository ShoppingCart { get; }
        public IApplicationUserRepository ApplicationUser { get; }
		public IOrderDetailRepository OrderDetail { get; }
		public IOrderHeaderRepository OrderHeader { get; }
        public IProductImageRepository ProductImage { get; }

		public void Save();
    }
}
