using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.API.Contants;
using RepositoryPattern.core.Interfaces;
using RepositoryPattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        //public readonly IBaseRepository<Book> _unitOfWork.Books;

        //public BooksController(IBaseRepository<Book> booksRepository)
        //{
        //    _unitOfWork.Books = booksRepository;
        //}


        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Books.GetAllAsync());
        }


        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }


        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return  Ok(await _unitOfWork.Books.GetByIdAsync(1));
        }



        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {

            return Ok(_unitOfWork.Books.Find(P => P.Title == "Time", new[] { "Author" }));

        }

        [HttpGet("GetByNameAsync")]
        public  async Task<IActionResult> GetByNameAsync()
        {

            return  Ok(await _unitOfWork.Books.FindAsync(P => P.Title == "Time", new[] { "Author" }));

        }

        [HttpGet("GetAllByName")]
        public IActionResult GetAllByName()
        {

            return Ok(_unitOfWork.Books.FindAll(P => P.Title.Contains("Book"), new[] {"Author"}));

        }


        [HttpGet("GetAllByNameAsync")]
        public async Task<IActionResult> GetAllByNameAsync()
        {

            return Ok(await _unitOfWork.Books.FindAllAsync(P => P.Title.Contains("Book"), new[] { "Author" }));

        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "TestBook", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }

    }
}
