using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KönyvtárKezelő
{
    public class Member
    {
     public int MemberID { get; set; }
        public string Name { get; set; }

        public List<Book> KolcsonzottKonyvek { get; } = new List<Book>();

        public void KolcsonzottKonyvet(Book book)
        {

            if (book == null) throw new ArgumentNullException(nameof(book));
            if (!book.IsAvailable) throw new InvalidOperationException("A könyv jelenleg nem elérhető.");

            book.IsAvailable = false;
            KolcsonzottKonyvek.Add(book);
        }
        public void VisszahozottKonyvet(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (!KolcsonzottKonyvek.Contains(book)) throw new InvalidOperationException("A könyvet nem ez a tag kölcsönözte.");
            book.IsAvailable = true;
            
        }

    }
}
 