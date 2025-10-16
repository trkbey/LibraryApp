using System;
using System.Net;
namespace Lib
{
    class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }

        public bool IsBorrowed { get; set; }

        public Book(int bookid, string title, string author)
        {
            BookId = bookid; 
            Title = title;
            Author = author;
            IsBorrowed = false;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"{BookId}. {Title} {Author} {(IsBorrowed ? "(ODUNC ALINDI)" : "(OKUNABILIR)")}");
        }
    }
    class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks {  get; set; }

        public Member(int memberid, string name) 
        {
            MemberId = memberid;
            Name = name;
            BorrowedBooks = new List<Book>();

        }
        public void DisplayInfo() 
        {
            Console.WriteLine($"UYE ID: {MemberId}, Ad: {Name}, Okudugu Kitaplar: {BorrowedBooks.Count}");
        }
    }



    class Library
    {
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Kitap '{book.Title}' Eklendi.");

        }
        public void AddMember(Member member)
        {
            Members.Add(member);
            Console.WriteLine($"Uye '{member.Name}' Kaydedildi");
        }
        public void DisplayBooks()
        {
            Console.WriteLine("\n--- Kitap Listesi ---");
            foreach (var book in Books)
            {
                book.DisplayInfo();
            }
        }
        public void BorrowBook(int memberId, int bookId)
        {
            Member member = Members.Find(m => m.MemberId == memberId);
            Book book = Books.Find(b => b.BookId == bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Yanlis Kitap Ya Da Uye Id!");
                return;
            }

            if (book.IsBorrowed)
            {
                Console.WriteLine("Bu kitap Odunc Alindi!");
                return;
            }

            book.IsBorrowed = true;
            member.BorrowedBooks.Add(book);
            Console.WriteLine($"{member.Name} '{book.Title}' Odunc aldi.");
        }
        public void ReturnBook(int memberId, int bookId)
        {
            Member member = Members.Find(m => m.MemberId == memberId);
            Book book = Books.Find(b => b.BookId == bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Bilgileri Yanlis Girdiniz");
                return;
            }

            if (member.BorrowedBooks.Contains(book))
            {
                book.IsBorrowed = false;
                member.BorrowedBooks.Remove(book);
                Console.WriteLine($"{member.Name} '{book.Title}' Iade Etti.");
            }
            else
            {
                Console.WriteLine($"{member.Name} Bu Kitabi Odunc Almadi.");
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            int bookId, memberId, choice;
            string bookTitle, bookAuthor, memberName;
            bool isBarrow;
            
            while (true)
            {
                Console.WriteLine("--------KUTUPHANE MENUSU------------");
                Console.WriteLine("1 ---> YENI UYE EKLE");
                Console.WriteLine("2 ---> YENI KITAP EKLE");
                Console.WriteLine("3 ---> GENEL BILGI");
                Console.WriteLine("4 ---> ODUNC KITAP AL");
                Console.WriteLine("5 ---> KITAP IADE ET");
                Console.WriteLine("6 ---> UYE BILGI");
                Console.WriteLine("7 ---> KITAPLAR");
                choice = Convert.ToInt32(Console.ReadLine());
             
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" UYE ID'SI VE ADINI GIRIN");
                        memberId = Convert.ToInt32(Console.ReadLine());
                        memberName = Console.ReadLine();
                        lib.AddMember(new Member(memberId, memberName));
                        break;

                    case 2:
                        Console.WriteLine("KITAP ID'SI KITAP ADI VE YAZAR GIRIN");
                        bookId = Convert.ToInt32(Console.ReadLine());
                        bookTitle = Console.ReadLine();
                        bookAuthor = Console.ReadLine();
                        lib.AddBook(new Book(bookId, bookTitle, bookAuthor));
                        break;

                    case 3:
                        lib.DisplayBooks();
                        Console.WriteLine("------Uye Listtesi-----");
                        foreach (var member in lib.Members)
                        {
                            member.DisplayInfo();
                        }
                        break;
                    case 4:
                        Console.WriteLine("UYE ID'SI VE KITAP ID'SI GIRIN");
                        memberId = Convert.ToInt32(Console.ReadLine());
                        bookId = Convert.ToInt32(Console.ReadLine());
                        lib.BorrowBook(memberId, bookId);
                        break;
                    case 5:
                        Console.WriteLine("UYE ID'SI VE KITAP ID'SI GIRIN");
                        memberId = Convert.ToInt32(Console.ReadLine());
                        bookId = Convert.ToInt32(Console.ReadLine());
                        lib.ReturnBook(memberId, bookId);
                        break;
                    
                    case 6:
                        Console.WriteLine("------Uye Listtesi-----");
                        foreach (var member in lib.Members)
                        {
                         
                            member.DisplayInfo();
                        }
                        break;

                    case 7:
                        Console.WriteLine("\n--- Kitap Listesi ---");
                        foreach (var book in lib.Books)
                        {
                            book.DisplayInfo();
                        }
                        break;
                }
            }

        }
    }
}