using System;
using Newtonsoft.Json;

namespace Unity3d_Restful_service.Contracts
{
    [JsonObject,Serializable] //Tell the system this class is going to be a JSON object and we are going to serialize it to a string
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Skeleton Skeleton { get; set; }
        //a Skeleton is a struct of Joint[]
        //a Joint is a struct of float[]position, float[] orientation
    }
}
