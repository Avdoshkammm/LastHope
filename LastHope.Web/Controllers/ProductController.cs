using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LastHope.Domain.Entities;
using LastHope.Infrastructure.Data;
using LastHope.Domain.Interfaces;
using LastHope.Application.DTO;

namespace LastHope.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly GenericInterface<ProductDTO> service;

        public ProductController(GenericInterface<ProductDTO> _service)
        {
            service = _service;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await service.GetProductsAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await service.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Cost")] ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await service.CreateProductAsync(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await service.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Cost")] ProductDTO productdto)
        {
            if (id != productdto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateProductAsync(productdto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (productdto.ID == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productdto);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await service.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await service.GetProductAsync(id);
            if (product != null)
            {
                await service.DeleteProductAsync(id);
            }

            
            return RedirectToAction(nameof(Index));
        }

    }
}
