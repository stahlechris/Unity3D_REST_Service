using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unity3d_Restful_service.Contracts;
using Newtonsoft.Json;
namespace Unity3d_Restful_service.Controllers
{
    /// <summary>
    /// We are going to be able to call these methods by using a host
    /// and a port number that gets assigned when we launch the solution.
    ///
    /// We are going to have a persistant layer that is not backed up by a db
    /// that means im making a static list of Players and filling w/ dummy data
    /// </summary>
    ///
    [Route("api/[controller]")]
    //[ApiController]
    public class PlayersController : ControllerBase
    {
        //make a list of players
        public static List<Player> Players = new List<Player>()
        {
            //initialize 3 players in this list
        new Player
        {
            Id = 1,
            Username = "BigCheesey",
            Skeleton = new Skeleton((int)JointId.Count)
        },
        new Player
        {
            Id = 2,
            Username = "Unclefuc3r",
            Skeleton = new Skeleton((int)JointId.Count)
        },
        new Player
        {
            Id = 3,
            Username = "yaboiTim",
            Skeleton = new Skeleton((int)JointId.Count)
        }
    };

        /// <summary>
        /// I am testing returning a JsonResult vs string.
        /// Returning a string formats the data better, and allows for a client to correctly deserialize it.
        /// I am testing this because I could not get my client to correctly deserialize the data when it is sent as a JsonResult.
        ///
        /// TO TEST RETURNING A STRING VS JSONRESULT:
        /// 1. uncomment what is commented out in the Get method and comment out what was uncommented
        /// 2. Go into the Unity project, into the Game.cs -> switcheroo the commenteds
        /// 3. Go to RestClient.cs -> switcheroo the commenteds
        /// </summary>
        /// <returns></returns>
        // GET api/players
        [HttpGet] //get to get a list of Players
        public string Get()
        //public JsonResult Get()

        {
            //this makes a Json array with a single object called Players, which is a List<Player>
            //JsonResult js = new JsonResult(Players);
            string json = JsonConvert.SerializeObject(Players, Formatting.Indented);

            //return js;
            return json;
        }

        // GET api/players/5
        [HttpGet("{id}")]//get to get a Player by id
        public JsonResult Get(int id)
        {
            //simulate searching the db for a player
            //by using lamda match on id
            Player player = Players.Single(p => p.Id == id);
            JsonResult js = new JsonResult(player);

            return js;
        }

        // POST api/players
        [HttpPost] //post to create a new Player
        public JsonResult Post([FromBody] Player newPlayer)
        {
            //return a new list of players
            Players.Add(newPlayer);
            JsonResult js = new JsonResult(Players);
            return js;
        }

        // PUT api/players/5
        [HttpPut("{id}")]//put to obtain an existing Player
        public JsonResult Put(int id, [FromBody] Skeleton newSkeleton)
        {
            Player player = Players.Single(p => p.Id == id);
            player.Skeleton = newSkeleton;
            JsonResult js = new JsonResult(player);
            return js;
        }

        // DELETE api/players/5
        [HttpDelete("{id}")] //delete to delete a player
        public void Delete(int id)
        {
            Player player = Players.Single(p => p.Id == id);
            Players.Remove(player);
        }
    }
}
