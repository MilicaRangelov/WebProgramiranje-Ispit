﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace OktobarII21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdavnicatController : ControllerBase
    {

        public ProdavnicaContext Context { get; set; }


        public ProdavnicatController(ProdavnicaContext Context)
        {
            this.Context  = Context;
        }


        [Route("PrikaziProdavnice")]
        [HttpGet]

        public async Task<ActionResult> PrikaziProdavnice(){

            return Ok(await Context.Prodavnica.Select(p => new{
                Id = p.ID,
                Naziv = p.Naziv
            }).ToListAsync());
        }

        [Route("DodajProdavnicu/{naziv}")]
        [HttpPost]

        public async Task<ActionResult> DodajProdavnicu(string naziv){

            if(string.IsNullOrEmpty(naziv) || naziv.Length > 50){
                return BadRequest("Pogresan naziv");
            }

            try{
                Prodavnica p = new Prodavnica();
                p.Naziv = naziv;
                Context.Prodavnica.Add(p);

                await Context.SaveChangesAsync();

                return Ok("Prodavnica uspesno dodata");

            }
            catch(Exception ex){

                return BadRequest(ex.Message);
            }


        }

      
    }
}
