using Faj.Server.Model.Player.Dao.Interface;
using Faj.Common.Model.Player.Structure;
using System.IO;
using ProtoBuf;
using Faj.Server.Model.Player.Exception;

namespace Faj.Server.Model.Player.Dao
{
    class FilePlayerDao : IServerPlayerDao
	{
        public PlayerStructure Load(string playerId)
        {
            var path = GetSavePath(playerId);
            PlayerStructure playerStructure;
            try
            {
                using (var file = File.OpenRead(path))
                {
                    playerStructure = Serializer.Deserialize<PlayerStructure>(file);
                }
            }
            catch (FileNotFoundException)
            {
                throw new NotExistPlayerException("Player not exist: " + playerId);
            }

            return playerStructure;
        }

        public void Save(string playerId, PlayerStructure playerStructure)
        {
            var path = GetSavePath(playerId);
            using (var file = File.Create(path))
            {
                Serializer.Serialize(file, playerStructure);
            }
        }

        string GetSavePath(string playerId)
        {
            return "\\player\\" + playerId;
        }
	}
}
