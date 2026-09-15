using InventoryByawAstha.BLL.Exceptions.GeneralExceptions;
using InventoryByawAstha.BLL.src.DTOs.PurchaseDTOs;
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
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IVendorRepository vendorRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IVendorRepository vendorRepository)
        {
            this.purchaseRepository = purchaseRepository;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.vendorRepository = vendorRepository;
        }
        public async Task Create(CreatePurchaseDTO dto, int userId)
        {
                if (dto.Items == null || !dto.Items.Any())
                {
                    throw new InvalidPurchaseException();

                }
                var vendor = await vendorRepository.GetById(dto.VendorId);
                if (vendor == null) { throw new VendorNotFoundException(dto.VendorId); }

                var purchase = new Purchase
                {
                    VendorId = dto.VendorId,
                    UserId = userId,
                    PurchaseDetails = new List<PurchaseDetail>(),
                    PurchaseDate = DateTime.Now
                };
                foreach (var item in dto.Items.OrderBy(p => p.ProductId))
                {
                    var product = await productRepository.GetByIdForUpdate(item.ProductId);
                    if (product == null) { throw new ProductNotFoundException(item.ProductId); }
                    if (item.Quantity <= 0) { throw new InvalidProductQuantityException(); }
                    if (item.PurchasePrice < 0) { throw new InvalidPriceException(); }
                    if (item.SalesPrice < 0) { throw new InvalidPriceException(); }
                    var details = new PurchaseDetail
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        SalesPrice = item.SalesPrice,
                        PurchasePrice = item.PurchasePrice,
                        Amount = item.Quantity * item.PurchasePrice
                    };

                    purchase.PurchaseDetails.Add(details);
                    product.Quantity += item.Quantity;
                }
                purchase.TotalAmount = purchase.PurchaseDetails.Sum(pd => pd.Amount);
                await purchaseRepository.Create(purchase);
                await unitOfWork.SaveChangesAsync();

        }
        public async Task<List<PurchaseDTO>> GetAll()
        {
            var purchases = await purchaseRepository.GetAll();
            return purchases.Select(p => new PurchaseDTO
            {
                PurchaseId = p.PurchaseId,
                PurchaseDate = p.PurchaseDate,
                CreatedBy = p.User.UserName,
                VendorName = p.Vendor.Name,
                TotalAmount = p.TotalAmount,
                VendorId = p.VendorId
            }).ToList();

        }
        public async Task<List<PurchaseDetailsDTO>> GetById(int purchaseId)
        {
            var purchase = await purchaseRepository.GetById(purchaseId);

            if (purchase == null)
                throw new PurchaseNotFoundException(purchaseId);

            return purchase.PurchaseDetails.Select(d => new PurchaseDetailsDTO
            {
                PurchaseDetailId = d.PurchaseDetailId,
                ProductId = d.ProductId,
                ProductName = d.Product.Name,
                Quantity = d.Quantity,
                PurchasePrice = d.PurchasePrice,
                SalesPrice = d.SalesPrice,
                Amount = d.Amount
            }).ToList();
        }



    }

}
