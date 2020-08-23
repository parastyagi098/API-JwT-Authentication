using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
             if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
           return _context.Commands.ToList(); 
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges()>= 0);
        }

        public void UpdateCommand(Command cmd)
        {
           
        }
        public Command Authenticate(string username, string password)
        {
            if(string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password))
            {
                return null;
            }
            var user = _context.Commands.SingleOrDefault(x=>x.Line==username);
            if(user==null)
            {
                return null;
            }
            if(password!=user.Platform)
            {
                return null; 
            }
            return user;
            }
        }
    }