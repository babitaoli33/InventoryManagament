using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.SalesDTOs;
using InventoryByawAstha.BLL.src.Interfaces;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryByawAstha.BLL.src.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        private readonly IProductRepository productRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;
        public SaleService(ISaleRepository saleRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.saleRepository = saleRepository;
            this.productRepository = productRepository;
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Create(CreateSalesDTO dto, int UserId)
        {

            var customer = await customerRepository.GetById(dto.CustomerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException(dto.CustomerId);
            }
            if (!customer.IsActive)
            {
                throw new InactiveCustomerException();
            }
            var sale = new Sale
            {
                CustomerId = dto.CustomerId,
                UserId = UserId,
                SaleDate = DateTime.Now,
                SaleDetails = new List<SaleDetail>()
            };
            foreach (var item in dto.Items.OrderBy(p => p.ProductId))
            {
                if (item.Quantity <= 0)
                {
                    throw new InvalidProductQuantityException();
                }
                var product = await productRepository.GetByIdForUpdate(item.ProductId);
                if (product == null)
                {
                    throw new ProductNotFoundException(item.ProductId);
                }
                if (product.Quantity < item.Quantity)
                {
                    throw new InsufficientStockException(product.Name);

                }
                var detail = new SaleDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    SalesPrice = item.SalesPrice,
                    Amount = item.Quantity * item.SalesPrice
                };
                sale.SaleDetails.Add(detail);
                product.Quantity -= item.Quantity;

            }
            sale.TotalAmount = sale.SaleDetails.Sum(sd => sd.Amount);
            await saleRepository.Create(sale);
            await unitOfWork.SaveChangesAsync();


        }
        public async Task<List<SalesDTO>> GetAll()
        {
            var sales = await saleRepository.GetAll();
            return sales.Select(s => new SalesDTO
            {
                SaleId = s.SaleId,
                CustomerId = s.CustomerId,
                CustomerName = s.Customer.Name,
                UserId = s.UserId,
                CreatedBy = s.User.UserName,
                SalesDate = s.SaleDate,
                TotalAmount = s.TotalAmount
            }).ToList();
        }
        public async Task<SalesDTO> GetById(int id)
        {
            var sale = await saleRepository.GetById(id);
            if (sale == null)
            {
                throw new SaleNotFoundException(id);
            }
            return new SalesDTO
            {
                SaleId = sale.SaleId,
                CustomerId = sale.CustomerId,
                CustomerName = sale.Customer.Name,
                UserId = sale.UserId,
                CreatedBy = sale.User.UserName,
                SalesDate = sale.SaleDate,
                TotalAmount = sale.TotalAmount,
                SaleDetails = sale.SaleDetails.Select(sd => new SaleDetailsDTO
                {
                    SaleDetailId = sd.SaleDetailId,
                    SalesPrice = sd.SalesPrice,
                    Amount = sd.Amount,
                    ProductId = sd.ProductId,
                    ProductName = sd.Product.Name,
                    Quantity = sd.Quantity

                }).ToList()

            };
        }
    }
}






