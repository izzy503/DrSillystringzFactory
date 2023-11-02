using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;

namespace Factory.Controllers
{
    [Route("engineers")]
    public class EngineersController : Controller
    {
        private readonly FactoryContext _dbContext;

        public EngineersController(FactoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult List()
        {
            List<Engineer> engineerList = _dbContext.Engineers.ToList();
            return View(engineerList);
        }

        public IActionResult Hire()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Hire(Engineer newEngineer)
        {
            if (!ModelState.IsValid)
            {
                return View(newEngineer);
            }
            else
            {
                _dbContext.Engineers.Add(newEngineer);
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }
        }

        public IActionResult AssignMachine(int id)
        {
            Engineer selectedEngineer = _dbContext.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            ViewBag.MachineId = new SelectList(_dbContext.Machines, "MachineId", "MachineName");
            return View(selectedEngineer);
        }

        [HttpPost]
        public IActionResult AssignMachine(Engineer engineer, int machineId)
        {
#nullable enable
            MachineEngineer? assignment = _dbContext.MachineEngineers.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
#nullable disable
            if (assignment == null && machineId != 0)
            {
                _dbContext.MachineEngineers.Add(new MachineEngineer { MachineId = machineId, EngineerId = engineer.EngineerId });
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Details", new { id = engineer.EngineerId });
        }

        public IActionResult Details(int id)
        {
            Engineer selectedEngineer = _dbContext.Engineers
                               .Include(engineer => engineer.AssignedMachines)
                               .ThenInclude(assignment => assignment.Machine)
                               .FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(selectedEngineer);
        }

        public IActionResult Edit(int id)
        {
            Engineer selectedEngineer = _dbContext.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            ViewBag.MachineId = new SelectList(_dbContext.Machines, "MachineId", "MachineName");
            return View(selectedEngineer);
        }

        [HttpPost]
        public IActionResult Edit(Engineer engineer)
        {
            _dbContext.Engineers.Update(engineer);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Remove(int id)
        {
            Engineer selectedEngineer = _dbContext.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(selectedEngineer);
        }

        [HttpPost, ActionName("Remove")]
        public IActionResult RemoveConfirmed(int id)
        {
            Engineer selectedEngineer = _dbContext.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            _dbContext.Engineers.Remove(selectedEngineer);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult UnassignMachine(int assignmentId)
        {
            MachineEngineer assignment = _dbContext.MachineEngineers.FirstOrDefault(a => a.MachineEngineerId == assignmentId);
            _dbContext.MachineEngineers.Remove(assignment);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
