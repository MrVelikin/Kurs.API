using Kurss.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kurss.Infrastructure.Repositorys
{
    public class PersonRepository
    {
        public readonly Context _context;

        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PersonRepository(Context context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Persons.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Person?> GetByNameAsync(string name)
        { 
            return await _context.Persons
                .Where(x => x.Name == name)
               // .Include(x => x.PersonalData)
                .FirstOrDefaultAsync();
        }

        public async Task DelateAsync(Guid id)
        {
            Person? person = await _context.Persons.FindAsync(id);
            if(person == null)
            {
                _context.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public void ChangeTrackerClear() 
        {
               _context.ChangeTracker.Clear();
        }

        public async Task<Person?> GetByIdAsync(Guid id)
        {
            return await _context.Persons
                .Where(x => x.Id == id)
           //     .Include(x => x.PersonalData)
                .FirstOrDefaultAsync();
        }
        public async Task<Person> AddAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task UpdateAsync(Person person)
        {
            var existPerson = GetByIdAsync(person.Id).Result;
            if (existPerson != null)
            {
                _context.Entry(existPerson).CurrentValues.SetValues(person);    
                foreach(var Doc in person.Documents)
                {
                    var existdoc = 
                        existPerson.Documents.FirstOrDefault(d => d.Id == Doc.Id);
                    if (existdoc == null)
                    {
                        existPerson.Documents.Add(Doc);
                    }
                    else
                    {
                        _context.Entry(existdoc).CurrentValues.SetValues(Doc);
                    }
                }
                foreach(var existdoc in existPerson.Documents) 
                {
                    if(!person.Documents.Any(pa => pa.Id == existdoc.Id)) 
                    {
                        _context.Remove(existdoc);  
                    }
                }

                await _context.SaveChangesAsync();
            }


        }
    }
}
