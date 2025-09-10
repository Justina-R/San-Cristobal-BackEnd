using Microsoft.AspNetCore.Mvc;
using MiPrimerAPI.Repositories;
using System;
using System.Diagnostics.Metrics;


namespace MiPrimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        //Con el ejercicio extra, usamos InstrumentRepository, no esta lista
        //private static List<string> instruments = new() { "Guitarra", "Batería", "Piano" };

        [HttpGet]
        public ActionResult GetInstruments()
        {
            //return Ok(instruments);
            return Ok(InstrumentRepository.Instruments);
        }

        // POST api/<InstrumentsController>
        [HttpPost]
        public ActionResult AddNewInstrument([FromBody] string instrument)
        {
            if (instrument == null)
            {
                return BadRequest("El campo es obligatorio.");
            }
            //instruments.Add(instrument);
            InstrumentRepository.Instruments.Add(instrument);
            return Ok($"Instrumento agregado con éxito a la lista: {instrument}");

        }

        // PUT api/<InstrumentsController>/5
        [HttpPut("{instrumentIndex}")]
        public ActionResult UpdateInstrument([FromRoute] int instrumentIndex, [FromBody] string newInstrument)
        {
            if (newInstrument == null)
            {
                return BadRequest("El campo es obligatorio.");
            }

            if (instrumentIndex < 0 || instrumentIndex >= InstrumentRepository.Instruments.Count)
            {
                return BadRequest($"El índice {instrumentIndex} no es válido. Debe estar entre 0 y {InstrumentRepository.Instruments.Count - 1}.");
            }

            //instruments[instrumentIndex] = newInstrument;
            InstrumentRepository.Instruments[instrumentIndex] = newInstrument;
            return Ok($"Se modificó el elemento en posición {instrumentIndex} a {newInstrument}.");
        }

        // DELETE api/<InstrumentsController>/5
        [HttpDelete("{instrumentIndex}")]
        public ActionResult DeleteInstrument(int instrumentIndex)
        {
            if (instrumentIndex < 0 || instrumentIndex >= InstrumentRepository.Instruments.Count)
            {
                return BadRequest($"El índice {instrumentIndex} no es válido. Debe estar entre 0 y {InstrumentRepository.Instruments.Count - 1}.");
            }
            //instruments.RemoveAt(instrumentIndex);
            InstrumentRepository.Instruments.RemoveAt(instrumentIndex);
            return Ok($"Elemento en posición {instrumentIndex} eliminado con éxito.");
        }
    }
}
