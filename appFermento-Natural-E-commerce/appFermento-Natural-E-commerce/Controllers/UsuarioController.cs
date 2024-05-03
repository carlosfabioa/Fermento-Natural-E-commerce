﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appFermento_Natural_E_commerce.Data;
using appFermento_Natural_E_commerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using MySqlConnector;

namespace appFermento_Natural_E_commerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly appFermento_Natural_E_commerceContext _context;

        public UsuarioController(appFermento_Natural_E_commerceContext context)
        {
            _context = context;
        }
        //public void Login(int id)
        //{
        //    SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //    con.Open();

            
        //    if (con != null)
        //    {
        //        string sql = "SELECT * FROM dbo.Usuario WHERE id='"+id+"'";
                
        //    }
        //    else
        //    {
        //        // Dados incorretos, mostre uma mensagem de erro
        //    }
        //}
        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return _context.UsuarioModel != null ? 
                          View(await _context.UsuarioModel.ToListAsync()) :
                          Problem("Entity set 'appFermento_Natural_E_commerceContext.UsuarioModel'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuarioModel == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Logar(string email, string senha)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=Padaria;uid=root;");
            await mySqlConnection.OpenAsync();
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM usuarios WHERE email= '{email}' AND senha='{senha}'";
            
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            
            if (await reader.ReadAsync())
            {
                return Json(new { Msg = "Usuario logado com sucesso!"});
            }

                
            return Json(new { Msg= "Usuario nao encontrado! Verifique suas credenciais."});
        }


        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,email,senha")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuarioModel == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,email,senha")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.id))
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
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuarioModel == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuarioModel == null)
            {
                return Problem("Entity set 'appFermento_Natural_E_commerceContext.UsuarioModel'  is null.");
            }
            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            if (usuarioModel != null)
            {
                _context.UsuarioModel.Remove(usuarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
          return (_context.UsuarioModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}