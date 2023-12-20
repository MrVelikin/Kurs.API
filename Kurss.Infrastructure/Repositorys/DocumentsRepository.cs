using Kurss.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Infrastructure.Repositorys
{
    public class DocumentsRepository
    {
        public readonly Context _context;

        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public DocumentsRepository(Context context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<List<Documents>> GetAllAsync()
        {
            return await _context.Documents.OrderBy(x => x.DocName).ToListAsync();
        }

        public async Task<Documents?> GetByNameAsync(string name)
        {
            return await _context.Documents
                .Where(x => x.DocName == name)
                .Include(x => x.Visible)
                .FirstOrDefaultAsync();
        }

        public async Task DelateAsync(Guid id)
        {
            Documents? Document = await _context.Documents.FindAsync(id);
            if (Document == null)
            {
                _context.Remove(Document);
                await _context.SaveChangesAsync();
            }
        }

        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<Documents?> GetByIdAsync(Guid id)
        {
            return await _context.Documents
                .Where(x => x.Id == id)
                .Include(x => x.Visible)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Documents Documents)
        {
            var existDoc= GetByIdAsync(Documents.Id).Result;
            if (existDoc != null)
            {
                _context.Entry(existDoc).CurrentValues.SetValues(Documents);
                foreach (var pasport in Documents.Pasports)
                {
                    var existpasport =
                        existDoc.Pasports.FirstOrDefault(d => d.Id == pasport.Id);
                    if (existpasport == null)
                    {
                        existDoc.Pasports.Add(pasport);
                    }
                    else
                    {
                        _context.Entry(existpasport).CurrentValues.SetValues(pasport);
                    }
                }
                foreach (var existpasport in existDoc.Pasports)
                {
                    if (!Documents.Pasports.Any(pa => pa.Id == existpasport.Id))
                    {
                        _context.Remove(existpasport);
                    }
                }

                foreach (var sertificate in Documents.Sertificates)
                {
                    var existsertificate =
                        existDoc.Sertificates.FirstOrDefault(s => s.Id == sertificate.Id);
                    if (existsertificate == null)
                    {
                        existDoc.Sertificates.Add(sertificate);
                    }
                    else
                    {
                        _context.Entry(existsertificate).CurrentValues.SetValues(sertificate);
                    }
                }
                foreach (var existsertificate in existDoc.Sertificates)
                {
                    if (!Documents.Sertificates.Any(ser => ser.Id == existsertificate.Id))
                    {
                        _context.Remove(existsertificate);
                    }
                }

                await _context.SaveChangesAsync();
            }


        }
    }
}
