using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.FaceAlbum.Web.Data;
using TDSTecnologia.FaceAlbum.Web.Models;

namespace TDSTecnologia.FaceAlbum.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AppContexto _context;

        public AlbumController(AppContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //return View();
            return View(_context.Albuns.ToList());
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _context.Albuns.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(int id, Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        private bool AlbumExists(int id)
        {
            return _context.Albuns.Any(e => e.AlbumId == id);
        }

        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _context.Albuns.FirstOrDefault(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
    }
}
