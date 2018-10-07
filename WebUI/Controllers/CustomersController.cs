using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Filters;
using WebUI.Infrastructure;
using WWM.Application.Customers.Commands;
using WWM.Application.Customers.Models;
using WWM.Application.Customers.Queries;
using WWM.Persistence.Context;

namespace WebUI.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await Mediator.Send(new GetCustomerListQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await Mediator.Send(new GetCustomerDetailQuery{Id = id.Value}));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await Mediator.Send(new GetCustomerDetailQuery { Id = id.Value }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateModel]
        public async Task<IActionResult> Create([Bind("Name,Email,Phone")]CustomerDetailModel customer)
        {
            await Mediator.Send(Mapper.Map<CreateCustomerCommand>(customer));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Email,Phone")] CustomerDetailModel customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        [HttpGet]
        [ValidateCustomerExists]
        public async Task<IActionResult> Delete(Guid? id)
        {       
            return View(await Mediator.Send(new GetCustomerDetailQuery{Id=id.Value}));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await Mediator.Send(new DeleteCustomerCommand{Id = id});
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
