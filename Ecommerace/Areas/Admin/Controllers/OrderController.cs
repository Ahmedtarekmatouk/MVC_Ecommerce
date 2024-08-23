using Ecommerace.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Ecommerace.Services.Orders;

[Area("Admin")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IActionResult index()
    {
        var orders = _orderService.GetAllOrders();
        return View("Orders", orders);
    }

    public IActionResult Details(int id)
    {
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return View("Details", order);
    }

    public IActionResult Create()
    {
        ViewBag.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>()
            .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() });

        return View("Create");
    }

    [HttpPost]
    public IActionResult SaveCreate(Order order)
    {
        if (ModelState.IsValid)
        {
            _orderService.CreateOrder(order);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>()
            .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() });

        return View(order);
    }

    public IActionResult Edit(int id)
    {
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }

        ViewBag.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>()
            .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() });

        return View("Edit", order);
    }


    [HttpPost]
    public IActionResult SaveEdit(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _orderService.UpdateOrder(order);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>()
            .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() });

        return View("Edit", order);
    }


    public IActionResult Delete(int id)
    {
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return View("Delete", order);
    }

    [HttpPost]
    public IActionResult SaveDelete(int id)
    {
        _orderService.DeleteOrder(id);
        return RedirectToAction(nameof(Index));

    }
}