namespace GameCharacter;

class Program
{
    public partial class GameCharacter
    {
        public string CharacterName;
        public int Level;

        public GameCharacter(string characterName, int level)
        {
            this.CharacterName = characterName;
            this.Level = level;
        }
    }
    public partial class GameCharacter
    {
        public void ShowCharacterInfo()
        {
            Console.WriteLine($"\nCharacter Name: {this.CharacterName}\nCharacter level: {this.Level}lvl");
        }
    }
    static void Main(string[] args)
    {
        GameCharacter obj = new GameCharacter("Dragon", 84);
        obj.ShowCharacterInfo();

    }
}
