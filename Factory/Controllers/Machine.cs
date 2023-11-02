using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
    [Route("machines")]
    public class MachinesController : Controller
    {
        private readonly FactoryContext _dbContext;

        public MachinesController(FactoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ListAll()
        {
            return View(_dbContext.Machines.ToList());
        }

        public IActionResult MachineDetails(int id)
        {
            Machine machineToDisplay = _dbContext.Machines
                .Include(m => m.AssociatedEngineers)
                .ThenInclude(join => join.Engineer)
                .FirstOrDefault(m => m.MachineId == id);
            return View(machineToDisplay);
        }

        public IActionResult CreateMachine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMachine(Machine machine)
        {
            _dbContext.Machines.Add(machine);
            _dbContext.SaveChanges();
            return RedirectToAction("ListAll");
        }

        public IActionResult AssignEngineer(int id)
        {
            Machine machineToAssign = _dbContext.Machines.FirstOrDefault(machine => machine.MachineId == id);
            ViewBag.EngineerId = new SelectList(_dbContext.Engineers, "EngineerId", "FullName");
            return View(machineToAssign);
        }

        [HttpPost]
        public IActionResult AssignEngineer(Machine machine, int engineerId)
        {
#nullable enable
            MachineEngineer? assignment = _dbContext.MachineEngineers.FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
#nullable disable
            if (assignment == null && engineerId != 0)
            {
                _dbContext.MachineEngineers.Add(new MachineEngineer { EngineerId = engineerId, MachineId = machine.MachineId });
                _dbContext.SaveChanges();
            }
            return RedirectToAction("MachineDetails", new { id = machine.MachineId });
        }

        public IActionResult EditMachine(int id)
        {
            Machine machineToEdit = _dbContext.Machines.FirstOrDefault(machine => machine.MachineId == id);
            return View(machineToEdit);
        }

        [HttpPost]
        public IActionResult EditMachine(Machine machine)
        {
            _dbContext.Machines.Update(machine);
            _dbContext.SaveChanges();
            return RedirectToAction("ListAll");
        }

        public IActionResult RemoveMachine(int id)
        {
            Machine machineToRemove = _dbContext.Machines.FirstOrDefault(machine => machine.MachineId == id);
            return View(machineToRemove);
        }

        [HttpPost, ActionName("RemoveMachine")]
        public IActionResult DeleteMachine(int id)
        {
            Machine machineToDelete = _dbContext.Machines.FirstOrDefault(machine => machine.MachineId == id);
            _dbContext.Machines.Remove(machineToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("ListAll");
        }

        [HttpPost]
        public IActionResult RemoveAssignment(int assignmentId)
        {
            MachineEngineer assignment = _dbContext.MachineEngineers.FirstOrDefault(a => a.MachineEngineerId == assignmentId);
            _dbContext.MachineEngineers.Remove(assignment);
            _dbContext.SaveChanges();
            return RedirectToAction("ListAll");
        }
    }
}
