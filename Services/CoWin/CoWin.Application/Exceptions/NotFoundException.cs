using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Application.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name,object key):base($"Entity \"{name}\" ({key}) is not found.")
        {
        }
    }
}
