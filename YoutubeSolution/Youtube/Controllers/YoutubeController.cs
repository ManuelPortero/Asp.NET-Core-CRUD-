using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Youtube.Services;
using Youtube.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Youtube.Controllers
{
    public class YoutubeController : Controller
    {
        private readonly YoutubeService _service;

        public YoutubeController (YoutubeService srv)
        {
            _service = srv; 
        }     
        public IActionResult Index()
        {
            var videos = _service.GetAll().Result;
            return View(videos);
        }

        public async Task<IActionResult>  Details(int id)
        {
            Video result = await _service.GetbyId(id);
            if(result != null)
            {
                return View(result);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Create()
        {
            List<Author> authors = new List<Author>();
            authors.Add(new Author { Id = 1, FirstName = "Daniel" , CreatedDate= DateTime.Now });
            ViewBag.AuthorId = new SelectList(authors, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Video video)
        {
            if (ModelState.IsValid)
            {
                Video result = await _service.Create(video); 
                if(result != null)
                {
                    return View(result);
                }
                       
            }
            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Video result = _service.GetbyId(id).Result; 
                if(result !=null)
                {
                    return View(result);

                }
            }
            return RedirectToAction(nameof(Index)) ;
        }
        [HttpPost]
        public async Task<IActionResult> Edit (Video video)
        {
            if (ModelState.IsValid)
            {
                Video result = await _service.Update(video);
                if (result != null)
                {
                    return View(video);
                }
            }
            return View(null);
        }


     

        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            Video result = await _service.GetbyId(id);
            if (result != null)
            {
                Video videoDeleted= await _service.Delete(result);
                if(videoDeleted != null)
                {
                    return RedirectToAction(nameof(Index), new { Message = "Video deleted satisfactory" });
                }

            }
            return RedirectToAction(nameof(Index));
        }
    }
}