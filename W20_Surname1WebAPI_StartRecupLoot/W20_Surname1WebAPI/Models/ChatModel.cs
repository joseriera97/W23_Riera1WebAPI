using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W20_Surname1WebAPI.Models
{
    public class ChatModel
    {

            private string _id;
            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _idPlayer;
            public string IdPlayer
            {
                get { return _idPlayer; }
                set { _idPlayer = value; }
            }

            private string _mensaje;
            public string Mensaje
            {
                get { return _mensaje; }
                set { _mensaje = value; }
            }

        }
    }
