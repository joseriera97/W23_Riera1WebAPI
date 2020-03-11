using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W20_Surname1WebAPI.Models
{
    [Serializable]
    public class ListaMensajes
    {
        public List<ChatModel> mylist = new List<ChatModel>();

    }
}