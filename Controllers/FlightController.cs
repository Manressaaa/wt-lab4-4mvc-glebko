using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_glebko.Models;

namespace wt_lab4_4mvc_glebko.Controllers;

public class FlightController : Controller
{
    private static readonly List<Flight> flights = new()
    {
        new Flight
        {
            nomer_reisa = 101,
            gorod_vilet = "Нюйорк",
            gorod_prilet = "Горки)",
            vremya_vileta = new DateTime(2026, 11, 15, 8, 30, 0),
            cena = 250,
            mesta = 45,
            dostupno = true
        },
        new Flight
        {
            nomer_reisa = 102,
            gorod_vilet = "Минск",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 11, 16, 12, 0, 0),
            cena = 180,
            mesta = 30,
            dostupno = true
        },
        new Flight
        {
            nomer_reisa = 103,
            gorod_vilet = "Москва",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 11, 17, 22, 15, 0),
            cena = 400,
            mesta = 0,
            dostupno = false
        },
        new Flight
        {
            nomer_reisa = 104,
            gorod_vilet = "Гомель",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 12, 20, 14, 0, 0),
            cena = 300,
            mesta = 50,
            dostupno = true
        },
        new Flight
        {
            nomer_reisa = 105,
            gorod_vilet = "Витебск",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 12, 25, 6, 45, 0),
            cena = 150,
            mesta = 20,
            dostupno = true
        }
    };

    //показать список всех рейсов
    public IActionResult Index()
    {
        return View(flights);
    }

    //показать один рейс по номеру
    public IActionResult Details(int id)
    {
        var flight = flights.FirstOrDefault(f => f.nomer_reisa == id);
        if (flight == null)
        {
            return NotFound();  //страница 404
        }
        return View(flight);
    }

    // GET: /Flight/Create — показать форму
    public IActionResult Create()
    {
        return View();
    }

    // POST:— обработать отправку формы
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Flight flight)
    {
        if (!ModelState.IsValid)
        {
            return View(flight);  // вернуть форму с ошибками
        }

        //дубликат номера
        if (flights.Any(f => f.nomer_reisa == flight.nomer_reisa))
        {
            ModelState.AddModelError("nomer_reisa",
                "Рейс с таким номером уже существует.");
            return View(flight);
        }

        flight.dostupno = flight.mesta > 0;

        flights.Add(flight);
        return RedirectToAction("Index");
    }

    // GET: /Flight/Edit/101 — показать форму редактирования
    public IActionResult Edit(int id)
    {
        var flight = flights.FirstOrDefault(f => f.nomer_reisa == id);
        if (flight == null)
        {
            return NotFound();
        }
        return View(flight);
    }

    // POST: /Flight/Edit/101 — сохранить изменения
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Flight flight)
    {
        if (!ModelState.IsValid)
        {
            return View(flight);
        }

        var existing = flights.FirstOrDefault(f => f.nomer_reisa == id);
        if (existing == null)
        {
            return NotFound();
        }

        existing.gorod_vilet = flight.gorod_vilet;
        existing.gorod_prilet = flight.gorod_prilet;
        existing.vremya_vileta = flight.vremya_vileta;
        existing.cena = flight.cena;
        existing.mesta = flight.mesta;
        existing.dostupno = flight.mesta > 0 && flight.dostupno;

        return RedirectToAction("Index");
    }
}