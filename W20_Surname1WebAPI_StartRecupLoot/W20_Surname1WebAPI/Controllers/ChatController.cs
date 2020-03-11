using Dapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using W20_Surname1WebAPI.Models;


namespace W20_Surname1WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Chat")]
    public class ChatController : ApiController
    {

        // GET api/Chat/TodosMensajes
        [HttpGet]
        public ListaMensajes TodosMensajes()
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"SELECT Id, IdPlayer, Mensaje FROM dbo.Chat ";
                var mensaje = cnn.Query<ChatModel>(sql).FirstOrDefault();

                var player = cnn.Query<ListaMensajes>(sql).FirstOrDefault();
                return player;
            }
        }

        // POST api/Chat/NuevoMensaje
        [HttpPost]
        public IHttpActionResult NuevoMensaje(ChatModel mensaje)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                //Otener el id maximo
                string id =$"SELECT MAX(Id) + 1 FROM dbo.Chat";
                //string id = $"SELECT MAX(Id) FROM dbo.Chat";

                var identi = cnn.Query<ChatModel>(id).FirstOrDefault();

                //Insertamos el nuevo mensaje
                string sql = "INSERT INTO dbo.Chat(Id, IdPlayer, Mensaje) " +
                    $"VALUES('{identi.Id}','{mensaje.IdPlayer}','{mensaje.Mensaje}')";
               //   $"VALUES('{identi.Id +1}','{mensaje.IdPlayer}','{mensaje.Mensaje}')";

                try
                {
                    cnn.Execute(sql);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error insertando Mensaje en la BBDD: " + ex.Message);
                }

                return Ok();
            }
        }


    }
}